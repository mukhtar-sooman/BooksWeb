using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.User
{
    [Route("api/res/user/[action]")]
    [ApiController]
    public class CustomerLogIn : ControllerBase
    {
        public ApplicationContext _context; 
        public CustomerLogInClass _logInClass;

        public CustomerLogIn(ApplicationContext context, CustomerLogInClass logInClass)
        {
            _context = context;
            _logInClass = logInClass;

        }

        [HttpPost]
        public async Task<IActionResult> CustomerLogInToken([FromBody] CustomerModel customerModel)
        {
            var s = await _context.Set<Customers>()
                .Where(b => b.Name.ToLower() == customerModel.Name.ToLower() && b.Email.ToLower() == customerModel.Email.ToLower())
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            List<Claim> clamis = new List<Claim>();
            clamis.Add(new Claim("name", s.Name));
            clamis.Add(new Claim("email", s.Email));

            var x = new CustomerMethod { Claims = clamis };

            var token = await _logInClass.CustmoerAuthenicate(x);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
