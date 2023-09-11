using FirstApi.Interfaces;
using FirstApi.Models;
using FirstApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _employeeService.GetAllEmployees();
            if (result == null)
            {
                return NotFound("No employees are there at this moment");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.AddANewEmployee(employee);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }
        [HttpPut("UpdateStatus")]
        public ActionResult PutChangeStatus(int id) 
        {
            try
            {
                var result = _employeeService.ToggleEmployeeStatus(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }
        [HttpPut("UpdateSalary")]
        public ActionResult PutchangeSalary(EmployeeSalaryDTO employeeSalaryDTO)
        {
            try
            {
                var result = _employeeService.UpdateEmployeeSalary(employeeSalaryDTO);
                if(result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdatePhone")]
        public ActionResult PutchangePhone(EmployeePhoneDTO employeePhoneDTO)
        {
            try
            {
                var result = _employeeService.UpdateEmployeePhone(employeePhoneDTO);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetBySalary")]
        public ActionResult GetBySalary(float min , float max)
        {
        var result = _employeeService.GemEmployeesInASalaryRange(min, max);
            if( result == null )
                    return NotFound("In no salary in this range");
            return Ok(result);
        }

    }
}
