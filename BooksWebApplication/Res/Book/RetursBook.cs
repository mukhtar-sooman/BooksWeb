using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.Book
{
    [Route("api/res/Book/[action]")]
    [ApiController]
    [Authorize]
    public class RetursBook : ControllerBase
    {
        private ApplicationContext _context;

        public RetursBook(ApplicationContext context)
        {
            _context = context;
        }

        [HttpDelete]
        public async Task<object> DeleteRent([FromBody] ReturnBookRequest request)
        {
            var s = await _context.Set<Books_Customers>().Where(s => s.Id == request.Id).FirstOrDefaultAsync();
            if (s == null) {

                var x = await _context.Set<Books_Customers>()
                    .Where(s => s.BookId == request.BookId && s.CustomerId == request.CustomerId)
                    .FirstOrDefaultAsync();
                if (x == null)
                    throw new System.Exception("not found");

                var newBookcopy = await _context.Set<Books>().FirstOrDefaultAsync(s => s.Id == request.BookId);
                if (newBookcopy == null)
                    throw new System.Exception("book not found");
                newBookcopy.AddNumberOfCopys();

                var newBooksLog = new BooksLog("return a abook", DateTime.UtcNow, "return", "", "Good", request.BookId);

                _context.Add(newBooksLog);

                _context.Remove(x);
            }

            _context.Remove(s);

            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
