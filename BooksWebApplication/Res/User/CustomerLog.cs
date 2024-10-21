using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.User
{
    [Route("api/res/user/[action]")]
    [ApiController]
    public class CustomerLog : ControllerBase
    {
        private ApplicationContext _context;

        public CustomerLog(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<object> CheckCustomer(string name)
        {
            var x = await _context.Set<Customers>().Where(s => s.Name == name).Select(s => new CustomerModel
            {
                Id = s.Id,
                Name = s.Name,
                Email= s.Email
            }).ToListAsync();
            if (x == null)
            {
                return "Not Found";
            }
            return x;
        }



    }
}
