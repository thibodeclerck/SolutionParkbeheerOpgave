using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private string connectionString;
        private ParkBeheerContext ctx;

        public HuizenRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
            this.ctx = new ParkBeheerContext(connectionString);
        }

        public Huis GeefHuis(int id)
        {
            try
            {
                HuisEF huisEF = ctx.Huis.Where(x => x.Id == id)
                    .Include(x => x.Park)
                    .FirstOrDefault();
                if (huisEF == null)
                {
                    throw new RepositoryException("Huis bestaat niet");
                }
                else return MapHuis.MapToDomain(huisEF);               
            } 
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return ctx.Huis.Any(huis => huis.Straat == straat && huis.Nr == nummer && huis.Park == MapPark.MapFromDomain(park));               
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("VogeHuisToe");
            }
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return ctx.Huis.Any(huis => huis.Id == id);                
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("VogeHuisToe");
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                var huisUpdate = ctx.Huis.Single(x => x.Id == huis.Id);

                if(huisUpdate != null)
                {
                    huisUpdate.Nr = huis.Nr;
                    huisUpdate.Straat = huis.Straat;
                    huisUpdate.Actief = huis.Actief;
                    ctx.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new RepositoryException("UpdateHuis");
            }
        }

        public Huis VoegHuisToe(Huis h)
        {
            try
            {
                ParkEF parkEF = ctx.Park.FirstOrDefault(x => x.Id == h.Park.Id);

                HuisEF huisEF = MapHuis.MapFromDomain(h);
                if (parkEF != null)
                {
                    huisEF.Park = parkEF;
                }
                ctx.Huis.Add(huisEF);
                ctx.SaveChanges();
                h.ZetId(huisEF.Id);
                return h;
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }
    }
}
