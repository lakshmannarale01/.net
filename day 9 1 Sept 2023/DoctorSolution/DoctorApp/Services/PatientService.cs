using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DoctorApp.Services
{
    public class PatientService : IManagePatientService
    {
     

        private readonly IRepository<int, Patient> _repository;
        private object p;
        private readonly PatientRepository _pRepository;

        public PatientService(IRepository<int, Patient> repository , PatientRepository repository1)
        {
            _repository = repository;
            _pRepository = repository1;

        }
        public Patient AddPatient(Patient patient)
        {
            var result = _repository.Add(patient);
            return result;
        }

        #region Update Doctor
        public Patient UpdatePatient(Patient patient)
        {
            Patient pat = _pRepository.GetById(patient.PatientId);
            pat.PatientName = patient.PatientName;
            pat.PatientPhone = patient.PatientPhone;
            pat.PatientEmail = patient.PatientEmail;

            return pat;
        }
        #endregion
    }
}
