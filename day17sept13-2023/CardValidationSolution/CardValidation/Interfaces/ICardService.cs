using CardValidation.Models;

namespace CardValidation.Interfaces
{
    public interface ICardService
    {
        bool ValidateCard(string ccNumber);
    }
}
