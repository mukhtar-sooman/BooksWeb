using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BooksWebApplication.Models;

namespace BooksWebApplication.Data
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(s => s.UserName).HasMaxLength(100).IsRequired(true);


            builder.Property(s => s.Email).IsRequired(true);


            builder.Property(s => s.Password).HasMaxLength(100).IsRequired(true);


            builder.Property(s => s.Type).HasDefaultValue(UserTypes.defulte).IsRequired(true);


        }
    }
}
