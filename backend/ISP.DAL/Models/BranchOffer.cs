using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class BranchOffer
    {
        [ForeignKey("OffersId")]
        public int OffersId { get; set; }
        [ForeignKey("BranchesId")]
        public int BranchesId { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
