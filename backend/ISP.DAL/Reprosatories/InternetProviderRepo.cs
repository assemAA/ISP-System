using ISP.DAL.Context;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Reprosatories
{
    public class InternetProviderRepo : IGeneralRepo<InternetServiceProvider>
    {
        private readonly ContextDb _contextDb;

        public InternetProviderRepo(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public async Task addItem(InternetServiceProvider item)
        {
            await _contextDb.InternetServiceProviders.AddAsync(item);
        }

        public async Task<IEnumerable<InternetServiceProvider>> getAll()
        {
            return await _contextDb.InternetServiceProviders.ToListAsync();

        }

        public async Task<InternetServiceProvider> getById(int id)
        {
            return await _contextDb.InternetServiceProviders.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task removeItem(int id)
        {
            InternetServiceProvider provider = await _contextDb.InternetServiceProviders.FirstOrDefaultAsync(c => c.Id == id);
            if (provider != null) _contextDb.InternetServiceProviders.Remove(provider);
        }

        public async Task saveChanges()
        {
            await _contextDb.SaveChangesAsync();
        }

        public async Task updateItem(InternetServiceProvider item)
        {
            InternetServiceProvider provider = await _contextDb.InternetServiceProviders.FirstOrDefaultAsync(ele => ele.Id == item.Id);
            if (provider != null)
            {
                provider.Id = item.Id;
                provider.Name = item.Name;

            }
        }
    }
}
