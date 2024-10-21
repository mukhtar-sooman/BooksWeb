using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using BooksWebApplication.Models;

namespace BooksWebApplication.Data
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired(true);
            builder.HasData(
                new { Id = 1, Name = "Math" },
                new { Id = 2, Name = "Sport" },
                new { Id = 3, Name = "Sciences" }
                );
        }
    }
}
