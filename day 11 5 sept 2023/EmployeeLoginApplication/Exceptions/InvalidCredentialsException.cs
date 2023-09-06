namespace EmployeeLoginApplication.Exceptions
{
    public class InvalidCredentialsException:Exception
    {
        public override string Message => "Invalid username or password";
    }
}
