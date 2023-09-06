using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using DoctorApp.Services;
using DoctorApplication.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DoctorApp.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IRepository<int, Appointment> _repository;
        private readonly AppointmentService _appointmentService;
       

        static List<Patient> patient = new List<Patient>();
        public AppointmentController(IRepository<int, Appointment> repository, AppointmentRepository repository1, AppointmentService appointmentService)
        {
            _repository = repository;
            _appointmentService = appointmentService;
           
        }

        #region Index = /Appointment/Index
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        #endregion


        #region book = /Appointment/BookAppointment
        [HttpGet]
         public IActionResult BookAppointment()
        {
            //ViewBag.ampylist = GetAppointment();
            return View();
        }
        [HttpPost]
        public IActionResult BookAppointment(Appointment appointment)
        {
            //ViewBag.ampylist = GetAppointment();
            _repository.Add(appointment);
            return RedirectToAction("Index");
        }
        //private List<SelectListItem> GetAppointment()
        //{
        //    List<SelectListItem> ampylist = new List<SelectListItem>();
        //    var ampt = _ARepo.GetAll();
        //    foreach (var d in ampt)
        //    {
        //        ampylist.Add(
        //            new SelectListItem
        //            {  Value = d.AppointmentNumber.ToString() }
        //            );
        //    }
        //    return ampylist;
        //}
        #endregion

        #region CheckAvailability = /Appointment/CheckAvailability

        [HttpGet]
        public IActionResult CheckAvailability(Appointment appointment)
        {
            //ViewBag.ampylist = GetAppointment();
            return View();
        }

        #endregion

        #region cancel Appointment = /Appointment/cancelAppointment
        [HttpGet]
        public IActionResult cancelAppointment(int id)
        {
            var appointments = _repository.GetById(id);
            return View(appointments);
        }
        [HttpPost]
        public IActionResult cancelAppointment(int id, Appointment appointment)
        {

            ViewBag.Message = "";
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "Unable to delete appointment";

            }
            return View(appointment);
        }
        #endregion


    }
}
