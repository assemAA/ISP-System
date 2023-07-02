using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public  class Token
    {
        public string token { get; set; }

        public DateTime expireDate { get; set; }

        public string role { get; set; }
        public Token(string token, DateTime expireDate , string role)
        {
            this.token = token;
            this.expireDate = expireDate;
            this.role = role;
        }
    }
}
