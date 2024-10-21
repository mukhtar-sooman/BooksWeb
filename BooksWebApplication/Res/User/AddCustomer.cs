using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.User
{
    [Route("api/res/user/[action]")]
    [ApiController]
    public class AddCustomer : ControllerBase
    {
        private ApplicationContext _context;

        public AddCustomer(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<object> AddNewCustomer([FromBody] CustomerModel customerModel)
        {
            var name = "ahmad";
            var email = "asb";


            var x = new Customers(name, email);

            _context.Add(x);

            await _context.SaveChangesAsync();
            return x.Id;
        }
    }
}
