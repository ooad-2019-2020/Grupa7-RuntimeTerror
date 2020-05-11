using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class Radnik
    {
        public int RadnikID { get; set; }
        public int UposlenikID { get; set; }
        public virtual UposlenikDoma UposlenikDoma { get; set; }
        public string Usluga { get; set; }
        [Display(Name = "Ime i prezime")]
        public string ImePrezime { get; set; }
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }
    }
}
