using HospitalClinicApp.Models;
using HospitalClinicApp.Models.DTO;

namespace HospitalClinicApp.Interfaces
{
    public interface IDoctorService : IAddingEntity<Doctor>
    {
        public Doctor UpdateSpecialization(DoctorSpecialDTO doctor);

        public Doctor UpdateEmail(Doctor doctor);

        public Doctor UpdatePhone(Doctor doctor);
        public IList<Doctor> GetAllDoctor();
       
    }
}
