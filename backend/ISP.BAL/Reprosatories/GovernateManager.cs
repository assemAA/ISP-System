using ISP.BAL.Interfaces;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using ISP.DAL.Reprosatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Reprosatories
{
    public class GovernateManager : IGovernateManager
    {
        private readonly IGeneralRepo<Governarate> _governateRepo;

        public GovernateManager(IGeneralRepo<Governarate> generalRepo)
        {
            _governateRepo = generalRepo;
        }
        public async Task addGovernate(Governarate governarate)
        {
           await _governateRepo.addItem(governarate);
        }

        public async Task<Governarate> GetGovernarateById(int id)
        {
            return await _governateRepo.getById(id);
        }

        public async Task<IEnumerable<Governarate>> GetGovernarates()
        {
            return await _governateRepo.getAll();
        }

        public async Task removeGovernate(int id)
        {
            //await _governateRepo.removeItem(id);

            var Gover = await _governateRepo.getById(id);
            if (Gover != null)
            {
                await _governateRepo.removeItem(id);
                await _governateRepo.saveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public async Task saveChanges()
        {
            await _governateRepo.saveChanges();
        }

        public async Task updateGovernate(Governarate governarate)
        {
            await _governateRepo.updateItem(governarate);
            //var gover=await _governateRepo.getById(governarate.Id);
            //if (gover!=null)
            //{
            //    await _governateRepo.updateItem(governarate);
            //    await _governateRepo.saveChanges();
            //} else
            //{
            //    throw new Exception("not found");

            //}
        }
    }
}
