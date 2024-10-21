using BooksWebApplication.Data;
using BooksWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BooksWebApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {

        }
        //public DbSet<Books> Books { get; set; }
        //public DbSet<Books_Customers> Books_Customers { get; set; }
        //public DbSet<BooksLog> BooksLog { get; set; }
        //public DbSet<Categories> Categories { get; set; }
        //public DbSet<Customers> Customers { get; set; }
        //public DbSet<Users> Users { get; set; }
        //public DbSet<UsersLog> UsersLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.HasDefaultSchema(schema);

            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BooksLogConfiguration());
            modelBuilder.ApplyConfiguration(new Books_Customers_Configuration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UsersLogConfiguration());



        }
    }
}
