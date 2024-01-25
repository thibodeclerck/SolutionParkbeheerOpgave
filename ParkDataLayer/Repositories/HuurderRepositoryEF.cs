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
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private string connectionString;
        private ParkBeheerContext ctx;

        public HuurderRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
            this.ctx = new ParkBeheerContext(connectionString);
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                HuurderEF huurder = 
                    ctx.Huurder.Where(x => x.Id == id)
                    .FirstOrDefault()
                    ;
                if (huurder != null)
                {
                    return MapHuurder.MapToDomain(huurder);
                } 
                else throw new RepositoryException("Huurder bestaat niet");
            } 
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(naam))
                {
                    return ctx.Huurder
                     .Where(x => x.Naam == naam)
                     .Select(MapHuurder.MapToDomain)
                     .ToList();
                }else
                {
                    return ctx.Huurder
                     .Select(MapHuurder.MapToDomain)
                     .ToList();
                }
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurders");
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return ctx.Huurder.Any(x => x.Naam == naam && x.Telefoon == contact.Tel && x.Email == contact.Email && x.Adres == contact.Adres);
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder");
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return ctx.Huurder.Any(x => x.Id == id);
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder");
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                HuurderEF huurderUpdate = ctx.Huurder.Single(x => x.Id == huurder.Id);
                
                if (huurderUpdate != null)
                {
                    huurderUpdate.Adres = huurder.Contactgegevens.Adres;
                    huurderUpdate.Email = huurder.Contactgegevens.Email;
                    huurderUpdate.Telefoon = huurder.Contactgegevens.Tel;
                    huurderUpdate.Naam = huurder.Naam;
                    ctx.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuurder");
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            try
            {
                HuurderEF hEF = MapHuurder.MapFromDomain(h);
                ctx.Huurder.Add(hEF);
                ctx.SaveChanges();
                h.ZetId(hEF.Id);
                return h;
            } 
            catch (Exception ex)
            {
                throw new RepositoryException("VoegHuurderToe");
            }
        }
    }
}
