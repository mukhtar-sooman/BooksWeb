using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApplication.Data
{


    public class Books_Customers_Configuration : IEntityTypeConfiguration<Books_Customers>
    {
        public void Configure(EntityTypeBuilder<Books_Customers> builder)
        {
            builder.Property(s => s.CustomerName).HasMaxLength(300).IsRequired(true);


            builder.Property(s => s.BookName).HasMaxLength(500).IsRequired(true);


            builder.Property(s => s.CustomerId).IsRequired(true);
            builder.HasOne(s => s.Customer).WithMany(s => s.Books_Customers).HasForeignKey(s => s.CustomerId);


            builder.Property(s => s.BookId).IsRequired(true);
            builder.HasOne(s => s.Books).WithMany(s => s.Books_Customers).HasForeignKey(s => s.BookId);
        }
    }

}
