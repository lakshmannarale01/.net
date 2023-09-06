namespace numbersoperation
{
    internal class Program
    {
        int num1, num2;
        void InputFromUser()
        {   
            Console.WriteLine("Enter the first number :-");
            num1 = Convert.ToInt32 (Console.ReadLine());
             Console.WriteLine("Enter the first number :-");
            num2 = Convert.ToInt32(Console.ReadLine());

        }
        int Add(int n1 , int n2)
        {
            return n1 + n2;
        }
        int Sub(int n1, int n2)
        {
            return n1 - n2;
        }
        int Mult(int n1, int n2)
        {
            return n1 * n2;
        }
        int Div(int n1, int n2)
        {
            return n1 / n2;
        }
        void CalculateAndPrint()
        {
            InputFromUser();
            int result1 = Add(num1, num2);
            Console.WriteLine($"The sum of {num1} and {num2} is {result1}");
            Console.WriteLine("-------------------------------");
            int result2 = Sub(num1, num2);
            Console.WriteLine($"The sum of {num1} and {num2} is {result2}");
            Console.WriteLine("-------------------------------");
            int result3 = Mult(num1, num2);
            Console.WriteLine($"The multiplication of {num1} and {num2} is {result3}");
            Console.WriteLine("-------------------------------");
            int result4 = Div(num1, num2);
            Console.WriteLine($"The Div of {num1} and {num2} is {result4}");
            Console.WriteLine("-------------------------------");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CalculateAndPrint();
            Console.ReadKey();
        }
    }
}