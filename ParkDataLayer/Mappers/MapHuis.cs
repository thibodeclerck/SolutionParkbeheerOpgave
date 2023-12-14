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
    public static class MapHuis
    {
        public static HuisEF MapFromDomain(Huis huis)
        {
            try
            {
                return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, MapPark.MapFromDomain(huis.Park));
            }
            catch(Exception ex)
            {
                throw new MapperException("MapHuisFromDomain");
            }
        }

        public static Huis MapToDomain(HuisEF huisEF)
        {
            try
            {
            Huis huis = new Huis(huisEF.Id,huisEF.Straat, huisEF.Nr, huisEF.Actief, MapPark.MapToDomain(huisEF.Park));
            return huis;

            } catch (Exception ex)
            {
                throw new MapperException("MapHuisToDomain");
            }
        }
    }
}
