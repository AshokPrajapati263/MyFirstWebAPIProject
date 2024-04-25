using Microsoft.EntityFrameworkCore;
using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product>? Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1000.00m, Category = "Electronics" },
                new Product { Id = 2, Name = "Desktop", Price = 2000.00m, Category = "Electronics" },
                new Product { Id = 3, Name = "Mobile", Price = 3000.00m, Category = "Electronics" }
            );
        }
    }
}
