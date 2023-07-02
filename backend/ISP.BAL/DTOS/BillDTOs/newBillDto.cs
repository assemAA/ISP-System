using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.BillDTOs
{
    public class newBillDto
    {
        public string phoneNumber { get; set; }
        public string clientName { get; set; }

        public string governate { get; set; }

        public string branch { get; set; }

        public string central { get; set; }

        public string provider { get; set; }

        public DateTime billCreated { get; set; }

        public DateTime billExpired { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public string bundle { get; set; }
        public double bundleCost { get; set; }

        public double totalCost { get; set; }


        public bool payed { get; set; }
    }
}
