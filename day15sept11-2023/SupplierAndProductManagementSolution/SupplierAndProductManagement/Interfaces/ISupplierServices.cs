using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;

namespace SupplierAndProductManagement.Interfaces
{
    public interface ISupplierServices
    {
        List<Supplier> GetAllSupplier();

       Supplier  AddNewSupplier(Supplier supplier);

        Supplier UpdateSupplierName(UpdateSupplierNameDTO updateSupplierNameDTO);

        Supplier UpdateSupplierEmail(UpdateSupplierEmailDTO updateSupplierEmailDTO);

        Supplier UpdateSupplierPhone(UpdatesupplierPhoneDTO updatedSupplierPhoneDTO);
    }
}
