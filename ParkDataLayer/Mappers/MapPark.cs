using ParkBusinessLayer.Model;
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
            //List<HuisEF> huizenEF = p.Huizen().Select(x => MapHuis.MapFromDomain(x)).ToList();

            ParkEF parkEF = new ParkEF(p.Id, p.Naam, p.Locatie);

            return parkEF;
        }

        public static Park MapToDomain(ParkEF ef)
        {
            Park p = new Park(ef.Id, ef.Naam, ef.Locatie);
            return p;
        }
    }
}
