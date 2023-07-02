using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.ClientDTOs
{
    public class ViewClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string GovernarateName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
        public string Bundle { get; set; } = string.Empty;
        public string Central { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Mobile1 { get; set; } = string.Empty;
        public string LineOwner { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;


    }
}
