using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;

namespace SupplierAndProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _service;
        private readonly IRepository<int, Supplier> _repo;

        public SupplierController(ISupplierServices supplierServices , IRepository<int , Supplier> repository)
        {
            _service = supplierServices;
            _repo=  repository;

        }
        #region Get All Supplier
        [HttpGet("GetAllSuppliers")]
        public IActionResult Get()
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
