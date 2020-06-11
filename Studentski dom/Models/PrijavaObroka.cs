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
        [Display(Name = "Ručak")]
        public bool Rucak { get; set; }
        [Display(Name = "Večera")]
        public bool Vecera { get; set; }
        [Display(Name = "Za ponijet ručak")]
        public bool ZaPonijetRucak { get; set; }
        [Display(Name = "Za ponijet večera")]
        public bool ZaPonijetVecera { get; set; }

        public string createdByUserId { get; set; }
    }
}
