using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using DoctorApp.Services;
using Microsoft.AspNetCore.Mvc;

using DoctorApp.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository<int, Patient> _repository;
        private readonly PatientService _patientService;
       

        static List<Patient> patient = new List<Patient>();
        public PatientController(IRepository<int, Patient> repository, PatientRepository repository1, PatientService patientService1)
        {
            _repository = repository;
            _patientService = patientService1;
            
        }




        #region Index = Patient/Index
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        #endregion



        #region Add Patient == /Patient/Add
        [HttpGet]
        public IActionResult AddPatient()
        {
            //ViewBag.patientList = GetPatient();
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            //ViewBag.patientList = GetPatient();
            _repository.Add(patient);
            return RedirectToAction("Index");
        }

        //private List<SelectListItem> GetPatient()
        //{
        //    List<SelectListItem> patientList = new List<SelectListItem>();
        //    var doct = _Prepo.GetAll();
        //    foreach (var p in doct)
        //    {
        //        patientList.Add(
        //            new SelectListItem
        //            { Text = p.PatientName, Value = p.PatientId.ToString() }
        //            );
        //    }
        //    return patientList;
        //}

        #endregion

        #region update Patient
        [HttpGet]
        public IActionResult UpdatePatient(int id)
        {
            var pat = _repository.GetById(id);
            return View(pat);
        }
        [HttpPost]
        public IActionResult UpdatePatient( int id ,Patient patient)
        {
            ViewBag.Message = "";
            try
            {
                _patientService.UpdatePatient(patient);
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "patient  not found";

            }
            return View(patient);
        }
        #endregion
    }



    
}
