using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BooksWebApplication.Res.Admin
{
    [Route("api/res/admin/[action]")]
    [ApiController]
    public class AddUser : ControllerBase
    {
        private ApplicationContext _context;

        public AddUser(ApplicationContext context)
        {
            _context = context;
        } 


        [HttpPost]
        [Route("")]
        public async Task<object> AddNewUser([FromBody]UserModel userModel)
        {

            var userName = "yuiyo";
            var email = "yjth";


            var x = new Users(userName, email, "abcd",UserTypes.Admin);

            _context.Add(x);

            await _context.SaveChangesAsync();
           return x.Id;
        }
    }
}
