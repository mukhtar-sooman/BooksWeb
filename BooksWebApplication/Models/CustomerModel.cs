using System.Collections.Generic;
using System.Security.Claims;

namespace BooksWebApplication.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }


    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }   
    }

    public class CustomerMethod
    {
        public List<Claim> Claims { get; set; }
    }
}
