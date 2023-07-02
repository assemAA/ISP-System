using ISP.DAL.Context;
using ISP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Seeds
{
    public class AdminSeed
    {
     
        private UserManager<User> _userManager;
        private readonly ContextDb _db;
        public AdminSeed(UserManager<User> userManager , ContextDb db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<Token> seedAdmin(string userName , string password , string key)
        {
            User admin = new User
            {
                UserName = userName,
                Email = "admin@admin.com" , 
                GroupId = 1,

            };
           IdentityResult result =  await _userManager.CreateAsync(admin, password);

           if (result.Succeeded)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier , admin.Id) ,
                    new Claim(ClaimTypes.Name, admin.UserName),
                    new Claim(ClaimTypes.Role , "Admin")
                };

                await _userManager.AddClaimsAsync(admin, claims);

                string secretKeyString = key;
                byte[] secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

                SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

                DateTime expireDate = DateTime.Now.AddDays(2);
                JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    expires: expireDate,
                    signingCredentials: signingCredentials);


                JwtSecurityTokenHandler tokenHndler = new JwtSecurityTokenHandler();
                String tokenString = tokenHndler.WriteToken(token);


                return new Token(tokenString, expireDate , "Admin");
            }


            return null;
        }
    }
}
