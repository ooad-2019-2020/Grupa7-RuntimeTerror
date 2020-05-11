using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class PrijavaObroka
    {
        public int PrijavaObrokaID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public bool Rucak { get; set; }
        public bool Vecera { get; set; }
        public bool ZaPonijetRucak { get; set; }
        public bool ZaPonijetVecera { get; set; }
    }
}
