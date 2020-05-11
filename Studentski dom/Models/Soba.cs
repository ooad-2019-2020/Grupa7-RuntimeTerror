using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class Soba
    {
        public int SobaID { get; set; }
        public int BrojSobe { get; set; }
        public bool Zauzeta { get; set; }
        public int Sprat { get; set; }
    }
}
