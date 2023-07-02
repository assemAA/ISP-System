using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.BranchesDtos
{
    public class EditAddBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GovernarateId { get; set; }

        public string PhoneNumberOne { get; set; }

        public string PhoneNumberTwo { get; set; }

        public string MobileNumberOne { get; set; }

        public string MobileNumberTwo { get; set; }

        public string Fax { get; set; }


        public string? ManagerId { get; set; }
    }
}
