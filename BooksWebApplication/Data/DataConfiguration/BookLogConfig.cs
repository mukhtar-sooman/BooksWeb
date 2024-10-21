using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApplication.Data
{
    public class BooksLogConfiguration : IEntityTypeConfiguration<BooksLog>
    {
        public void Configure(EntityTypeBuilder<BooksLog> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired(true);
           

            builder.Property(s => s.Action).HasMaxLength(300).IsRequired(false);


            builder.Property(s => s.Description).IsRequired(false);


            builder.Property(s => s.States).IsRequired(false);


            builder.Property(s => s.BookId).IsRequired(true);
            builder.HasOne(s => s.Books).WithMany(s => s.Bookslog).HasForeignKey(s => s.BookId);
        }
    }
}
