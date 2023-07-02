using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.UsersDtos
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [Required]
        public int group { get; set; }
        [Required]
        public int branch { get; set; }

        public double salary { get; set; }

        public string mobile { get; set; }

        public bool status { get; set; } = true;


    }
}
