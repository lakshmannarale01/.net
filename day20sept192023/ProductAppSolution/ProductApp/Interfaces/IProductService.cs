using ProductApp.Models;

namespace ProductApp.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product AddANewProduct(Product product);

        Product Delete(int id);

        
    }
}
