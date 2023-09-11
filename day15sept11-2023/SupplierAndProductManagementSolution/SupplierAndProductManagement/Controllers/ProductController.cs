using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierAndProductManagement.Interfaces;
using SupplierAndProductManagement.Model;
using SupplierAndProductManagement.Model.DTOs;
using SupplierAndProductManagement.Services;

namespace SupplierAndProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IRepository<int, Product> _repo;

        public ProductController(IProductService service, IRepository<int, Product> repository)
        {
            _service = service;
            _repo = repository;
        }
        #region Get


        [HttpGet]
        public ActionResult Get()
        {
            var result = _service.GetAllProducts();
            if (result == null)
            {
                return NotFound("No products are there at this moment");
            }
            return Ok(result);
        }

        #endregion

        #region Add Product
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.AddNewProduct(product);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }

        #endregion

        #region Update Price

        [HttpPut("Price")]
        public ActionResult UpdatePrice(UpdateProductPriceDTO price)
        {
            try
            {



                var result = _service.UpdateProductPrice(price);
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

        #region Update Price

        [HttpPut("Description")]
        public ActionResult UpdateDec(UpdateProductDescriptionDTO d)
        {
            try
            {



                var result = _service.UpdateProductDescription(d);
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

        #region Update Price

        [HttpPut("Name")]
        public ActionResult UpdateName(UpdateProductNameDTO name)
        {
            try
            {



                var result = _service.UpdateProductName(name);
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



        #region Delete

        [HttpDelete]
            public ActionResult DeleteProduct(int id)
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
        
    }
}
