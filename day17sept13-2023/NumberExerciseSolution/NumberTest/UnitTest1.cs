using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NumberExercise.Interfaces;
using NumberExercise.Services;

namespace NumberTest
{
    public class Tests
    {
        INumberService _num;
        [SetUp]
        public void Setup()
        {
            _num = new NumberServices();
        }

        [Test]
      
        public void check()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 16 }; 


             var result = _num.FindSquare(numbers);

            Assert.Contains(1,  result);
            Assert.Contains(2, result);
            Assert.Contains(4, result);
            Assert.Contains(3, result);
        }
    }
}