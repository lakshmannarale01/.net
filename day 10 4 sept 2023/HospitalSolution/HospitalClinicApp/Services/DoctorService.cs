using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models;
using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models.DTO;

namespace HospitalClinicApp.Services
{
    public class DoctorService : IDoctorService
    {
        private IRepository<int, Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public Doctor Add(Doctor entity)
        {
           entity.Pic = "/Images"+ entity.Pic;
            var doctor = _repository.Add(entity);
            return doctor;
        }

        public IList<Doctor> GetAllDoctor()
        {
            return _repository.GetAll().ToList();
        }

        public Doctor UpdateSpecialization(DoctorSpecialDTO doctor)
        {
            var myDoctor = _repository.GetById(doctor.Id);
            myDoctor.Speciality = doctor.Speciality;
            _repository.Update(myDoctor);
            return myDoctor;
        }
        public Doctor UpdatePhone(Doctor doctor)
        {
            var myDoctor = _repository.GetById(doctor.Id);
            myDoctor.Phone = doctor.Phone;
            _repository.Update(myDoctor);
            return myDoctor;
        }
        public Doctor UpdateEmail(Doctor doctor)
        {
            var myDoctor = _repository.GetById(doctor.Id);
            myDoctor.Email = doctor.Email;
            _repository.Update(myDoctor);
            return myDoctor;
        }
    }
}