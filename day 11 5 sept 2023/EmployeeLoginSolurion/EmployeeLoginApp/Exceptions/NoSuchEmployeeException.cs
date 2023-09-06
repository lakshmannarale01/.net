namespace EmployeeLoginApp.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "There is no employee with the spec you have specified";
        }
        public override string Message => message;
    }
}
