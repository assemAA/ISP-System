using ISP.BAL.DTOS.BranchesDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IBranchManager
    {
        public Task<IEnumerable<ViewBranchDto>> getBranches();

        public Task<ViewBranchDto> getBranchById(int id);

        public Task addBranch(EditAddBranchDto branch);

        public Task deleteBranch(int id);

        public Task updateBranch(EditAddBranchDto branch);

        public Task saveChanges();
    }
}
