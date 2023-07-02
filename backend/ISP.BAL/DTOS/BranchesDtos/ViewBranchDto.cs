using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.BranchesDtos
{
    public class ViewBranchDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string governate { get; set; }

        public string PhoneNumberOne { get; set; }

        public string PhoneNumberTwo { get; set; }

        public string MobileNumberOne { get; set; }

        public string MobileNumberTwo { get; set; }

        public string Fax { get; set; }


        public string Manager { get; set; }
    }
}
