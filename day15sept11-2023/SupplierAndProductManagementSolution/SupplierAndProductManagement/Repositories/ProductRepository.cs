using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.ManageContext;
using SupplierAndProductManagement.Model;

namespace SupplierAndProductManagement.Repositories
{
    public class ProductRepository : IRepository<int , Product>
    {
        #region injection 
        private readonly MContext _context;

        public ProductRepository(MContext context)
        {
            _context = context;
        }
        #endregion

        #region Add
        public Product Add(Product item)
        {
           _context.products.Add(item);
            _context.SaveChanges();
            return item;
        }
        #endregion

        #region Delete
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
        #endregion

        #region Get
        public Product Get(int key)
        {
           var product = _context.products.FirstOrDefault(p=>p.ProductId == key);
            return product;
        }
        #endregion

        #region GetAll
        public List<Product> GetAll()
        {
            return _context.products.ToList();
        }
        #endregion

        #region Update

        public Product Update(Product item)
        {
           _context.Entry<Product>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
        #endregion
    }
}
