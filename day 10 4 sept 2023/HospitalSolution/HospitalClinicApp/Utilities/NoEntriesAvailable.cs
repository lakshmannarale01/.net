namespace HospitalClinicApp.Utilities
{
    public class NoEntriesAvailable : Exception
    {
        string message;
        public NoEntriesAvailable(string name)
        {
            message = $"No entries {name} is available";
        }
        public override string Message => message;
    }
}
