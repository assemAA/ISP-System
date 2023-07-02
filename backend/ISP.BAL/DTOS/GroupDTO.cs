using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS
{
    public  class GroupDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsManager { get; set; }

        public bool IsEmployee { get; set; }

        public bool ReadClients { get; set; }

        public bool ReadWriteClients { get; set; }

    }
}
