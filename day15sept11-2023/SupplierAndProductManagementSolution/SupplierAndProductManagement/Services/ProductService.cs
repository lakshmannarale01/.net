using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;

namespace SupplierAndProductManagement.Services
{
    public class ProductService :IProductService
    {
        private readonly IRepository<int, Product> _repo;

        public ProductService(IRepository<int , Product> repository)
        {
            _repo=repository;
        }

        public Product AddNewProduct(Product product)
        {
           return _repo.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public Product UpdateProductDescription(UpdateProductDescriptionDTO product)
        {
           var pro = _repo.Get(product.Id);
            if(pro != null)
            {
                pro.Description = product.Description;
                return _repo.Update(pro);
            }
            return null;
        }

        public Product UpdateProductName(UpdateProductNameDTO product)
        {
            var pro = _repo.Get(product.Id);
            if (pro != null)
            {
                pro.Name = product.Name;
                return _repo.Update(pro);
            }
            return null;
        }

        public Product UpdateProductPrice(UpdateProductPriceDTO product)
        {
            var pro = _repo.Get(product.Id);
            if (pro != null)
            {
                pro.Price = product.Price;
                return _repo.Update(pro);
            }
            return null;
        }
    }
}
