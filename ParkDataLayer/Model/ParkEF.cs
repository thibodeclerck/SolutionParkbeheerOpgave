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
        [Key]
        public string Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Naam { get; set; }
        [MaxLength(500)]
        public string Locatie { get; set; }
    }
}
