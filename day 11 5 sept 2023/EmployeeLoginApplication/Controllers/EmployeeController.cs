using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;
using EmployeeLoginApplication.Repositories;
using EmployeeLoginApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using System.Security.Policy;

namespace EmployeeLoginApplication.Controllers
{
    public class EmployeeController : Controller
    {

        //private readonly IEmployeeService _employeeService;
       // private readonly ILogger<EmployeeController> _logger;
        //private readonly IRepository<int, Employee> _repository;



        private readonly IEmployeeService _employeeService;
        private readonly ILogger<Employee> _logger;



        public EmployeeController(IEmployeeService employeeService, ILogger<Employee> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _employeeService.GetAllEmployees().ToList();
                return View(employees);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogInformation("There were no employees");
            }
            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                var emp = _employeeService.Add(employee);
                _logger.LogInformation("Created employee record");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add employee ");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // ViewBag.Specialities = specilities;
            var emp = _employeeService.GetAllEmployees().SingleOrDefault(x => x.Id == id);
            var employee = new EmployeeSpecialDTO { Id = id, Phone = emp.Phone };
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(int id, EmployeeSpecialDTO employee)
        {
           // ViewBag.Specialities = specilities;
            try
            {
                var result = _employeeService.UpdatePhone(employee);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to update employee Phone Number");
            }
            return View(employee);
        }
    }
}

