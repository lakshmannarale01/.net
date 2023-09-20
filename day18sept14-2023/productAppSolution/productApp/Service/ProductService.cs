using productApp.Interfaces;
using productApp.Models;
using productApp.Models.DTOs;

namespace productApp.Service
{
    public class ProductService : IProductServices
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

        public List<Product> GetInPriceRange(float min, float max)
        {
           var products =_repo.GetAll().Where(e=> e.Price>= min && e.Price<=max);
            if(products.Count()>0)
            {
                return products.ToList();
            }
            return null;
        }

        public List<Product> GetAllproduct()
        {
            return _repo.GetAll();
        }

        public Product Updateprice(ProductPriceDTO product)
        {
            var myProduct=_repo.Get(product.Id);
            if(myProduct != null)
            {
                myProduct.Price = product.Price;
                return _repo.Update(myProduct);
            }
            return null;
        }

        public Product UpdateQuantity(ProductQuantity product)
        {
            var myProduct =_repo.Get(product.Id);
            if (myProduct!=null)
                {
                myProduct.Quantity = product.Quantity;
                return _repo.Update(myProduct);
              }return null;
            {
                
            }
        }
    }
}
