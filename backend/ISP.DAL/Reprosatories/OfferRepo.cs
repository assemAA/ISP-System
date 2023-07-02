using ISP.DAL.Context;
using ISP.DAL.Interfaces;
using ISP.DAL.Migrations;
using ISP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISP.DAL.Reprosatories
{
    public class OfferRepo : IGeneralRepo<Offer>, IOfferRepo
    {
        private readonly ContextDb _db;

        public OfferRepo( ContextDb db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Offer>> getAll()
        {
            return await _db.Offers.Include("Branches").ToListAsync();


        }
        public async Task<Offer> getById(int id)
        {

            Offer offer = await _db.Offers.Include("Branches").FirstOrDefaultAsync(O => O.Id == id);
            return offer;
        }
        public async Task addItem(Offer item)
        {
            
            await _db.Offers.AddAsync(item);
           

        }
        public async Task addBranchOffer(int offerid, List<int> BranchesId)
        {

            try
            {
                foreach (var item in BranchesId)
                {
                    await _db.BranchOffer.AddAsync(new BranchOffer { BranchesId = item, OffersId = offerid });
                }
               // await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        public async Task removeItem(int id)
            
        {
            Offer offer =await _db.Offers.FindAsync(id);
            if (offer != null)
            {
                _db.Offers.Remove(offer);
            }
        }
        public async Task removeBranchOffer(int offerid)
        {
            List<BranchOffer> branchOffers = await _db.BranchOffer.Where(BO => BO.OffersId == offerid).ToListAsync();
            if (branchOffers != null)
            {
                foreach (BranchOffer branchOffer in branchOffers)
                {
                    _db.BranchOffer.Remove(branchOffer);

                }
            }
        }


        public async Task updateItem(Offer item)
        {
            Offer offer = await _db.Offers.FindAsync(item);
            if (offer != null)
            {
                _db.Offers.Update(offer);
            }
        }

        public async Task UpdateBranchOffer(int offerid, List<int> BranchesId)
        {
            throw new NotImplementedException();
        }

        public async Task saveChanges()
        {
            await _db.SaveChangesAsync();
        }

    }
}
