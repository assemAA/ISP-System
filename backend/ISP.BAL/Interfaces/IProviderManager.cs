using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IProviderManager
    {
        public Task<IEnumerable<InternetServiceProvider>> getProviders();

        public Task<InternetServiceProvider> getProviderById(int id);

        public Task addProvider(InternetServiceProvider provider);

        public Task removeProvider(int id);

        public Task updateProvider(InternetServiceProvider provider);

        public Task saveChanges();

    }
}
