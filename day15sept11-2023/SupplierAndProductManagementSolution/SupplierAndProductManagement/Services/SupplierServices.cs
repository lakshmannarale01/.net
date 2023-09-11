using Microsoft.AspNetCore.Mvc;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;

namespace SupplierAndProductManagement.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly IRepository<int, Supplier> _repo;
   

        public SupplierServices( IRepository<int , Supplier> repository )
        {
            _repo= repository;
            
        }

        #region Add
       
        public Supplier AddNewSupplier(Supplier supplier)
        {
            return _repo.Add(supplier);
        }
        #endregion

       


        #region GetAll Supplier

        public List<Supplier> GetAllSupplier()
        {
            return _repo.GetAll();
        }
        #endregion

        #region Update Email
        public Supplier UpdateSupplierEmail(UpdateSupplierEmailDTO updateSupplierEmailDTO)
        {
            var emp = _repo.Get(updateSupplierEmailDTO.Id);
            if (emp != null)
            {
                emp.Email = updateSupplierEmailDTO.Email;
                return _repo.Update(emp);
            }
            return null;

        }
        #endregion

        #region Update Name
        public Supplier UpdateSupplierName(UpdateSupplierNameDTO updateSupplierNameDTO)
        {
            var emp = _repo.Get(updateSupplierNameDTO.Id);
            if (emp != null)
            {
                emp.Name = updateSupplierNameDTO.Name;
                return _repo.Update(emp);
            }
            return null;
        }
        #endregion

        #region Update Phone
        public Supplier UpdateSupplierPhone(UpdatesupplierPhoneDTO updatedSupplierPhoneDTO)
        {
            var emp = _repo.Get(updatedSupplierPhoneDTO.Id);
            if (emp != null)
            {
                emp.Phone = updatedSupplierPhoneDTO.Phone;
                return _repo.Update(emp);
            }
            return null;
        }
        #endregion
    }
}
