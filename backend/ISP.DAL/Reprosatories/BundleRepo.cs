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
    public class BundleRepo : IGeneralRepo<Bundle>
    {
        private readonly ContextDb context;
        public BundleRepo(ContextDb context)
        {
            this.context = context;
        }
        public async Task addItem(Bundle item)
        {
            await context.Bundles.AddAsync(item);
        }

        public async Task<IEnumerable<Bundle>> getAll()
        {
            return await context.Bundles.Include("provider").ToListAsync();

        }

        public async Task<Bundle> getById(int id)
        {
            return await context.Bundles.Include("provider").FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task removeItem(int id)
        {
            Bundle bundle = await context.Bundles.FirstOrDefaultAsync(c => c.Id == id);
            if (bundle != null) context.Bundles.Remove(bundle);
        }

        public async Task saveChanges()
        {
            await context.SaveChangesAsync();
        }


        public async Task updateItem(Bundle item)
        {
            Bundle bundle = await context.Bundles.FirstOrDefaultAsync(ele => ele.Id == item.Id);
            if (bundle != null)
            {
                bundle.Id = item.Id;
                bundle.Name = item.Name;
                bundle.BundleType = item.BundleType;
                bundle.ProviderID = item.ProviderID;
                bundle.Notes = item.Notes;
                bundle.Price = item.Price;
                bundle.IsActive = item.IsActive;
                bundle.BuyingPrice = item.BuyingPrice;

            }
        }
    }
}
