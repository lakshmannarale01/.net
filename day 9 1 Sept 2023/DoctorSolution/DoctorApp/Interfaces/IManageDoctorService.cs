using DoctorApp.Models;

namespace DoctorApp.Interfaces
{
    public interface IManageDoctorService
    {
        Doctor AddDoctor(Doctor doctor);
     

        public ICollection<Doctor> GetDoctorExp(int min, int max);

        public Doctor UpdateDoctorExp(int id, Doctor doctor);

        public Doctor UpdateDoctorPhone(int id, Doctor doctor);

        public Doctor UpdateDoctorSpeciality(int id, Doctor doctor);
    }
}
