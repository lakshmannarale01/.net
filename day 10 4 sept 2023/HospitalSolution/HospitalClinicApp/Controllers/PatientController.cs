using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalClinicApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;



        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        #region
        public IActionResult Index()
        {
            var patients = new List<Patient>();
            try
            {
                patients = _patientService.GetAllPatient().ToList();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogError("No doctors are available and call this a hospital..");
            }
            return View(patients);
        }
        #endregion


        #region

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            ViewBag.ErrorMessage = "";

            try
            {
                var myPatient = _patientService.Add(patient);
                _logger.LogInformation("Created patient record");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add patient " + DateTime.Now.ToString());
            }
            return View();
        }
        #endregion
    }
}
