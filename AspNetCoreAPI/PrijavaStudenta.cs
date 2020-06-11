using System;
using System.Collections.Generic;

namespace AspNetCoreAPI
{
    public partial class PrijavaStudenta
    {
        public PrijavaStudenta()
        {
            Student = new HashSet<Student>();
        }

        public int PrijavaStudentaId { get; set; }
        public string ImePrezime { get; set; }
        public string Jmbg { get; set; }
        public string AdresaStanovanja { get; set; }
        public string Fakultet { get; set; }
        public int GodinaStudiranja { get; set; }
        public int CiklusStudija { get; set; }
        public int BrojIndeksa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Fotografija { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
