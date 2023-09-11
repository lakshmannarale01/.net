namespace BlogApplication.Utilities
{
    public class UnableToUpdateException : Exception
    {
        string message;
        public UnableToUpdateException(string name)
        {
            message = $"Unnable to update {name} ...!!";
        }
        public override string Message => base.Message;
    }
}
