using productApp.Models;
using productApp.Models.DTOs;

namespace productApp.Interfaces
{
    public interface IProductServices
    {
        List<Product> GetAllproduct();
        List<Product> GetInPriceRange(float min, float max);
        Product AddANewProduct(Product product);
        Product Updateprice(ProductPriceDTO product);
        Product UpdateQuantity(ProductQuantity product);
       
    }
}
