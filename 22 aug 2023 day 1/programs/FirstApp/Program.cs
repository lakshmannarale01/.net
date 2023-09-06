namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the your Name");
            String name = Console.ReadLine();
            Console.WriteLine("Hello "+name);
            Console.WriteLine($"hiii {name}");
            Console.ReadKey();
            
        }
    }
}