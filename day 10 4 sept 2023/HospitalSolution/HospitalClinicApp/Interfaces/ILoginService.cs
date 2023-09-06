using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Models;

namespace HospitalClinicApp.Interfaces
{
    public interface ILoginService
    {
        public Patient Login(LoginDTO loginDTO);
    }
}
