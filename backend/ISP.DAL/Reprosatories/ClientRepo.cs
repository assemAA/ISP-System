using ISP.DAL.Context;
using ISP.DAL.Helper;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Reprosatories
{
    public class ClientRepo:IGeneralRepo<Client>, IClientRepo
    {
        private readonly ContextDb context;
        public ClientRepo(ContextDb context)
        {
            this.context = context;
        }
       public async Task addItem(Client item)
        {
            List<ClientTakeOffer> clientTakeOffers= new List<ClientTakeOffer>();
            foreach(var ele in item.offers)
            {
                ClientTakeOffer clientTakeOffer = new ClientTakeOffer()
                {
                    offer= ele ,
                    offerId = ele.Id,
                    startDate = DateTime.Now,
                    endDate = DateTime.Now.AddMonths(ele.AmountOfOfferMonths),
                };
                clientTakeOffers.Add(clientTakeOffer);
            }

            Governarate governorate = await context.Governarates.FirstOrDefaultAsync(gov => gov.Id == item.GovernarateCode);
            string governorateCode = governorate.Code.ToString();
            item.Phone = governorateCode + item.Phone;                                 

            item.client_offer= clientTakeOffers;
            await context.Clients.AddAsync(item);
        }

        public async Task<IEnumerable<Client>> getAll()
        {
            return await context.Clients.Include("Provider")
                                        .Include("Bundle")
                                        .Include("Governarate")
                                        .Include("Central")
                                        .Include("Branch")
                                        .AsNoTracking()
                                        .ToListAsync();
        }
        public async Task<Pagination< IEnumerable<Client>>> getAllPages(int pageSize, int pageNumbe)
        {
            IEnumerable < Client > clients= await context.Clients.Include("Provider")
                                        .Include("Bundle")
                                        .Include("Governarate")
                                        .Include("Central")
                                        .Include("Branch")
                                        .Skip((pageNumbe - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return new Pagination<IEnumerable<Client>> { Data = clients, CurrentPages = pageNumbe, TotalPages = await context.Clients.CountAsync() };
        }
        public async Task<Client> getById(int id)
        {
            return await context.Clients.Include("Provider")
                                        .Include("Bundle")
                                        .Include("Governarate")
                                        .Include("Central")
                                        .Include("Branch")
                                        .Include(ele => ele.offers)
                                        .Include(ele => ele.client_offer)
                                        .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Client> GetByNumber(string num)
        {
            return await context.Clients.AsNoTracking().Include("Provider")
                                        .Include("Bundle")
                                        .Include("Governarate")
                                        .Include("Central")
                                        .Include("Branch")
                                        .Include(ele => ele.offers)
                                        .Include(ele => ele.client_offer)
                                        .Include(ele => ele.bills)
                                        .FirstOrDefaultAsync(c => c.Phone == num);
        }



        public async Task removeItem(int id)
        {
            Client client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client != null) context.Clients.Remove(client);
        }

        public async Task saveChanges()
        {
            await context.SaveChangesAsync();

        }

        public async Task updateItem(Client item)
        {
            Client client = await context.Clients.FirstOrDefaultAsync(c => c.Id == item.Id);

            Governarate governorate = await context.Governarates.FirstOrDefaultAsync(gov => gov.Id == item.GovernarateCode);
            string governorateCode = governorate.Code.ToString();
            item.Phone = governorateCode + item.Phone;

            if (client != null)
            {
                client.Id = item.Id;
                client.Name = item.Name;
                client.Address = item.Address;
                client.Phone = item.Phone;
                client.SSN = item.SSN;
                client.UserName = item.UserName;
                client.Password = item.Password;
                client.Email = item.Email;
                client.Mobile1 = item.Mobile1;
                client.Mobile2 = item.Mobile2;
                client.IpPackage = item.IpPackage;
                client.PrePaid = item.PrePaid;
                client.BlockNum = item.BlockNum;
                client.OrderNumber = item.OrderNumber;
                client.OrderWorkNumber = item.OrderWorkNumber;
                client.BranchId = item.BranchId;
                client.ProviderId = item.ProviderId;
                client.CentralId = item.CentralId;
                client.GovernarateCode = item.GovernarateCode;
                client.BundleId = item.BundleId;
                client.Contractdate = item.Contractdate;
                client.ContractFee = item.ContractFee;
                client.SlotNum = item.SlotNum;
                client.ContractFee = item.ContractFee;
                client.InstallationFee = item.InstallationFee;
                client.LineOwner = item.LineOwner;
                client.PortSlot = item.PortSlot;
                client.PortBlock = item.PortBlock;
                client.VCI = item.VCI;
                client.VPI = item.VPI;
                client.Note = item.Note;
                client.Orderworkdate = item.Orderworkdate;
                client.RouterSerial = item.RouterSerial;
                client.offers = item.offers;
            }

            List<ClientTakeOffer> clientTakeOffers = new List<ClientTakeOffer>();
            foreach (var ele in client.offers)
            {
                ClientTakeOffer clientTakeOffer = new ClientTakeOffer()
                {
                    offer = ele,
                    offerId = ele.Id,
                    startDate = DateTime.Now,
                    endDate = DateTime.Now.AddMonths(ele.AmountOfOfferMonths),
                };
                clientTakeOffers.Add(clientTakeOffer);
            }

            client.client_offer = clientTakeOffers;
        }
    }
}
