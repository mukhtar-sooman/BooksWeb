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
    public class RentBook : ControllerBase
    {
        private ApplicationContext _context;

        public RentBook(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("")]
        public async Task<object> Rent([FromBody] RentBookRequest request)
        {
            var book = await _context.Set<Books>().FirstOrDefaultAsync(s => s.Id == request.BookId);
            if (book == null)
                throw new System.Exception("book not found");

            var customer = await _context.Set<Customers>().FirstOrDefaultAsync(s => s.Id == request.CustomerId);
            if (customer == null)
                throw new System.Exception("coustomer not found");


            var newRent = new Books_Customers(customer.Name, customer.Id, book.Name, book.Id, DateTime.UtcNow, request.ReturnDate);

            _context.Add(newRent);

            if (book.NumberOfCopys == 0)
                throw new System.Exception("no available compys to rint");

            book.UpdateNumberOfCopys();

            var newBooksLog = new BooksLog("rent a abook", DateTime.UtcNow, "rent", "", "Good",book.Id);
            _context.Add(newBooksLog);


            await _context.SaveChangesAsync();
            return newRent.Id;

        }

    }
}
