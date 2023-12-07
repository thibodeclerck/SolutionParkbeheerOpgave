using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        public ParkEF()
        {
        }

        public ParkEF(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        //public ParkEF(string id, string naam, string locatie, List<HuisEF> huizen)
        //{
        //    Id = id;
        //    Naam = naam;
        //    Locatie = locatie;
        //    Huizen = huizen;
        //}

        [Key]
        [MaxLength(20)]
        public string Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Naam { get; set; }
        [MaxLength(500)]
        public string Locatie { get; set; }
        //public List<HuisEF> Huizen { get; set; }
    }
}
