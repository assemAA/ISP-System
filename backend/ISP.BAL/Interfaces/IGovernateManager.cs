using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IGovernateManager
    {
        public Task<IEnumerable<Governarate>> GetGovernarates();
        public Task<Governarate> GetGovernarateById(int id);

        public Task updateGovernate (Governarate governarate);

        public Task removeGovernate (int id);

        public Task addGovernate(Governarate governarate);

        public Task saveChanges();

    }
}
