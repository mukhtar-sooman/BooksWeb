using BooksWebApplication.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace BooksWebApplication.Models
{
    public class UserModel 
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
    }

    public class UserLogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public UserModel Users { get; set; }

    }
}
