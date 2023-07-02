using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Interfaces
{
    public interface IOfferRepo
    {
        public Task addBranchOffer(int offerid, List<int> BranchesId);
        public Task UpdateBranchOffer(int offerid, List<int> BranchesId);
        public Task removeBranchOffer(int offerid);

        public  Task<Offer> getById(int id);

    }
}
