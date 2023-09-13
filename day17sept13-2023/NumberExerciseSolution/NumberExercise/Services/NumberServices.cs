using NumberExercise.Interfaces;

namespace NumberExercise.Services
{
    public class NumberServices : INumberService

    {
        public List<int> FindSquare(int[] numbers)
        {
            List<int> result = new List<int>();
            foreach (var a in numbers)
            {
                var square = a * a;
                if (numbers.Contains(square))
                {
                    result.Add(a);
                }
            }
            return result;
        }
    }
}
