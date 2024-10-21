using BooksWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using Microsoft.WindowsAzure.MediaServices.Client;
using Microsoft.AspNetCore.Mvc;
using BooksWebApplication.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BooksWebApplication
{
    public class LogInClass
    {
        public ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public LogInClass(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<object> Authenicate(UserLogMethod userdata)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);



            //List<Claim> clamis = new List<Claim>();
            //clamis.Add(new Claim("name", userdata.username));
            //clamis.Add(new Claim("email", userdata.Email));




            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userdata.Claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            //if (userdata.Type == UserTypes.User)
            //{
            //    if (userdata.Type == UserTypes.Admin)
            //    {
                    
            //    }
            //    else
            //    {
            //        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            //        {
            //            Subject = new ClaimsIdentity(new Claim[]
            //       {
            //        new Claim("name", userdata.username),
            //        new Claim("email", userdata.Email),
            //        new Claim("type", ((int)userdata.Type).ToString(), ClaimValueTypes.Integer),
            //        new Claim("accses", "user"),
            //       }),
            //            Expires = DateTime.UtcNow.AddDays(1),
            //            SigningCredentials = new SigningCredentials(
            //           new SymmetricSecurityKey(tokenKey),
            //           SecurityAlgorithms.HmacSha512Signature)
            //        };
            //        var token = tokenHandler.CreateToken(tokenDescriptor);
            //        return tokenHandler.WriteToken(token);
            //    }
            //}
            //else
            //{
                    
            //}
        }
    }
}
