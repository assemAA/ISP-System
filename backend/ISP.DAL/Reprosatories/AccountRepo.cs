using ISP.DAL.Context;
using ISP.DAL.Helper;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using ISP.DAL.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace ISP.DAL.Reprosatories
{
    public  class AccountRepo : IAccount
    {
        private readonly UserManager<User> _userManager;    
        private readonly AdminSeed _adminSeed;
        private readonly ContextDb _db;
        private readonly IGeneralRepo<Group> _groupRepo;
        public AccountRepo(UserManager<User> userManager , ContextDb db , IGeneralRepo<Group> groupRepo) {
            this._userManager = userManager;
            this._db = db;
            this._adminSeed = new AdminSeed(userManager , _db);
            this._groupRepo = groupRepo;
        }
        public async Task<Token> Login(string username, string password , string key)
        {
            User user = await _userManager.Users
                        .Include(u => u.group)
                        .FirstOrDefaultAsync(usr => usr.UserName == username);
            

            if (user == null)
                if (username == "Admin" && password == "Admin@kk123456")
                   return await this._adminSeed.seedAdmin(username, password , key);
                else
                    return null;



            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, password);

            if (!isAuthenticated) return null;
            

            IList<Claim> claimsList = await _userManager.GetClaimsAsync(user);


            string secretKeyString = key;
            byte[] secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            DateTime expireDate = DateTime.Now.AddDays(2);
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimsList,
                expires: expireDate,
                signingCredentials: signingCredentials);


            JwtSecurityTokenHandler tokenHndler = new JwtSecurityTokenHandler();
            String tokenString = tokenHndler.WriteToken(token);
            string userRole = user.group.groupRole.ToString();
            return new Token(tokenString, expireDate , userRole);


        }

        public async Task<IEnumerable<User>> getMangers()
        {
            IEnumerable<User> managers = await _userManager.Users.Where(emp => emp.GroupId == 1 || emp.GroupId == 2).ToListAsync();
            return managers;
        }

        public async Task<bool> RegisterUser (RegisterForm newUser)
        {
            User user = new User()
            {
                UserName = newUser.username,
                Email = newUser.Email,
                Salary = newUser.salary,
                PhoneNumber = newUser.mobile,
                status = newUser.status,
                GroupId = newUser.group,
                branchId = newUser.branch
            };

            IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                Group group = await _groupRepo.getById(newUser.group);

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id),
                    new Claim(ClaimTypes.Name , user.UserName),
                    new Claim(ClaimTypes.Role , group.groupRole)
                
                };

                await _userManager.AddClaimsAsync(user, claims);
                return true;
            }
            return false;
        }


        public async Task<Pagination<IEnumerable<User>>> getUsers(int pageSize , int pageNumber)
        {
            IEnumerable<User> users = await _userManager.Users
                                                .Include("branch")
                                                .Include("group")
                                                .Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToListAsync();
            return new Pagination<IEnumerable<User>> {Data=users , CurrentPages= pageNumber , TotalPages= await _userManager.Users.CountAsync() };


        }

        public async Task deleteUser (string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.Id == id);
            if (user != null) 
               await _userManager.DeleteAsync(user);

        }
        public async Task<User> getUserById(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.Id == id);
            return user;

        }

        public async Task editUser(User newUser)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.Id == newUser.Id);
            if(user != null)
            {
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;
                user.branchId = newUser.branchId;
                user.GroupId = newUser.GroupId;
                user.Salary = newUser.Salary;
                user.status = newUser.status;   
                user.PhoneNumber= newUser.PhoneNumber;
            }
           await _userManager.UpdateAsync(user);
        }


    }
}
