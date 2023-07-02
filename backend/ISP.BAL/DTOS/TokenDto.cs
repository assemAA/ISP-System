using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS
{
    public  class TokenDto
    {
        public string token { get; set; }

        public DateTime expireDate { get; set; }
    }
}
