using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models;
using NuGet.Protocol.Core.Types;

namespace HospitalClinicApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _repository;

        public PatientService(IRepository<int , Patient>repository)
        {
            _repository = repository;
        }
        public Patient Add(Patient entity)
        {
            var patient = _repository.Add(entity);
            return patient;
        }

        public IList<Patient> GetAllPatient()
        {
            return _repository.GetAll().ToList();
        }

        #region Update Doctor
        public Patient UpdatePatient(Patient patient)
        {
            Patient pat = _repository.GetById(patient.Id);
            pat.Name = patient.Name;
            pat.Phone = patient.Phone;
            pat.Email = patient.Email;

            return pat;
        }
        #endregion
    }
}
