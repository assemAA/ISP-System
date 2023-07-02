using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Privillages
{
    public enum Privileges
    {
        Admin ,
        Manager ,
        CEO , 
        Employee , 
        Client ,
        UserCanReadEmployeesData ,
        UserCanReadWriteEmployeesData,
        UserCanReadClientsData,
        UserCanReadWriteClientsData,
    }
}
