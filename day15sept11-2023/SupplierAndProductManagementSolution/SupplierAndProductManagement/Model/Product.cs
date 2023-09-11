using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierAndProductManagement.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter Product Name ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Product Price ")]
        public float Price { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
    }
}
