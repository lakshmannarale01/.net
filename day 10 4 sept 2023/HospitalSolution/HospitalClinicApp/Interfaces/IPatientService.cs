using HospitalClinicApp.Models;

namespace HospitalClinicApp.Interfaces
{
    public interface IPatientService : IAddingEntity<Patient>
    {
        public IList<Patient> GetAllPatient();

        public Patient UpdatePatient(Patient patient);
    }
}
