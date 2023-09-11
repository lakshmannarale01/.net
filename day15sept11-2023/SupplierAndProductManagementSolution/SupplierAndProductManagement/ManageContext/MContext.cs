using Microsoft.EntityFrameworkCore;
using SupplierAndProductManagement.Model;

namespace SupplierAndProductManagement.ManageContext
{
    public class MContext : DbContext
    {
        public MContext(DbContextOptions opts) : base(opts) { }
        
        public DbSet<Supplier> suppliers { get; set; }      
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1 , Email="abc@gmail.com", Name= "ABC" , Phone="8856904770"},
                new Supplier { SupplierId = 2, Email = "def@gmail.com", Name = "DEF", Phone = "8856904771" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1 , Name = "LG", Description="fidge" , Price=20000 , SupplierId = 1},
                new Product { ProductId = 2, Name = "LG", Description = "fidge", Price = 20000, SupplierId = 1 }

                );
        }

    }
}
