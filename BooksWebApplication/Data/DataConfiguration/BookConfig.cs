using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;

namespace BooksWebApplication.Data
{
    public class BookConfig: IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired(true);


            builder.Property(s => s.NumberOfCopys).HasMaxLength(200).IsRequired(true);


            builder.Property(s => s.CategoriesId).IsRequired(true);
            builder.HasOne(s => s.categories).WithMany(s => s.Books).HasForeignKey(s => s.CategoriesId);


            builder.Property(s => s.AddedByUserId).IsRequired(true);
            builder.HasOne(s => s.Users).WithMany(s => s.Books).HasForeignKey(s => s.AddedByUserId);
        }
    }
}