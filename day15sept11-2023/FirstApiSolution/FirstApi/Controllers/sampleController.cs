using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sampleController : ControllerBase
    {
        //[HttpGet] public string Get()
        //{
        //    return "Hello";
        //}


        [HttpGet]
        public ActionResult Get() {
        return Ok( new string[] 
                {
            "hiii","byy","welocome"
            });
                
                }

        [HttpGet("GetById")]
        public ActionResult GetById(int idx)
        {
            return Ok(new string[]
                    {
            "hiii","byy","welocome"
                } [idx]
                ); ;

        }

        [HttpPost]
        public ActionResult deva(string name) {
        if(name.Length > 4) 
            {
                return Ok(name);
            }
        return BadRequest();
        }

        [HttpPut]
        public ActionResult Lakshman(Student student)
        {
            if(student.Id == 101) 
            {
                student.Name = "Somu";
                return Ok(student); 
            }
            return BadRequest();
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        [HttpDelete] public ActionResult deva(int id) 
        {
            if (id == 101)
                return Ok();
            return NotFound();
        }
        [HttpDelete("deva1")]
        public ActionResult deva1(int id)
        {
            if (id == 101)
                return Ok();
            return NotFound();
        }
    }
}
