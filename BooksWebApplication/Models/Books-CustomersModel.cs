using BooksWebApplication.Data;
using System;
using System.Collections.Generic;

namespace BooksWebApplication.Models
{
    public class Books_CustomersModel
    {
        public int Id { get;  set; }

        public string CustomerName { get;  set; }

        public int CustomerId { get;  set; }
        public CustomerModel Customers { get; set; }
    }

    public class RentBookRequest
    {

        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReturnDate { get; set; }

    }
    public class ReturnBookRequest
    {
        public int? Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDateet { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
