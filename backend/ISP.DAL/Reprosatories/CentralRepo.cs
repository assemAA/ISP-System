using ISP.DAL.Context;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Reprosatories
{
    public class CentralRepo :IGeneralRepo<Central>
    {
        private readonly ContextDb _db;
        public CentralRepo(ContextDb db) 
        {
            _db= db;
        }

        public  async Task<IEnumerable<Central>> getAll()
        {
            return await _db.Centrals.Include("Governarate").ToListAsync();
        }

        public async Task<Central> getById(int id)
        {
            Central central = await _db.Centrals.Include("Governarate").FirstOrDefaultAsync(ele => ele.Id == id);
            return central;
        }

        public async Task addItem(Central item)
        {
            await _db.Centrals.AddAsync(item);
        }

        public async Task updateItem(Central item)
        {
            Central central = await _db.Centrals.FirstOrDefaultAsync(ele => ele.Id ==item.Id);
            if (central != null)
            {
                central.Id = item.Id;
                central.Name = item.Name;
                central.GovernarateId = item.GovernarateId;
            }
        }

        public async Task removeItem(int id)
        {
            Central central = await _db.Centrals.FirstOrDefaultAsync(ele => ele.Id == id);
            if(central != null)
                _db.Centrals.Remove(central);
        }

        public async Task saveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
