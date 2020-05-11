using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class PrijavaStudenta
    {
        public int PrijavaStudentaID { get; set; }
        public string ImePrezime { get; set; }
        public string JMBG { get; set; }
        public string AdresaStanovanja { get; set; }
        public string Fakultet { get; set; }
        public int GodinaStudiranja { get; set; }
        public int CiklusStudija { get; set; }
        public int BrojIndeksa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Fotografija { get; set; }
    }
}
