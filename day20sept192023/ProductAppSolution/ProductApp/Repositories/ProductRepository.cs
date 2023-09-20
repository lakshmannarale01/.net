using ProductApp.Interfaces;
using ProductApp.Models;
using ProductApp.PContext;

namespace ProductApp.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public Product Add(Product item)
        {
           _context.products.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Product Delete(int key)
        {
            var product = Get(key);
            if(product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public Product Get(int key)
        {
           var product = _context.products.FirstOrDefault(p=>p.Id == key);
            return product;
        }

        public List<Product> GetAll()
        {
            return _context.products.ToList();
        }

        public Product Update(Product item)
        {
           _context.Entry<Product>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
