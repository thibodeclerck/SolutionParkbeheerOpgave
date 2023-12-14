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
    public static class MapHuurcontract
    {
        public static HuurcontractEF MapFromDomain(Huurcontract huurcontract)
        {
            try
            {
            HuurcontractEF huurEF = new HuurcontractEF(huurcontract.Id, huurcontract.Huurperiode.StartDatum, huurcontract.Huurperiode.EindDatum, huurcontract.Huurperiode.Aantaldagen, MapHuurder.MapFromDomain(huurcontract.Huurder), MapHuis.MapFromDomain(huurcontract.Huis));
            return huurEF;

            } catch (Exception ex)
            {
                throw new MapperException("MapHuurcontractFromDomain");
            }
        }

        public static Huurcontract MapToDomain(HuurcontractEF huurcontractEF)
        {
            try
            {
            Huurcontract hc = new Huurcontract(huurcontractEF.Id, new Huurperiode(huurcontractEF.StartDatum, huurcontractEF.Dagen), MapHuurder.MapToDomain(huurcontractEF.Huurder), MapHuis.MapToDomain(huurcontractEF.Huis));
            return hc;

            } catch (Exception ex)
            {
                throw new MapperException("MapHuurcontractToDomain");
            }
        }
    }
}
