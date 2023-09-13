class Program
{ 
  
    static void Main(string[] args) { 
        int[] numbers = new int[10];
        int count = 0;
        Console.WriteLine("Enter numbers");
        int input;
        do 
        {
            if (int.TryParse(Console.ReadLine(), out input)) 
            { 
                numbers[count] = input;
                if (count < numbers.Length)
                {
                    count++;
                }
                else
                    Console.WriteLine("-------------------");
            }
            else
            { 
                Console.WriteLine("Invalid input.");
            }
        } 
        while (input != 0); 
        Console.WriteLine("Prime numbers"); 
        for (int i = 0; i < count; i++)
        { 
            if (IsPrime(numbers[i]))
            { 
                Console.WriteLine(numbers[i]);
            } 
        } 
    }
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }
}