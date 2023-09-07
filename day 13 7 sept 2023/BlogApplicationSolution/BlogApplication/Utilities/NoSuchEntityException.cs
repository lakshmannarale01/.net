namespace BlogApplication.Utilities
{
    public class NoSuchEntityException : Exception
    {
        string message;
        public NoSuchEntityException(string name)
        {
            message = $"No Such {name} found...!!";
        }
        public override string Message => base.Message;
    }
}
