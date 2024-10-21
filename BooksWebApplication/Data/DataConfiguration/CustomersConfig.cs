using BooksWebApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApplication.Data
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired(true);


            builder.Property(s => s.Email).IsRequired(true);

        }
    }
}