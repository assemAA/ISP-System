using ISP.DAL.Context;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Reprosatories
{
    public class BranchRepo : IGeneralRepo<Branch>
    {
        private readonly ContextDb _db;
        public BranchRepo(ContextDb db) 
        {
            _db = db;
        }
        public async Task addItem(Branch item)
        {
           await _db.Branches.AddAsync(item);
        }

        public async Task<IEnumerable<Branch>> getAll()
        {
            IEnumerable<Branch> branches = await _db.Branches
                                                 .Include("Magnager")
                                                 .Include("governarate")
                                                 .ToListAsync();
            return branches;
        }

        public async Task<Branch> getById(int id)
        {
            Branch branch = await _db.Branches
                                    .Include("Magnager")
                                     .Include("governarate")
                                    .FirstOrDefaultAsync(ele => ele.Id == id);
            return branch;
        }

        public async Task removeItem(int id)
        {
            Branch branch = await _db.Branches.FindAsync(id);
            if(branch != null)
            {
                 _db.Branches.Remove(branch);
            }
        }

        public async Task saveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task updateItem(Branch item)
        {
            Branch branch = await _db.Branches.FirstOrDefaultAsync(ele => ele.Id == item.Id);
            if (branch != null)
            {
                branch.Id = item.Id;
                branch.Name = item.Name;
                branch.GovernarateId = item.GovernarateId;
                branch.PhoneNumberOne = item.PhoneNumberOne;
                branch.PhoneNumberTwo = item.PhoneNumberTwo;
                branch.MobileNumberOne = item.MobileNumberOne;
                branch.MobileNumberTwo = item.MobileNumberTwo;
                branch.Fax = item.Fax;
                branch.ManagerId = item.ManagerId;
            }
        }
    }
}
