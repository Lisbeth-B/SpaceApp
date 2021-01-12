using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApp.Models
{
    public class RegisterModel
    {
        public string IdNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsMarried { get; set; }
        public bool? IsWorker { get; set; }
        public string Address { get; set; }
        public Decimal? Salary { get; set; }
    }
}
