namespace HospitalClinicApp.Utilities
{
    public class NoSuchEntityException : Exception

    {
        string message;
        public NoSuchEntityException(string name)
        {
            message = $"No Such {name} is available";
        }
        public override string Message => message;
    }
}
