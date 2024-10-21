using System;

namespace BooksWebApplication.Models
{
    public class BookLogModel
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string States { get; set; }
        public int BookId { get; set; }
    }
}
