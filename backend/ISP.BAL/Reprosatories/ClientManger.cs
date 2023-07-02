using AutoMapper;
using ISP.BAL.DTOS.ClientDTOs;
using ISP.BAL.DTOS.UsersDtos;
using ISP.BAL.Interfaces;
using ISP.DAL.Helper;
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
    public class ClientManger : IClientManager
    {
        // private readonly IGeneralRepo<Client> clientRepo;
         private readonly IClientRepo clientRepo;

        // private readonly ClientRepo ClientNum;


        private readonly IMapper mapper;
        private readonly IOfferRepo offerRepo;


        public ClientManger(IClientRepo clientRepo, IMapper mapper , IOfferRepo offerRepo )
        {
            this.clientRepo = clientRepo;
            this.mapper = mapper;
            //this.ClientNum = ClientNum;
            this.offerRepo= offerRepo;
        }

        public async Task addClient(AddEditClientDto newClient)
        {
            Client client = new Client()
            {
                Id= newClient.Id,
                Name= newClient.Name,
                SSN = newClient.SSN,
                Phone = newClient.Phone,
                GovernarateCode = newClient.GovernarateCode,
                Address = newClient.Address,
                Email = newClient.Email,
                ProviderId = newClient.ProviderId,
                BundleId = newClient.BundleId,
                CentralId = newClient.CentralId,
                IpPackage = newClient.IpPackage,
                Contractdate= newClient.Contractdate,
                Mobile1 = newClient.Mobile1,
                Mobile2= newClient.Mobile2,
                LineOwner= newClient.LineOwner,
                Note = newClient.Note,
                BranchId = newClient.BranchId,
                RouterSerial= newClient.RouterSerial,
                OrderNumber= newClient.OrderNumber,
                PortSlot= newClient.PortSlot,
                PortBlock    = newClient.PortBlock,
                UserName= newClient.UserName,
                Password= newClient.Password,
                VPI= newClient.VPI,
                VCI= newClient.VCI,
                OrderWorkNumber= newClient.OrderWorkNumber,
                PrePaid= newClient.PrePaid,
                InstallationFee= newClient.InstallationFee,
                ContractFee= newClient.ContractFee,
                SlotNum= newClient.SlotNum,
                BlockNum= newClient.BlockNum,
            };

            List<Offer> offers= new List<Offer>();
            foreach (var ele in newClient.offers)
            {
                Offer offer = await offerRepo.getById(ele);
                offers.Add(offer);
            }
            client.offers = offers;
            await clientRepo.addItem(client);
            await clientRepo.saveChanges();
        }

        public async Task<Pagination<IEnumerable<ViewClientDto>>> getAllPages(int pageSize, int pageNumbe)
        {
           Pagination< IEnumerable<Client>> clientsPages = await clientRepo.getAllPages(pageSize,pageNumbe);
            IEnumerable<ViewClientDto> viewClients = mapper.Map<IEnumerable<ViewClientDto>>(clientsPages.Data);
            return new Pagination<IEnumerable<ViewClientDto>> { Data=viewClients,TotalPages= clientsPages.TotalPages,CurrentPages=clientsPages.CurrentPages};
        }

        public async Task<Client> getClientById(int id)
        {
            var client = await clientRepo.getById(id);
            return client;
        }

        public async Task<Client> GetClientByNumber(string num)
        {
           var client= await  clientRepo.GetByNumber(num);
            return client;

        }

        public async Task<IEnumerable<ViewClientDto>> getClients()
        {
            var lstClients = await clientRepo.getAll();
            var viewlstclient = mapper.Map<IEnumerable<ViewClientDto>>(lstClients);
            return viewlstclient;
        }

        public async Task removeClient(int id)
        {
            Client client = await clientRepo.getById(id);
            if (client != null)
            {
                await clientRepo.removeItem(id);
                await clientRepo.saveChanges();
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public async Task saveChanges()
        {
            await clientRepo.saveChanges();
        }

        public async Task updateClient(AddEditClientDto newClient)
        {
            Client updatedClient = mapper.Map<Client>(newClient);
            await clientRepo.updateItem(updatedClient);
        }
    }
}
