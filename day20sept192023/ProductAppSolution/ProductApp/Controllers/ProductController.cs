using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Interfaces;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _proservice;

        public ProductController(IProductService productservice)
        {
            _proservice=    productservice;
        }
        [HttpGet]
        public ActionResult Get() {
        var result = _proservice.GetAllProducts();
            if (result == null)
            {
                return NotFound("Product Are Not Available");
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var result = _proservice.AddANewProduct(product);
                    return Created("", result);
                }
                catch (Exception e )
                {

                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _proservice.Delete(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
