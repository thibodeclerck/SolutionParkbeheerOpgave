using ParkBusinessLayer.Model;
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
            List<HuurcontractEF> huurcontracten = huis.Huurcontracten().Select(x => MapHuurcontract.MapFromDomain(x)).ToList();
            //List<HuurderEF> huurders = new List<HuurderEF>();
            //List<HuurcontractEF> contractenEF = new List<HuurcontractEF>();

            //foreach (Huurcontract contract in huurcontracten)
            //{
            //    HuurderEF h = MapHuurder.MapFromDomain(contract.Huurder);
            //    HuurcontractEF hc = MapHuurcontract.MapFromDomain(contract);
            //    hc.Huurder = h;
            //    if (huurders.Contains(h))
            //    {
            //        int index = huurders.IndexOf(h);
            //        huurders[index].Huurcontracten.Add(hc);
            //    } else
            //    {
            //        h.Huurcontracten.Add(hc);
            //        huurders.Add(h);
            //    }
            //}
            return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, huurcontracten);
        }

        public static Huis MapToDomain(HuisEF huisEF)
        {
            Huis huis = new Huis(huisEF.Straat, huisEF.Nr, MapPark.MapToDomain(huisEF.Park));
            return huis;
        }
    }
}
