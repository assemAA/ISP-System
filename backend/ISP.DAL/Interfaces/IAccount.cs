using ISP.DAL.Helper;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Interfaces
{
    public interface IAccount
    {
        public Task<Token> Login (string username, string password , string key);
        public Task<IEnumerable<User>> getMangers();
        public Task<bool> RegisterUser(RegisterForm newUser);

        public Task<Pagination< IEnumerable<User>>> getUsers(int pageSize, int pageNumber);

        public  Task deleteUser(string id);

        public Task editUser(User newUser);
        public  Task<User> getUserById(string id);





    }
}
