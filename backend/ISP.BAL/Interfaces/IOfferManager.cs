using ISP.BAL.DTOS.BranchesDtos;
using ISP.BAL.DTOS.OfferDtos;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public  interface IOfferManager
    {
        public Task<IEnumerable<OfferDto>> getOffers();
        public Task<OfferDto> getOfferById(int id);
        public Task removeOffer(int id);
        public Task addOffer(AddEditOffer offer);
        public Task updateOffer(AddEditOffer offer);

    }
}
