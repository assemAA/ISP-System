using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public DateTime date { get; set; } = DateTime.Now; 


        public DateTime expireDate { get; set; } = DateTime.Now.AddMonths(1);

        public int Month { get; set; } = DateTime.Now.Month;

        public int year { get; set; } = DateTime.Now.Year;
        public double cost { get; set; }

        public bool payed { get; set; }
    }
}
