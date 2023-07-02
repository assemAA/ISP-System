using AutoMapper;
using ISP.BAL.DTOS.BranchesDtos;
using ISP.BAL.DTOS.BundleDTOs;
using ISP.BAL.DTOS.OfferDtos;
using ISP.BAL.DTOS.BranchesDtos;

using ISP.BAL.Interfaces;
using ISP.DAL.Interfaces;
using ISP.DAL.Migrations;
using ISP.DAL.Models;
using ISP.DAL.Reprosatories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Reprosatories
{
    public class OfferManager : IOfferManager
    {
        private readonly IGeneralRepo<Offer> offerRepo;
        private readonly IMapper mapper;
        private readonly IOfferRepo repo;

        public OfferManager(IGeneralRepo<Offer> offerRepo, IMapper mapper,IOfferRepo repo )
        {
            this.offerRepo = offerRepo;
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<IEnumerable<OfferDto>> getOffers()
        {
            IEnumerable<Offer> offers = await offerRepo.getAll();
            IEnumerable<OfferDto> offersView = mapper.Map<IEnumerable<OfferDto>>(offers);          
            return offersView;
        }

        public async Task<OfferDto> getOfferById(int id)
        {
            var offer = await offerRepo.getById(id);
            var viewOfferDtos = mapper.Map<OfferDto>(offer);
            return viewOfferDtos;
        }

        public async Task removeOffer(int id)
        {

            Offer offer= await offerRepo.getById(id);
            if(offer != null)
            {
                await repo.removeBranchOffer(id);
                await offerRepo.saveChanges();
                await offerRepo.removeItem(id);
                await offerRepo.saveChanges();

            }

        }
        public async Task addOffer(AddEditOffer offer)
        {
           
            Offer newoffer = mapper.Map<Offer>(offer);   
           await offerRepo.addItem(newoffer);
            await offerRepo.saveChanges();
            await repo.addBranchOffer(newoffer.Id,offer.BranchesId);
            await offerRepo.saveChanges();

        }

        public async Task updateOffer(AddEditOffer offer)
        {
            Offer Updaredoffer = mapper.Map<Offer>(offer);
            await offerRepo.updateItem(Updaredoffer);
            await offerRepo.saveChanges();
        }
    }  
}
