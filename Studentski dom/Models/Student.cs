using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int SobaID { get; set; }
        public virtual Soba Soba { get; set; }
        public int BrojBonova { get; set; }
        public int PrijavaStudentaID { get; set; }
        public virtual PrijavaStudenta PrijavaStudenta { get; set; }
    }
}
