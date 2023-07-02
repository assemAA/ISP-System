using ISP.BAL.DTOS.ClientDTOs;
using ISP.DAL.Helper;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IClientManager
    {
        public Task<IEnumerable<ViewClientDto>> getClients();
        public Task<Pagination<IEnumerable<ViewClientDto>>> getAllPages(int pageSize, int pageNumbe);


        public Task<Client> getClientById(int id);
        public Task<Client> GetClientByNumber(string num);

        public Task addClient(AddEditClientDto newClient);

        public Task removeClient(int id);

        public Task updateClient(AddEditClientDto newClient);

        public Task saveChanges();
    }
}
