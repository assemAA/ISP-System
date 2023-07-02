using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class RegisterForm
    {
        public string username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public int group { get; set; }

        public int branch { get; set; }

        public double salary { get; set; }

        public string mobile { get; set; }

        public bool status { get; set; } = true;


    }
}
