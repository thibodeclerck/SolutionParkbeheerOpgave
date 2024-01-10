using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private string connectionString;
        private ParkBeheerContext ctx;

        public ContractenRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
            this.ctx = new ParkBeheerContext(connectionString);
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                HuurcontractEF hcEF = ctx.Huurcontract.Find(contract.Id);
                ctx.Huurcontract.Remove(hcEF);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new RepositoryException("");
            }
        }

        public Huurcontract GeefContract(string id)
        {
            return MapHuurcontract.MapToDomain(
                ctx.Huurcontract.Where(x => x.Id == id)
                .Include(x => x.Huurder)
                .Include(x => x.Huis)
                .ThenInclude(x => x.Park)
                .FirstOrDefault()
                );
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {

            if (dtEinde == null)
                {
                    return ctx.Huurcontract.Where(x => x.StartDatum >= dtBegin)
                        .Include(x => x.Huurder)
                        .Include(x => x.Huis)
                        .ThenInclude(x => x.Park)
                        .Select(x => MapHuurcontract.MapToDomain(x))
                        .ToList();
                }else
                {
                    return ctx.Huurcontract.Where(x => x.StartDatum >= dtBegin && x.EindDatum <= dtEinde)
                        .Include(x => x.Huurder)
                        .Include(x => x.Huis)
                        .ThenInclude(x => x.Park)
                        .Select(x => MapHuurcontract.MapToDomain(x))
                        .ToList();
                }

            } catch (Exception ex)
            {
                throw new RepositoryException("");
              }
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return ctx.Huurcontract.Any(x => x.StartDatum == startDatum && x.Huurder.Id == huurderid && x.Huis.Id == huisid);

            } catch (Exception ex)
            {
                throw new RepositoryException("");
              }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return ctx.Huurcontract.Any(x => x.Id == id);
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("");
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                HuurcontractEF hcEF = ctx.Huurcontract.Single(x => x.Id == contract.Id);
                HuisEF huis = null;
                if (hcEF.Huis.Id != contract.Huis.Id)
                {
                    huis = ctx.Huis.Single(x => x.Id == contract.Huis.Id);
                }
                HuurderEF huurder = null;
                if (hcEF.Huurder.Id != contract.Huurder.Id)
                {
                    huurder = ctx.Huurder.Single(x => x.Id != contract.Huurder.Id);
                }

                if(hcEF != null)
                {
                    hcEF.Dagen = contract.Huurperiode.Aantaldagen;
                    hcEF.StartDatum = contract.Huurperiode.StartDatum;
                    hcEF.EindDatum = contract.Huurperiode.EindDatum;
                    if (huurder != null)
                    {
                        hcEF.Huurder = huurder;
                    }
                    if(huis != null)
                    {
                        hcEF.Huis = huis;
                    }
                    ctx.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("");
              }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                if (contract.Huurperiode.StartDatum < DateTime.Now)
                {
                    throw new RepositoryException("startDatum is in het verleden");
                }

            HuurcontractEF hcEF = MapHuurcontract.MapFromDomain(contract);

            if (contract.Huurder.Id != 0)
            {
                HuurderEF huurder = ctx.Huurder.Find(hcEF.Huurder.Id);
                ctx.Attach(huurder);
                hcEF.Huurder = huurder;
            }
            if (contract.Huis.Id != 0)
            {
                HuisEF huis = ctx.Huis.Find(hcEF.Huis.Id);
                ctx.Attach(huis);
                hcEF.Huis = huis;
            }
            if(!string.IsNullOrWhiteSpace(contract.Huis.Park.Id))
            {
                ParkEF park = ctx.Park.Find(contract.Huis.Park.Id);
                ctx.Attach(park);
                hcEF.Huis.Park = park;
            }
            ctx.Huurcontract.Add(hcEF);

            ctx.SaveChanges();
            } catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
              }
        }
    }
}
