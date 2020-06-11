using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class Soba
    {
        public Soba()
        {
            Student = new HashSet<Student>();
        }

        public int SobaId { get; set; }
        public int BrojSobe { get; set; }
        public bool Zauzeta { get; set; }
        public int Sprat { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
