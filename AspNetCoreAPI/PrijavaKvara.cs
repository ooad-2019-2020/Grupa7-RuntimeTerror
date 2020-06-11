using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class PrijavaKvara
    {
        public int PrijavaKvaraId { get; set; }
        public int StudentId { get; set; }
        public string TipKvara { get; set; }
        public string OpisKvara { get; set; }
        public DateTime VrijemePrijave { get; set; }
        public bool HitanKvar { get; set; }
        public bool? Rijeseno { get; set; }
        public string CreatedByUserId { get; set; }

        public virtual Student Student { get; set; }
    }
}
