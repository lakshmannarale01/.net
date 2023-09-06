using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Models;
using HospitalClinicApp.Utilities;

namespace HospitalClinicApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Patient> _repository;

        public LoginService(IRepository<int, Patient> repository)
        {
            _repository = repository;
        }
        public Patient Login(LoginDTO loginDTO)
        {
            try
            {
                var patient = _repository.GetById(loginDTO.Id);
                if (patient.Phone == loginDTO.Password)
                    return patient;
            }
            catch (NoSuchEntityException e)
            {
                throw new InvalidCredentialsException();
            }
            throw new InvalidCredentialsException();
        }
    }
}
