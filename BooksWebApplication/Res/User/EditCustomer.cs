using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace BooksWebApplication.Res.User
{
    [Route("api/res/user/[action]")]
    [ApiController]
    public class EditCustomer : ControllerBase
    {
        private ApplicationContext _context;

        public EditCustomer(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPut("{id}")]
        public async Task<object> UpdateCustomer([FromBody] CustomerModel customerModel, [FromRoute] int id)
        {
            var x = await _context.Set<Customers>().FirstOrDefaultAsync(s => s.Id == id);
            if (x != null)
            {
                x.Update(customerModel.Name, customerModel.Email);

            }
            await _context.SaveChangesAsync();
            return x.Id;


        }
    }
}
