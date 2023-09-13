using Microsoft.EntityFrameworkCore.Migrations;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.ManageContext;
using SupplierAndProductManagement.Model;

namespace SupplierAndProductManagement.Repositories
{
    public class SupplierRepository : IRepository<int, Supplier>
    {
        #region injection
        private readonly MContext _context;

        public SupplierRepository(MContext context)
        {
            _context = context;
        }
        #endregion

        #region Add
        public Supplier Add(Supplier item)
        {
           _context.suppliers.Add(item);
            _context.SaveChanges();
            return item;
        }
        #endregion

        #region Delete

        public Supplier Delete(int key)
        {
            var suuplier = Get(key);
            if(suuplier != null)
            {
                _context.suppliers.Remove(suuplier);
                _context.SaveChanges();
                return suuplier;
            }
            return null;
        }
        #endregion

        #region Get
        public Supplier Get(int key)
        {
            var supplier = _context.suppliers.FirstOrDefault(s => s.SupplierId == key);
            return supplier;
        }
        #endregion

        #region
        public Supplier GetByPhone(string phone)
        {
            var supplier = _context.suppliers.FirstOrDefault(g=>g.Phone == phone);
            return supplier;
        }
        #endregion

        #region GetAll
        public List<Supplier> GetAll()
        {
            return _context.suppliers.ToList();
        }
        #endregion

        #region Update
        public Supplier Update(Supplier item)
        {
           _context.Entry<Supplier>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
        #endregion
    }
}
