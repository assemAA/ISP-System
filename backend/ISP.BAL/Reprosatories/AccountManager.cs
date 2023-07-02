using AutoMapper;
using ISP.BAL.DTOS.BranchesDtos;
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
    public class AccountManager : IAccountManager
    {
        private readonly IAccount _accountRepo;
        private readonly IMapper _mapper;
        public AccountManager(IAccount accountRepo , IMapper mapper) {
            this._accountRepo = accountRepo;
            this._mapper = mapper;
        }

        public async Task<Token> Login(string username, string password, string key)
        {
            Token token =await _accountRepo.Login(username, password, key);
            return token;
        }
        public async Task<ViewUserDto> getUserById(string id)
        {
            User user = await _accountRepo.getUserById(id);
            ViewUserDto viewUser = _mapper.Map<ViewUserDto>(user);
            return viewUser;
        }
        public async Task<IEnumerable<ViewManagersDtos>> getMangers ()
        {
            IEnumerable<User> mangers = await _accountRepo.getMangers();
            IEnumerable<ViewManagersDtos> viewManagers = _mapper.Map<IEnumerable<ViewManagersDtos>>(mangers);
            return viewManagers;
        }

        public async Task<bool> registerUser(RegisterDto newUser)
        {
            RegisterForm registerForm = _mapper.Map<RegisterForm>(newUser);
            return await _accountRepo.RegisterUser(registerForm);
        }

        public async Task<Pagination< IEnumerable<ViewUserDto>>> getUsers(int pageSize, int pageNumber)
        {
           Pagination<  IEnumerable<User>> users = await _accountRepo.getUsers(pageSize, pageNumber);
            IEnumerable<ViewUserDto> viewUsers = _mapper.Map<IEnumerable<ViewUserDto>>(users.Data);
            return new Pagination<IEnumerable<ViewUserDto>> {Data=viewUsers , CurrentPages= users.CurrentPages , TotalPages=users.TotalPages };
        }

        public async Task editUser(EditUserDto user)
        {
            User userToUpdate = new User()
            {
                Id = user.Id,
                UserName = user.userName,
                Salary = user.Salary,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                branchId = user.branch,
                GroupId = user.group,
                status = user.status,
            };
           await _accountRepo.editUser(userToUpdate);
        }

        public async Task deleteUser(string id)
        {
            await _accountRepo.deleteUser(id);
        }
    }
}
