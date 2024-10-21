using System.Collections.Generic;
using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace BooksWebApplication.Data

{
    public class Users 
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserTypes Type { get; set; }
        public ICollection<Books> Books { get; set; }
        public ICollection<UsersLog> Userslog { get; set; }


        public Users( string userName, string email, string password, UserTypes type)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Type = type;
        }

        public Users(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public void Update(string userName)
        {
            UserName = userName;
        }
    }
}
