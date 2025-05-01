using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SimpleInventoryManagementSystem.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("InventoryDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Product1", Category = "Category1", Quantity = 100, Price = 10.0m, ReorderLevel = 10 },
                new Product { ProductID = 2, Name = "Product2", Category = "Category2", Quantity = 200, Price = 20.0m, ReorderLevel = 20 }
            );
        }
    }
}
