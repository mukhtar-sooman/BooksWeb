using System.Collections.Generic;
using System.Data.Common;

namespace BooksWebApplication.Data
{
    public class Customers
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ICollection<Books_Customers> Books_Customers { get; set; }


        public Customers(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public void Update(string name, string email)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
            }

        }
    }
}
