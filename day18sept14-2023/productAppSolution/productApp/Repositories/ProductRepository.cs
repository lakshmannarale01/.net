using productApp.Contexts;
using productApp.Interfaces;
using productApp.Models;

namespace productApp.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly pContexts _context;

        public ProductRepository(pContexts contexts)
        {
            _context = contexts;
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
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public Product Get(int key)
        {
            var product = _context.products.FirstOrDefault(x => x.Id == key);
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
