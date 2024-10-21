using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace BooksWebApplication.Res.Book
{
    [Route("api/res/Book/[action]")]
    [ApiController]
   // [Authorize]
    public class GetBook : ControllerBase
    {
        public ApplicationContext _context;

        public GetBook(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<object> GetAllBooks()
        {
            var x = await _context.Set<Books>().Select(s => new BookModel(){
                Id= s.Id,   
                Name=s.Name,
                NumberOfCopys=s.NumberOfCopys,
                CategoriesId=s.CategoriesId,
                AddedByUserId=s.AddedByUserId,

            }).ToListAsync();

            return x;
        }

        [HttpGet("{id}")]
        public async Task<object> GetoneBook(int id)
        {
            var x = await _context.Set<Books>().Where(s => s.Id == id).Select(s => new BookModel 
            {
                Id = s.Id,
                Name = s.Name,
                NumberOfCopys = s.NumberOfCopys,
                CategoriesId = s.CategoriesId,
                AddedByUserId = s.AddedByUserId,

            }).FirstOrDefaultAsync();
            if (x == null)
            {
                return "Not Found";
            }

            return x;
        }
    }
}
