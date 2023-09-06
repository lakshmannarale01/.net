namespace employeeprogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ManageEmployee manageEmployee = new ManageEmployee();

            Employee employee = manageEmployee.CreateEmployeeByTakingDetailsFromConsole();

            manageEmployee.PrintEmployeeDetails(employee);

            
            Console.ReadKey();
        }
    }
}