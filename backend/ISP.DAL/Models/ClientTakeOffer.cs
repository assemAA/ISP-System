using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public  class ClientTakeOffer
    {
        [Key]
         public int Id { get; set; }

        [ForeignKey("offer")]
        public int offerId { get; set; }

        public Offer? offer { get; set; }

        public DateTime startDate { get; set; } = DateTime.Now;

        public DateTime endDate { get; set; }
        
    }
}
