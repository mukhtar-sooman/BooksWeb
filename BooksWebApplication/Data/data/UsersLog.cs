using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace BooksWebApplication.Data
{
    public class UsersLog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public string Action { get; private set; }
        public string Description { get; private set; }

        public int UserId { get; private set; }
        public Users Users { get; set; }



        public UsersLog(string name, DateTime time, string action, string description, int userId)
        {
            Name = name;
            Time = time;
            Action = action;
            Description = description;
            UserId = userId;
        }
    }
}
