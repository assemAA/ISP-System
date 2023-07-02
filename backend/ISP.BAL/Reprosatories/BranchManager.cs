using AutoMapper;
using ISP.BAL.DTOS.BranchesDtos;
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
    public class BranchManager : IBranchManager
    {
        private readonly IGeneralRepo<Branch> _branchRepo;
        private readonly IMapper _mapper;
        public BranchManager(IGeneralRepo<Branch> branchRepo , IMapper mapper)
        {
            _branchRepo = branchRepo;
            _mapper= mapper;
        }
        public async Task addBranch(EditAddBranchDto branch)
        {
            Branch newBranch =  _mapper.Map<Branch>(branch);
            await _branchRepo.addItem(newBranch);
        }

        public async Task deleteBranch(int id)
        {
           
            var client = await _branchRepo.getById(id);
            if (client != null)
            {
                await _branchRepo.removeItem(id);
                await _branchRepo.saveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public async Task<ViewBranchDto> getBranchById(int id)
        {
            Branch branch = await _branchRepo.getById(id);
            ViewBranchDto viewBranch = _mapper.Map<ViewBranchDto>(branch);
            return viewBranch;
        }

        public async Task<IEnumerable<ViewBranchDto>> getBranches()
        {
            IEnumerable<Branch> branches = await _branchRepo.getAll();
            IEnumerable<ViewBranchDto> branchesView = _mapper.Map<IEnumerable<ViewBranchDto>>(branches);
            return branchesView;
        }

        public async Task saveChanges()
        {
            await _branchRepo.saveChanges();
        }

        public async Task updateBranch(EditAddBranchDto branch)
        {
            Branch updatedBranch = _mapper.Map<Branch>(branch);
            await _branchRepo.updateItem(updatedBranch);
        }
    }
}
