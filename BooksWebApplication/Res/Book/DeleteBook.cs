using BooksWebApplication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.Book
{
    [Route("api/res/Book/[action]")]
    [ApiController]
    //[Authorize]
    public class DeleteBook : ControllerBase
    {
        private ApplicationContext _context;

        public DeleteBook(ApplicationContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<object> RemoveBook([FromRoute] int id)
        {
            var x = await _context.Set<Books>().Where(s => s.Id == id).FirstOrDefaultAsync();
            if (x != null)
            {
                _context.Remove(x);
            }
            else 
            {
                return "Not Found";
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
