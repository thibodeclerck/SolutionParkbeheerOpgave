﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Straat { get; set; }
        [Required]
        public int Nr { get; set; }
        public bool Actief { get; set; }
    }
}
