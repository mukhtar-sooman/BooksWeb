using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BooksWebApplication.Res.Admin
{
    [Route("api/res/admin/[action]")]
    [ApiController]
    public class EditUser : ControllerBase
    {
        private ApplicationContext _context;

        public EditUser(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPut("{id}")]
        public async Task<object> UpdateUser([FromBody] UserModel userModel, [FromRoute] int id)
        {
            var x = await _context.Set<Users>().FirstOrDefaultAsync(s => s.Id == id);
            if (x != null)
            {
                x.Update(userModel.UserName);
               
            }
            await _context.SaveChangesAsync();
            return x.Id;


        }
    }
}
