namespace HospitalClinicApp.Utilities
{
    public class DoctorNotFreeException : Exception
    {
        string message;
        public DoctorNotFreeException()
        {
            message = "Doctors occoupied already that time  ";

        }
        public override string Message => message;
    }
}
