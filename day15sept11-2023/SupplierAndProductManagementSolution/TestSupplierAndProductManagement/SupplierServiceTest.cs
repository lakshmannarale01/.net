using Microsoft.EntityFrameworkCore;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.ManageContext;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Repositories;
using SupplierAndProductManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestSupplierAndProductManagement
{
    internal class SupplierServiceTest
    {
        MContext context;

        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<MContext>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new MContext(dbContextOption);
        }
        [Test]
        public void AddNewSupplier()
        {
            // Arrange
            IRepository<int, Supplier> supplierRepository = new SupplierRepository(context);

            ISupplierServices supplierService = new SupplierServices(supplierRepository);

            //Action

            var supplier = new Supplier { SupplierId = 1, Email = "abc@gmail.com", Name = "ABC", Phone = "8856904770" };
            var result = supplierService.AddNewSupplier(supplier);
            var data = new Supplier { SupplierId = 1, Email = "abc@gmail.com", Name = "ABC", Phone = "8856904770" };

            //Assert
            Assert.AreEqual(data.SupplierId ,result.SupplierId);
       


        }
    }
}
