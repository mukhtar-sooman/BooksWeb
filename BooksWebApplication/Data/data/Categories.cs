using System.Collections.Generic;
using BooksWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksWebApplication.Data
{
    public class Categories
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Books> Books { get; set; }


        public Categories( string name)
        {
            Name = name;
        }
    }
}
