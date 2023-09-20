using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.PContext
{
    public class ProductContext  : DbContext
    {
        public ProductContext(DbContextOptions opts) : base(opts){    }

        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "ABC",
                    price = 200,
                     Qty = 100 
                },
                  new Product
                  {
                      Id = 2,
                      Name = "DEF",
                      price = 1000,
                      Qty = 100
                  });

        }


    }
}
