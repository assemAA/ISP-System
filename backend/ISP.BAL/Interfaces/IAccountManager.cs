using ISP.BAL.DTOS.UsersDtos;
using ISP.DAL.Helper;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IAccountManager
    {
        public Task<Token> Login(string username, string password, string key);
        public Task<IEnumerable<ViewManagersDtos>> getMangers();

        public Task<bool> registerUser(RegisterDto newUser);

        public Task<Pagination<IEnumerable<ViewUserDto>>> getUsers(int pageSize, int pageNumber);

        public Task editUser(EditUserDto user);

        public Task deleteUser(string id);
        public Task<ViewUserDto> getUserById(string id);
    }
}
