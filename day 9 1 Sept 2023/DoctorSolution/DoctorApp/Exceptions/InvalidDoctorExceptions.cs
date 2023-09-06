namespace DoctorApp.Exceptions
{
    public class InvalidDoctorExceptions : Exception
    {
        string message;
        public InvalidDoctorExceptions()
        
        {
            message = "Invalid Doctor Id";
        }
        public override string Message => message;
    }
}
