using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Models
{
    public  class Governarate
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Code is not valid")]
        //[Index(IsUnique =true)]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
