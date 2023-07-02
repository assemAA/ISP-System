using AutoMapper;
using ISP.BAL.DTOS.CentralsDtos;
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
    public class CentralManager : ICentralManager
    {
        private readonly IMapper _mapper;
        private readonly IGeneralRepo<Central> _centralRepo;
        public CentralManager(IGeneralRepo<Central> centralRepo , IMapper mapper) 
        {
            _centralRepo = centralRepo;
            _mapper = mapper;
        }
        public async Task addCentral(AddEditCentralDto central)
        {
            Central newCentral = _mapper.Map<Central>(central);
            await _centralRepo.addItem(newCentral);
        }

        public async Task<ViewCentralDto> getCentralById(int id)
        {
            Central central = await _centralRepo.getById(id);
            ViewCentralDto viewedCentral = _mapper.Map<ViewCentralDto>(central);
            return viewedCentral;
        }

        public async Task<IEnumerable<ViewCentralDto>> getCentrals()
        {
            IEnumerable<Central> centrals = await _centralRepo.getAll();
            IEnumerable<ViewCentralDto> viewedCentrals = _mapper.Map<IEnumerable<ViewCentralDto>>(centrals);
            return viewedCentrals;
        }

        public async Task removeCentral(int id)
        {
            await _centralRepo.removeItem(id);
        }

        public async Task saveChanges()
        {
            await _centralRepo.saveChanges();   
        }

        public async Task updateCentral(AddEditCentralDto central)
        {
            Central updatedCentral = _mapper.Map<Central>(central);
            await _centralRepo.updateItem(updatedCentral);
        }
    }
}
