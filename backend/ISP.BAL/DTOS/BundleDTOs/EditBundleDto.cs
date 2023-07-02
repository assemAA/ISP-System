using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.BundleDTOs
{
    public class EditBundleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


        public string BundleType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public int ProviderID { get; set; }


        public int Price { get; set; }

        public bool IsActive { get; set; }
        public int BuyingPrice { get; set; }
    }
}
