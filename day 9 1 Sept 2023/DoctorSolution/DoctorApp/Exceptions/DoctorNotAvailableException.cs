namespace DoctorApp.Exceptions
{
    public class DoctorNotAvailableException : Exception
    {
        string message;
        public DoctorNotAvailableException()
        {
            message = "Doctors Not Available";
        }
        public override string Message => message;
    }
}
