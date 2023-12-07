using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapHuurcontract
    {
        public static HuurcontractEF MapFromDomain(Huurcontract huurcontract)
        {
            HuurcontractEF huurEF = new HuurcontractEF(huurcontract.Id, huurcontract.Huurperiode.StartDatum, huurcontract.Huurperiode.EindDatum, huurcontract.Huurperiode.Aantaldagen, MapHuurder.MapFromDomain(huurcontract.Huurder));
            return huurEF;
        }

        public static Huurcontract MapToDomain(HuurcontractEF huurcontractEF)
        {
            Huurcontract hc = new Huurcontract(huurcontractEF.Id, new Huurperiode(huurcontractEF.StartDatum, huurcontractEF.Dagen), MapHuurder.MapToDomain(huurcontractEF.Huurder));
        }
    }
}
