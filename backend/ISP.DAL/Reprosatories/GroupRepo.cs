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
    public class GroupRepo : IGeneralRepo<Group>
    {
        private readonly ContextDb _db;
        public GroupRepo(ContextDb contextDb) { 
        
            _db= contextDb;
        }
        public async Task addItem(Group item)
        {
           await _db.Groups.AddAsync(item);
        }

        public async Task<IEnumerable<Group>> getAll()
        {
            IEnumerable<Group> groups = await _db.Groups.AsNoTracking().ToListAsync();
            return groups;
        }

        public async Task<Group> getById(int id)
        {
            Group group = await _db.Groups.AsNoTracking().FirstOrDefaultAsync(ele => ele.Id == id);
            return group;
        }

        public async Task removeItem(int id)
        {
            Group group = await _db.Groups.FirstOrDefaultAsync(ele => ele.Id == id);
            _db.Groups.Remove(group);


        }

        public async Task updateItem(Group item)
        {
            Group group = await _db.Groups.FirstOrDefaultAsync(ele => ele.Id == item.Id);
            
            if (group != null)
            {
                group.Name = item.Name;
                group.IsEmployee = item.IsEmployee;
                group.IsManager = item.IsManager;
                group.ReadWriteClients = item.ReadWriteClients;
                group.IsAdmin= item.IsAdmin;
                group.ReadClients= item.ReadClients;
                group.groupRole = item.groupRole;
            }

        }

        public async Task saveChanges()
        {
           await _db.SaveChangesAsync();
        }
    }
}
