using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BooksWebApplication.Res.Admin
{
    [Route("api/res/admin/[action]")]
    [ApiController]
    public class Log_In : ControllerBase
    {
        public ApplicationContext _context;
        public  LogInClass _logInClass;

        public Log_In(ApplicationContext context, LogInClass logInClass)
        {
            _context = context;
            _logInClass = logInClass;
        }

        [HttpGet("{id}")]
        public async Task<object> CheckUser(int userId)
        {
            var x = await _context.Set<UsersLog>()
                .Include(s => s.Users)
                .Where(s => s.UserId == userId)
                .Select(s => new UserLogModel
                {
                    Id = s.UserId,
                })
                .FirstOrDefaultAsync();
            return x;
        }

        [HttpPost]
        public async Task<IActionResult> test123([FromBody] UserLogIModel userLogIModel)
        {
            var s = await _context.Set<Users>()
                .Where(b => b.Email.ToLower() == userLogIModel.Email.ToLower() && b.Password.ToLower() == userLogIModel.Password.ToLower())
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            List<Claim> clamis = new List<Claim>();
            clamis.Add(new Claim("name", s.UserName));
            clamis.Add(new Claim("email", s.Email));
            clamis.Add(new Claim("type", ((int)s.Type).ToString(), ClaimValueTypes.Integer));
            clamis.Add(new Claim("accses", s.Type == UserTypes.Admin ? "Admin" : "user"));

            var x = new UserLogMethod { Claims = clamis };

            var token = await _logInClass.Authenicate(x);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
