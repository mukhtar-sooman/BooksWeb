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
    public class Renting : ControllerBase
    {
        private ApplicationContext _context;

        public Renting(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<object> RentingBooks(int bookid)
        {
            var x = await _context.Set<Books_Customers>()
                .Include(s => s.Customer)
                .Include(s => s.Books)
                .Where(s => s.BookId == bookid)
                .Select(s => new Books_CustomersModel
                {
                    Id = s.BookId,
                    Customers = new CustomerModel { Id = s.Customer.Id, Email = s.Customer.Email, Name = s.Customer.Name }
                })
                .FirstOrDefaultAsync();


            return x;
        }
    }
}
