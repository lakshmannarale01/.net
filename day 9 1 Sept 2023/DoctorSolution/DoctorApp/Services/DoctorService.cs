using DoctorApp.Exceptions;
using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;

namespace DoctorApp.Services
{
    public class DoctorService : IManageDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;
        private readonly DoctorsRepository _dRepository;
        private object p;

        //static List<Doctor> doctors = new List<Doctor>();
        public DoctorService(IRepository<int, Doctor> repository, DoctorsRepository repository1)
        {
            _repository = repository;
            _dRepository= repository1;
        }
        #region AddDoctor
        /// <summary>
        /// this method to add Doctor 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = _repository.Add(doctor);
            return result;
        }
        #endregion

        #region GetDoctor Experience
        public ICollection<Doctor> GetDoctorExp(int min, int max)
        {
            var doct = _repository.GetAll();
            if (min >= 00 || max > 0)
            {
                var expRange = doct.Where(p=>p.YearOfExp>= min && p.YearOfExp <= max).ToList();
                if (expRange.Count == 0)
                    throw new InvalidDoctorExceptions();
                return expRange;
            }
            throw new InvalidRangeOfYearOfExpException();
        }
        #endregion


        #region Update Doctor Speciality

        public Doctor UpdateDoctorSpeciality(int id, Doctor doctor)
        {
            var doct = _dRepository.GetById(id);
            if (doct == null)
                throw new InvalidDoctorExceptions();
            doct.Speciality = doctor.Speciality;
            doct = _repository.Update(doct);
            return doct;
        }
        #endregion

        #region Update Doctor Experience

        public Doctor UpdateDoctorExp(int id ,Doctor doctor)
        {
            var doct = _dRepository.GetById(id);
            if (doct == null)
                throw new InvalidDoctorExceptions();
            doct.YearOfExp = doctor.YearOfExp;
            doct = _repository.Update(doct);
            return doct;
        }
        #endregion

        #region Update Doctor Phone
        public Doctor UpdateDoctorPhone(int id, Doctor doctor)
        {
            var doct = _dRepository.GetById(id);
            if (doct == null)
                throw new InvalidDoctorExceptions();
            doct.Doctorphone = doctor.Doctorphone;
            doct = _repository.Update(doct);
            return doct;
        }
        #endregion

        #region Update Doctor
        public Doctor UpdateDoctor(Doctor doctor)
        {
            Doctor doct = _dRepository.GetById(doctor.DoctorId);
            doct.DoctorName = doctor.DoctorName;
            doct.YearOfExp = doctor.YearOfExp;
            doct.Doctorphone = doctor.Doctorphone;
            doct.DoctorEmail = doctor.DoctorEmail;
            doct.Speciality = doctor.Speciality;
            doct.pic = doctor.pic;

            return doct;
        }
        #endregion
    }
}
