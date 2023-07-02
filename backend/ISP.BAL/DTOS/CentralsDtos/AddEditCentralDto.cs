using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.CentralsDtos
{
    public  class AddEditCentralDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GovernarateId { get; set; }
    }
}
