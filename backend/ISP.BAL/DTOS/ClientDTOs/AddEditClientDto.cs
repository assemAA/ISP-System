using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.ClientDTOs
{
    public class AddEditClientDto
    {
        public int Id { get; set; }

        public int SSN { get; set; }


        public string Name { get; set; } = string.Empty;



        public string Phone { get; set; } = string.Empty;


        // public string Status { get; set; } = string.Empty;


        public int GovernarateCode { get; set; }


        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int ProviderId { get; set; }


        public int BundleId { get; set; }


        public int CentralId { get; set; }


        public int? IpPackage { get; set; }
        public DateTime Contractdate { get; set; }
        public string Mobile1 { get; set; } = string.Empty;

        public string Mobile2 { get; set; } = string.Empty;

        public string LineOwner { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public int BranchId { get; set; }


        public string RouterSerial { get; set; } = string.Empty;

        public int? OrderNumber { get; set; }

        public int? PortSlot { get; set; }


        public int? PortBlock { get; set; }

        public string UserName { get; set; } = string.Empty;
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

        public List<int> offers { get; set; }
    }
}
