using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksWebApplication.Data
{
    public class Books
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int NumberOfCopys { get; private set; }

        public int CategoriesId { get; private set; }
        public Categories categories { get; set; }

        public int AddedByUserId { get; private set; }
        public Users Users { get; set; }

        public ICollection<BooksLog> Bookslog { get; set; }
        public ICollection<Books_Customers> Books_Customers { get; set; }


        public Books( string name, int numberOfCopys, int categoriesId, int addedByUserId)
        {
            Name = name;
            NumberOfCopys = numberOfCopys;
            CategoriesId = categoriesId;
            AddedByUserId = addedByUserId;
        }
        public Books(int numberOfCopys)
        {
            NumberOfCopys = numberOfCopys;
        }
        public void UpdateNumberOfCopys()
        {
            NumberOfCopys = NumberOfCopys -1;
        }

        public void AddNumberOfCopys()
        {
            NumberOfCopys = NumberOfCopys +1;
        }

        public void Update(string name, int numberOfCopys, int categoriesId, int addedByUserId)
        {
            Name = name;
            NumberOfCopys = numberOfCopys;
            CategoriesId = categoriesId;
            AddedByUserId = addedByUserId; 
        }
    }
}