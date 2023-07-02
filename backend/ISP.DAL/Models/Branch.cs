using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
        [ForeignKey("governarate")]
        public int GovernarateId { get; set; }
        public virtual Governarate? governarate { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "phone  is not valid")]
        [Required]
        public string PhoneNumberOne { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "phone  is not valid")]
        [Required]
        public string PhoneNumberTwo { get; set;}

        [RegularExpression("^[0-9]*$", ErrorMessage = "phone  is not valid")]
        [Required]
        public string MobileNumberOne { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "phone  is not valid")]
        [Required]
        public string MobileNumberTwo { get; set;}

        [Required]
        public string Fax { get; set; }

        [ForeignKey("Magnager")]
        public string? ManagerId { get; set; }
        public virtual User? Magnager { get; set; }
        public virtual ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public virtual ICollection<BranchOffer> BranchOffers { get; set; } = new HashSet<BranchOffer>();


    }
}
