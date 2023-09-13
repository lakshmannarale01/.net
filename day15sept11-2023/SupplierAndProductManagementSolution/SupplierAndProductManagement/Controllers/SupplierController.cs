using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;
using SupplierAndProductManagement.Repositories;

namespace SupplierAndProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _service;
        private readonly IRepository<int, Supplier> _repo;
        private readonly SupplierRepository _repo1;

        public SupplierController(ISupplierServices supplierServices , IRepository<int , Supplier> repository , SupplierRepository repository1)
        {
            _service = supplierServices;
            _repo=  repository;
            _repo1 = repository1;

        }
        #region Get All Supplier
        [HttpGet]
        public ActionResult Get()
        {
            var result = _service.GetAllSupplier();
            if(result == null)
            {
                return NotFound("No Supplier Found");
            }
            return Ok(result);
        }
        #region Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _repo.Delete(id);
                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        #region Serach by phone
        [HttpGet("GetBYPhone")]
        public ActionResult GetByPhone(String phone) 
        {
        var result = _repo1.GetByPhone(phone);
            if(result == null)
            {
                return NotFound();

            }
            return Ok(result);
        }

        #endregion

        #endregion
        #endregion
        #region AddSupplier
        [HttpPost("addSupplier")]
        public ActionResult AddSupplier(Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var result = _service.AddNewSupplier(supplier);
                    return Created("",result);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }


        #endregion

        #region UpdateName

        [HttpPut("UpdateEmail")]
        public ActionResult UpdateEmail(UpdateSupplierEmailDTO email) {
            try
            {
                var result = _service.UpdateSupplierEmail(email);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Update Name
        [HttpPut("UpadeName")]
        public ActionResult UpdateName(UpdateSupplierNameDTO name)
        {
            try
            {
                var result = _service.UpdateSupplierName(name);
                if(result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        #endregion

        #region update phone
        [HttpPut("updatePhone")]
        public ActionResult updatePhone(UpdatesupplierPhoneDTO phone)
        {
            try
            {
                var result = _service.UpdateSupplierPhone(phone);
                if(result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion

    }
}
