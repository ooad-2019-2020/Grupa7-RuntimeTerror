using System;
using System.Collections.Generic;
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
        public string ImePrezime { get; set; }
        public string BrojTelefona { get; set; }
    }
}
