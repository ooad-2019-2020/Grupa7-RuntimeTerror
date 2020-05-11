using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class PrijavaKvara
    {
        public int PrijavaKvaraID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public string TipKvara { get; set; }
        public string OpisKvara { get; set; }
        public DateTime VrijemePrijave { get; set; }
        public DateTime VrijemeRjesenja { get; set; }
        public bool HitanKvar { get; set; }
    }
}
