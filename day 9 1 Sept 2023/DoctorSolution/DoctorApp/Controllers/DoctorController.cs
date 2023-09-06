using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using DoctorApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IRepository<int, Doctor> _repository;
        private readonly DoctorService _doctorService;
       

        static List<Doctor> doctors = new List<Doctor>();
        public DoctorController(IRepository<int, Doctor> repository, DoctorsRepository repository1,
            DoctorService doctorService)
        {
            _repository = repository;
            _doctorService = doctorService;
           
        }




        #region index == /Index
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
        #endregion
     
       

     



        #region Add == /Doctor/AddDoctor
        [HttpGet]
        public IActionResult AddDoctor()
        {
            //ViewBag.doctorList = GetDoctor();
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            //ViewBag.doctorList = GetDoctor();
            _doctorService.AddDoctor(doctor);
            return RedirectToAction("Index");
        }
       


        //private List<SelectListItem> GetDoctor()
        //{
        //    List<SelectListItem> doctorList = new List<SelectListItem>();
        //    var doct = _docRe.GetAll();
        //    foreach (var d in doct)
        //    {
        //        doctorList.Add(
        //            new SelectListItem
        //            { Text = d.DoctorName, Value = d.DoctorId.ToString() }
        //            );
        //    }
        //    return doctorList;
        //}
        #endregion

        #region update Experience = /Doctor/UpdateDoctorExp
        [HttpGet]
        public IActionResult UpdateDoctorExp(int id)
        {
            var doct = _repository.GetById(id);
            return View(doct);
        }
        [HttpPost]
        public IActionResult UpdateDoctorExp(int id, Doctor doctor)
        {
            ViewBag.Message = "";
            try
            {
                _doctorService.UpdateDoctorExp(id , doctor);
             
                _repository.Update(doctor);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "doctor  not found";
            }
            return View(doctor);
        }
        #endregion

        #region update Speciality == /Doctor/UpdateDoctorSpeciality
        [HttpGet]
        public IActionResult UpdateDoctorSpeciality(int id)
        {
            var doctorexp = _repository.GetById(id);
            return View(doctorexp);
        }
        [HttpPost]
        public IActionResult UpdateDoctorSpeciality(int id, Doctor doctor)
        {
            ViewBag.Message = "";
            try
            {
                _doctorService.UpdateDoctorSpeciality(id , doctor);
                _repository.Update(doctor);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "doctor  not found";
            }
            return View(doctor);
        }
        #endregion

        #region delete = /Doctor/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = _repository.GetById(id);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Delete(int id, Doctor doctor)
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
                ViewBag.Message = "Unable to delete doctor";

            }
            return View(doctor);
        }
        #endregion


        #region update Phone = /Doctor/UpdateDoctorPhone
        [HttpGet]
        public IActionResult UpdateDoctorPhone(int id)
        {
            var doctorexp = _repository.GetById(id);
            return View(doctorexp);
        }
        [HttpPost]
        public IActionResult UpdateDoctorPhone(int id, Doctor doctor)
        {
            ViewBag.Message = "";
            try
            {
                _doctorService.UpdateDoctorPhone(id, doctor);
                _repository.Update(doctor);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "doctor  not found";
            }
            return View(doctor);
        }
        #endregion

     

    }
}
