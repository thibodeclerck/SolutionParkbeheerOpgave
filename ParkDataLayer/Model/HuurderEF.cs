using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        public HuurderEF()
        {
        }

        public HuurderEF(int id, string naam, string telefoon, string email, string adres)
        {
            Id = id;
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;           
        }

        public HuurderEF(int id, string naam, string telefoon, string email, string adres, List<HuurcontractEF> huurcontracten) : this(id, naam, telefoon, email, adres)
        {
            Huurcontracten = huurcontracten;
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }
        [MaxLength(100)]
        public string Telefoon { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Adres { get; set; }
        public List<HuurcontractEF> Huurcontracten { get; set; }

        public override bool Equals(object obj)
        {
            return obj is HuurderEF huurderEF &&
                   EqualityComparer<int>.Default.Equals(Id, huurderEF.Id) &&
                   EqualityComparer<string>.Default.Equals(Naam, huurderEF.Naam);                   
        }
    }
}
