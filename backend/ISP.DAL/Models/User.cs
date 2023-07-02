using ISP.DAL.Privillages;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Models
{
    // Employee
    public class User : IdentityUser
    {
        public int? GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group group { get; set; }

        public double? Salary { get; set; }

        [ForeignKey("branch")]
        public int? branchId { get; set; } = null;
        public virtual Branch? branch { get; set; }

        public bool status { get; set; } = true;

        

    }
}
