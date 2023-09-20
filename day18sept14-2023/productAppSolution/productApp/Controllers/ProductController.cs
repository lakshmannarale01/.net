using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productApp.Interfaces;
using productApp.Models;
using productApp.Models.DTOs;

namespace productApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            var result = _productServices.GetAllproduct();
            if (result == null)
            {
                return NotFound("No Product Available");
            }
            return Ok(result);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Post(Product procuct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _productServices.AddANewProduct(procuct);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }
     
        [HttpPut("UpdatePrice")]
        public ActionResult PutchangePrice(ProductPriceDTO productPriceDTO)
        {
            try
            {
                var result = _productServices.Updateprice(productPriceDTO);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdateQuantity")]
        public ActionResult PutchangeQuantity(ProductQuantity quantity)
        {
            try
            {
                var result = _productServices.UpdateQuantity(quantity);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetByRange")]
        public ActionResult GetByPriceRange(float min, float max)
        {
            var result = _productServices.GetInPriceRange(min, max);
            if (result == null)
                return NotFound("In no salary in this range");
            return Ok(result);
        }
    }
}
