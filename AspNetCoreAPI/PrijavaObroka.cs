using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class PrijavaObroka
    {
        public int PrijavaObrokaId { get; set; }
        public int StudentId { get; set; }
        public bool Rucak { get; set; }
        public bool Vecera { get; set; }
        public bool ZaPonijetRucak { get; set; }
        public bool ZaPonijetVecera { get; set; }
        public string CreatedByUserId { get; set; }

        public virtual Student Student { get; set; }
    }
}
