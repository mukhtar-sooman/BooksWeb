using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.Book
{
    [Route("api/res/Book/[action]")]
    [ApiController]
    //[Authorize]
    public class AddBook : ControllerBase
    {
        private ApplicationContext _context;

        public AddBook(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public async Task<object> AddNewBook([FromBody] BookModel BookModel)
        {

            var name = BookModel.Name;
            var numberOfCopys = BookModel.NumberOfCopys;
            var categoriesId = BookModel.CategoriesId;
            var addedByUserId = BookModel.AddedByUserId;

            var x = new Books(name, numberOfCopys, categoriesId , addedByUserId);

            _context.Add(x);

            await _context.SaveChangesAsync();
            return x.Id;
        }
    }
}
