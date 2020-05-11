using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class PrijavaStudenta
    {
        public int PrijavaStudentaID { get; set; }
        [Display (Name = "Ime i prezime")]
        public string ImePrezime { get; set; }
        public string JMBG { get; set; }
        [Display (Name = "Adresa stanovanja")]
        public string AdresaStanovanja { get; set; }
        public string Fakultet { get; set; }
        [Display (Name = "Godina studiranja")]
        public int GodinaStudiranja { get; set; }
        [Display(Name = "Ciklus studija")]
        public int CiklusStudija { get; set; }
        [Display(Name = "Broj indeksa")]
        public int BrojIndeksa { get; set; }
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Fotografija { get; set; }
    }
}
