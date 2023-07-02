using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.UsersDtos
{
    public class EditUserDto
    {
        public string Id { get; set; }

        public string? userName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int? branch { get; set; }

        public int? group { get; set; }

        public bool status { get; set; } 

        public double? Salary { get; set; }
    }
}
