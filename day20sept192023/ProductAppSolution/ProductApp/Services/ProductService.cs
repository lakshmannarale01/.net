using ProductApp.Interfaces;
using ProductApp.Models;
using ProductApp.utilities;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _repo;

        public ProductService(IRepository<int , Product> repository)
        {
            _repo=repository;
        }

        public Product AddANewProduct(Product product)
        {
           return _repo.Add(product);
        }

        public Product Delete(int id)
        {
         var product = _repo.Get(id);
            if(product==null)
            {
               throw new NotFoundException("product");
            }
            return _repo.Delete(product.Id);
        }

        public List<Product> GetAllProducts()
        {
           return _repo.GetAll();
        }
    }
}
