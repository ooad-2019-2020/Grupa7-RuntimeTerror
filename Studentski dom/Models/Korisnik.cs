using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_dom.Models
{
    public class Korisnik : IdentityUser
    {
        public int StudentId { get; set; }
    }
}
