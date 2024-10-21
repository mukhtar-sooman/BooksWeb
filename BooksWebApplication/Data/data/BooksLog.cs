using System;

namespace BooksWebApplication.Data
{
    public class BooksLog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public string Action { get; private set; }
        public string Description { get; private set; }
        public string States { get; private set; }

        public int BookId { get; private set; }
        public Books Books { get; set; }


        public BooksLog(string name, DateTime time, string action, string description, string states, int bookId)
        {
            Name = name;
            Time = time;
            Action = action;
            Description = description;
            States = states;
            BookId = bookId;
        }
    }
}
