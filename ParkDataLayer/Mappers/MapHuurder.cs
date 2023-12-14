using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapHuurder
    {
        public static HuurderEF MapFromDomain(Huurder huurder)
        {
            try
            {
            HuurderEF map = new HuurderEF(huurder.Id, huurder.Naam, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Email, huurder.Contactgegevens.Adres);
            return map;

            } catch (Exception ex)
            {
                throw new MapperException("MapHuurderFromDomain");
            }
        }

        public static Huurder MapToDomain(HuurderEF huurderEF)
        {
            try
            {
            Huurder h = new Huurder(huurderEF.Id, huurderEF.Naam, new Contactgegevens(huurderEF.Email, huurderEF.Telefoon, huurderEF.Adres));
            return h;

            } catch (Exception ex)
            {
                throw new MapperException("MapHuurderToDomain");
            }
        }
    }
}
