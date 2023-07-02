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
    public class GovernarateRepo : IGeneralRepo<Governarate>
    {
        private readonly ContextDb _db;
        public GovernarateRepo(ContextDb db)
        {
            _db = db;
        }
        public async Task addItem(Governarate item)
        {
            await _db.Governarates.AddAsync(item);
        }

        public async Task<IEnumerable<Governarate>> getAll()
        {
            IEnumerable<Governarate> governarates = await _db.Governarates.ToListAsync();
            return governarates;
        }

        public async Task<Governarate> getById(int id)
        {
            Governarate governarate = await _db.Governarates.FindAsync(id);
            return governarate;
        }

        public async Task removeItem(int id)
        {
            Governarate governarate = await _db.Governarates.FirstOrDefaultAsync(item => item.Id == id);
            if (governarate != null)
            {
                _db.Governarates.Remove(governarate);
            }
        }

        public async Task saveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task updateItem(Governarate item)
        {
            Governarate governarate = await _db.Governarates.FirstOrDefaultAsync(ele => item.Id == ele.Id);
            if (governarate != null)
            {
                governarate.Code = item.Code;
                governarate.Name = item.Name;
            }
        }
    }
}
