using Microsoft.EntityFrameworkCore;
using productApp.Models;

namespace productApp.Contexts
{
    public class pContexts : DbContext
    {
        public pContexts(DbContextOptions opts): base(opts)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "ABC", Price = 200, Quantity = 1, },
                 new Product { Id = 2, Name = "DEF", Price = 200, Quantity = 1, }
                 );
        }
    }
}
