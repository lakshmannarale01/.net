using ProductApp.Interfaces;
using ProductApp.Models;

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

        public List<Product> GetAllProducts()
        {
           return _repo.GetAll();
        }
    }
}
