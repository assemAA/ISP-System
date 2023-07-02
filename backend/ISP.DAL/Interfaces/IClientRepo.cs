using ISP.DAL.Helper;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Interfaces
{
    public interface IClientRepo:IGeneralRepo<Client>
    {
        public Task<Client> GetByNumber(string num);
        public Task<Pagination<IEnumerable<Client>>> getAllPages(int pageSize, int pageNumbe);

    }
}
