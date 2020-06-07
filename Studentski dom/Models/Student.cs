using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int SobaID { get; set; }
        public virtual Soba Soba { get; set; }
        [Display(Name = "Broj bonova")]
        public int BrojBonova { get; set; }
        [Display(Name = "ID prijave u dom")]
        public int PrijavaStudentaID { get; set; }
        public virtual PrijavaStudenta PrijavaStudenta { get; set; }

        public string ImePrezime { get { return PrijavaStudenta.ImePrezime; } }
    }


}
