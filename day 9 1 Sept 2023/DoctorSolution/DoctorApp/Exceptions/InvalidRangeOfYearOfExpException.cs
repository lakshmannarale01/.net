namespace DoctorApp.Exceptions
{
    public class InvalidRangeOfYearOfExpException : Exception
    {
        string message;
        public InvalidRangeOfYearOfExpException()
        {
            message = "Invalid value range Id";
        }
        public override string Message => message;
    }
}
