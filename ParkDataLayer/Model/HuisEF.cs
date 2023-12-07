using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        public HuisEF()
        {
        }

        public HuisEF(int id, string straat, int nr, bool actief, List<HuurcontractEF> huurcontracten)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            Huurcontracten = huurcontracten;
        }

        public HuisEF(string straat, int nr, bool actief, List<HuurcontractEF> huurcontracten)
        {
            Straat = straat;
            Nr = nr;
            Actief = actief;
            Huurcontracten = huurcontracten;
        }

        public int Id { get; set; }
        [MaxLength(250)]
        public string Straat { get; set; }
        [Required]
        public int Nr { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool Actief { get; set; }
        public ParkEF Park { get; set; }

        public List<HuurcontractEF> Huurcontracten { get; set; }
    }
}
