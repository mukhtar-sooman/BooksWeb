using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.Admin
{
    [Route("api/res/admin/[action]")]
    [ApiController]
    public class DeleteUser : ControllerBase
    {
        private ApplicationContext _context;

        public DeleteUser(ApplicationContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser( [FromRoute] int id)
        {
            var x = await _context.Set<Users>().Where(s => s.Id == id).FirstOrDefaultAsync();
            if (x != null)
            {
                _context.Remove(x);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
