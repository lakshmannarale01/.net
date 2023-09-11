using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;

namespace SupplierAndProductManagement.Interfaces
{
    public interface IProductService
    {
        Product AddNewProduct(Product product);
        List<Product> GetAllProducts();

        Product UpdateProductDescription(UpdateProductDescriptionDTO product);

        Product UpdateProductName(UpdateProductNameDTO product);

        Product UpdateProductPrice(UpdateProductPriceDTO product);



    }
}
