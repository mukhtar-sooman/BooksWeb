using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BooksWebApplication.Res.Book
{
    [Route("api/res/Book/[action]")]
    [ApiController]
    public class EditBook : ControllerBase
    {
        private ApplicationContext _context;
        public EditBook(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPut("{id}")]
        public async Task<object> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            var x = await _context.Set<Books>().FirstOrDefaultAsync(s => s.Id == id);
            if (x != null)
            {
                x.Update(bookModel.Name, bookModel.NumberOfCopys, bookModel.CategoriesId, bookModel.AddedByUserId);
                
            }
            await _context.SaveChangesAsync();
            return x.Id;


        }
    }
}
