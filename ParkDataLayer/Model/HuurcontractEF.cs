using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        public HuurcontractEF()
        {
        }

        public HuurcontractEF(string id, DateTime startDatum, DateTime eindDatum, int dagen, HuurderEF huurder)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Dagen = dagen;
            Huurder = huurder;
        }

        [Key]
        [MaxLength(25)]
        public string Id { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public int Dagen { get; set; }
        public HuurderEF Huurder { get; set; }
        //public HuisEF Huis { get; set; }
    }
}
