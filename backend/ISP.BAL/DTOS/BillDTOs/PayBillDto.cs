using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.BillDTOs
{
    public class PayBillDto
    {
        public string phoneNumber { get; set; }

        public int month { get; set; }

        public int year { get; set; }
    }
}
