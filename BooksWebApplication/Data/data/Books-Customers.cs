using System;
using System.Collections.Generic;

namespace BooksWebApplication.Data
{
    public class Books_Customers
    {
        public int Id { get; private set; }

        public string CustomerName { get; private set; }

        public int CustomerId { get; private set; }
        public Customers Customer { get; set; }

        public string BookName { get; private set; }

        public int BookId { get; private set; }
        public Books Books { get; set; }

        public DateTime TakeTime { get; private set; }
        public DateTime RefundTime { get; private set; }


        public Books_Customers( string customerName, int customerId, string bookName, int bookId, DateTime takeTime, DateTime refundTime)
        {
            CustomerName = customerName;
            CustomerId = customerId;
            BookName = bookName;
            BookId = bookId;
            TakeTime = takeTime;
            RefundTime = refundTime;
        }
        public Books_Customers(int bookId)
        {
            BookId = bookId;
        }
    }
}
