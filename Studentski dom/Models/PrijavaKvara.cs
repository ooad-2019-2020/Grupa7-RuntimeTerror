﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class PrijavaKvara
    {
        public int PrijavaKvaraID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        [Display (Name = "Tip kvara")]
        public string TipKvara { get; set; }
        [Display (Name = "Opis kvara")]
        public string OpisKvara { get; set; }
        [Display(Name = "Vrijeme prijave")]
        public DateTime VrijemePrijave { get; set; }
        [Display(Name = "Vrijeme rjesenja")]
        public DateTime VrijemeRjesenja { get; set; }
        [Display(Name = "Hitan kvar")]
        public bool HitanKvar { get; set; }
    }
}