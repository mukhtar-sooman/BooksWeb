using BooksWebApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.User
{
    [Route("api/res/user/[action]")]
    [ApiController]
    public class DeleteCustomer : ControllerBase
    {
        private ApplicationContext _context;

        public DeleteCustomer(ApplicationContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer([FromRoute] int id)
        {
            var x = await _context.Set<Customers>().Where(s => s.Id == id).FirstOrDefaultAsync();
            if (x != null)
            {
                _context.Remove(x);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
