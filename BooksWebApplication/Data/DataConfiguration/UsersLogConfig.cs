using BooksWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksWebApplication.Data
{
    public class UsersLogConfiguration : IEntityTypeConfiguration<UsersLog>
    {
        public void Configure(EntityTypeBuilder<UsersLog> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired(true);


            builder.Property(s => s.Action).HasMaxLength(300).IsRequired(false);


            builder.Property(s => s.Description).IsRequired(false);


            builder.Property(s => s.UserId).IsRequired(true);
            builder.HasOne(s => s.Users).WithMany(s => s.Userslog).HasForeignKey(s => s.UserId);

        } 
    }
}