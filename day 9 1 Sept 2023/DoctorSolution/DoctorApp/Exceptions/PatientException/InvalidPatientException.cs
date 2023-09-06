namespace DoctorApp.Exceptions.PatientException
{
    public class InvalidPatientException : Exception
    {
        string message;

        public InvalidPatientException()
        {
            message = "Invalid Patient";
        }
        public override string Message => message;
    }
}
