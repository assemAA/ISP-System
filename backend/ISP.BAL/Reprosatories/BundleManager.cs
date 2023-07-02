using AutoMapper;
using ISP.BAL.DTOS.BundleDTOs;
using ISP.BAL.Interfaces;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Reprosatories
{
    public class BundleManager : IBundleManger
    {
        private readonly IGeneralRepo<Bundle> bundleRepo;
        private readonly IMapper mapper;


        public BundleManager(IGeneralRepo<Bundle> bundleRepo, IMapper mapper)
        {
            this.bundleRepo = bundleRepo;
            this.mapper = mapper;
        }
        public async Task addBundle(AddBundleDto bundle)
        {
            Bundle newBundle = mapper.Map<Bundle>(bundle);
            await bundleRepo.addItem(newBundle);
        }

        public async Task<ViewBundleDto> getBundleById(int id)
        {
            var bundle = await bundleRepo.getById(id);
            var viewBundDto = mapper.Map<ViewBundleDto>(bundle);
            return viewBundDto;
        }

        public async Task<IEnumerable<ViewBundleDto>> getBundles()
        {
            var lstBundle = await bundleRepo.getAll();
            var viewlstBundle = mapper.Map<IEnumerable<ViewBundleDto>>(lstBundle);
            return viewlstBundle;
        }

        public async Task removeBundle(int id)
        {
            Bundle bundle = await bundleRepo.getById(id);
            if (bundle != null)
            {
                await bundleRepo.removeItem(id);
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public async Task saveChanges()
        {
            await bundleRepo.saveChanges();
        }

        public async Task updateBundle(EditBundleDto newbundle)
        {
            Bundle updatedBundle = mapper.Map<Bundle>(newbundle);
            await bundleRepo.updateItem(updatedBundle);
        }
    }
}
