using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class Bundle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string BundleType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        [ForeignKey("provider")]
        public int ProviderID { get; set; }
        public InternetServiceProvider provider { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public double BuyingPrice { get; set; }
    }
}
