using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class Student
    {
        public Student()
        {
            PrijavaKvara = new HashSet<PrijavaKvara>();
            PrijavaObroka = new HashSet<PrijavaObroka>();
        }

        public int StudentId { get; set; }
        public int SobaId { get; set; }
        public int BrojBonova { get; set; }
        public int PrijavaStudentaId { get; set; }

        public virtual PrijavaStudenta PrijavaStudenta { get; set; }
        public virtual Soba Soba { get; set; }
        public virtual ICollection<PrijavaKvara> PrijavaKvara { get; set; }
        public virtual ICollection<PrijavaObroka> PrijavaObroka { get; set; }
    }
}
