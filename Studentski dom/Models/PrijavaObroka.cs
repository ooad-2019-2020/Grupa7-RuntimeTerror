using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Za ponijet rucak")]
        public bool ZaPonijetRucak { get; set; }
        [Display(Name = "Za ponijet vecera")]
        public bool ZaPonijetVecera { get; set; }
    }
}
