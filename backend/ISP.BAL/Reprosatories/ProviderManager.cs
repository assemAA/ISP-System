using AutoMapper;
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
    public class ProviderManager : IProviderManager
    {
        private readonly IGeneralRepo<InternetServiceProvider> _providerRepo;

        public ProviderManager (IGeneralRepo<InternetServiceProvider> providerRepo)
        {
            _providerRepo = providerRepo;
        }

        public async Task addProvider(InternetServiceProvider provider)
        {
            await _providerRepo.addItem(provider);
        }

        public async Task<InternetServiceProvider> getProviderById(int id)
        {
            InternetServiceProvider provider = await _providerRepo.getById(id);
            return provider;

        }

        public async Task<IEnumerable<InternetServiceProvider>> getProviders()
        {
            IEnumerable<InternetServiceProvider> providers = await _providerRepo.getAll();
            return providers;
        }

        public async Task removeProvider(int id)
        {
            //await _providerRepo.removeItem(id);
            var provider = await _providerRepo.getById(id);
            if (provider != null)
            {
                await _providerRepo.removeItem(id);
                await _providerRepo.saveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public Task saveChanges()
        {
            return _providerRepo.saveChanges();
        }

        public async Task updateProvider(InternetServiceProvider provider)
        {
            await _providerRepo.updateItem(provider);
        }
    }
}
