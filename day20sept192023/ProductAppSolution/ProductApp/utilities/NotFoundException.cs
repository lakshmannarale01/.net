using System.Xml.Linq;

namespace ProductApp.utilities
{
    public class NotFoundException : Exception
    {
        string message;
        public NotFoundException(string name)
        {
            message = $"No Entries {name} is available";
        }
        public override string Message => message;
    }
}
