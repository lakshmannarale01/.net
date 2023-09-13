using CardValidation.Interfaces;
using CardValidation.Services;

namespace CreditCardTest
{
    public class Tests
    {
        ICardService cardService;
        [SetUp]
        public void Setup()
        {
            cardService = new CardServices();
        }

        [TestCase("4477468343113002")]
        [TestCase("Checkk")]
        [TestCase("6477468343113002")]
        [TestCase("447746834311302")]
        public void ValidCheck(string number)
        {
            var result = cardService.ValidateCard(number);
            Assert.IsTrue(result);
        }
    }
}