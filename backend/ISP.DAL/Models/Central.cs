using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class Central
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Governarate")]
        public int GovernarateId { get; set; }

        public virtual Governarate Governarate { get; set; }
    }
}
