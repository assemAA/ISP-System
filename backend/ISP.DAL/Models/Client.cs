using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public  class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]  //Plus==>
        public int SSN { get; set; }
        [Required]

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [RegularExpression("^[0-9]*$", ErrorMessage = "phone  is not valid")]

        [Required]
        public string Phone { get; set; } = string.Empty;


        // public string Status { get; set; } = string.Empty;

        [ForeignKey("Governarate")]
        public int GovernarateCode { get; set; }
        public virtual Governarate? Governarate { get; set; }

        public string Address { get; set; } = string.Empty;

        [EmailAddress]  
        public string Email { get; set; } = string.Empty;

        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public virtual InternetServiceProvider? Provider { get; set; }


        [ForeignKey("Bundle")]
        public int BundleId { get; set; }
        public virtual Bundle? Bundle { get; set; }

        [ForeignKey("Central")]
        public int CentralId { get; set; }
        public virtual Central? Central { get; set; }

        public int? IpPackage { get; set; }
        public DateTime Contractdate { get; set; }
        public string Mobile1 { get; set; } = string.Empty;

        public string Mobile2 { get; set; } = string.Empty;

        public string LineOwner { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        public string RouterSerial { get; set; } = string.Empty;

        public int? OrderNumber { get; set; }

        public int? PortSlot { get; set; }


        public int? PortBlock { get; set; }

        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public int? VPI { get; set; }
        public int? VCI { get; set; }

        public int? OrderWorkNumber { get; set; }


        public DateTime Orderworkdate { get; set; }

        public double PrePaid { get; set; }

        public double InstallationFee { get; set; }
        public double ContractFee { get; set; }

        public int? SlotNum { get; set; }


        public int? BlockNum { get; set; }

        public List<Offer> offers { get; set; }

        public List<ClientTakeOffer> client_offer { get; set; }

        public List<Bill> bills { get; set; } 
    }
}
