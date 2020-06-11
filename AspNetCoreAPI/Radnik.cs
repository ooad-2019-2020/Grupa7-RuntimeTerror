using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class Radnik
    {
        public int RadnikId { get; set; }
        public int UposlenikId { get; set; }
        public int? UposlenikDomaId { get; set; }
        public string Usluga { get; set; }
        public string ImePrezime { get; set; }
        public string BrojTelefona { get; set; }

        public virtual UposlenikDoma UposlenikDoma { get; set; }
    }
}
