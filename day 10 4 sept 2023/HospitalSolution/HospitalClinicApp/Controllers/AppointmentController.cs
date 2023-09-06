using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalClinicApp.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly ILogger<AppointmentController> _logger;
        private readonly IPatientService _patientService;

        public AppointmentController(IAppointmentService appointmentService,
            IDoctorService doctorService,
            IPatientService patientService,
            ILogger<AppointmentController> logger)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _logger = logger;
            _patientService = patientService;

        }
        #region Index
        public IActionResult Index()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                appointments = _appointmentService.GetAll().ToList();
                return View(appointments);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogInformation("There were no appointments");
            }
            return View(appointments);
        }
        #endregion

        #region create
        [HttpGet]
        [Route("BookAppointment/{id}")]
        public IActionResult Create(int id)
        {
            ViewBag.Patients = GetAllPatient();
            ViewBag.Doctors = GetDoctors();
            Appointment appointment = new Appointment();
            appointment.DoctorId = id;
            appointment.AppointmentDateTime = DateTime.Now;
            return View(appointment);
        }
        [HttpPost]
        [Route("{controller}/BookAppointment/{id}")]
        public IActionResult Create(int id ,Appointment appointment)
        {
            ViewBag.Doctors = GetDoctors();
            if (ModelState.IsValid)
            {
                try
                {
                    var myAppointment = _appointmentService.Add(appointment);
                    ViewBag.Registered = myAppointment.AppointmentNumber;
                    return View(myAppointment);
                }
                catch (Exception e)
                {

                    ViewBag.ErrorMessage = e.Message;
                    _logger.LogInformation("Unable to add appointment");
                }
            }
                return View(appointment);
            
        }
        #endregion

        #region getDoctors
        private List<SelectListItem> GetDoctors()
        {

            List<SelectListItem> doctors = new List<SelectListItem>();
            foreach (var item in _doctorService.GetAllDoctor())
            {
                var li = new SelectListItem
                {
                    Text = item.Name + " - " + item.Speciality,
                    Value = item.Id.ToString()
                };
                doctors.Add(li);
            }
            return doctors;

        }
        #endregion

        #region Get Patient
        private List<SelectListItem> GetAllPatient()
        {

            List<SelectListItem> patients = new List<SelectListItem>();
            foreach (var item in _patientService.GetAllPatient())
            {
                var P = new SelectListItem
                {
                    Text = item.Id + " - " + item.Name,
                    Value = item.Id.ToString()
                };
                patients.Add(P);
            }
            return patients;

        }

        #endregion
    }
}
