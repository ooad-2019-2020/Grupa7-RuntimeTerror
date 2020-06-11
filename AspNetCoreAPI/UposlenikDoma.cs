using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class UposlenikDoma
    {
        public UposlenikDoma()
        {
            Radnik = new HashSet<Radnik>();
        }

        public int UposlenikDomaId { get; set; }
        public string ImePrezime { get; set; }
        public string BrojTelefona { get; set; }

        public virtual ICollection<Radnik> Radnik { get; set; }
    }
}
