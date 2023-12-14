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
    public static class MapPark
    {
        public static ParkEF MapFromDomain(Park p)
        {
            try
            {
            ParkEF parkEF = new ParkEF(p.Id, p.Naam, p.Locatie);

            return parkEF;

            } catch (Exception ex)
            {
                throw new MapperException("MapParkFromDomain");
            }

        }

        public static Park MapToDomain(ParkEF ef)
        {
            try
            {
            Park p = new Park(ef.Id, ef.Naam, ef.Locatie);
            return p;

            } catch (Exception ex)
            {
                throw new MapperException("MapParkToDomain");
            }
        }
    }
}
