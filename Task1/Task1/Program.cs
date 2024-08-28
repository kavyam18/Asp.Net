namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employees = new List<Employee>();
            //employees.Add(new Employee(1, "Dhanush", "dhanush@gmail.com", "Cs", 4567.1));
            //employees.Add(new Employee(2, "Manikanta", "mani@gmail.com", "Ic", 78475.21));
            //employees.Add(new Employee(3, "Mahendra", "mahi@gmail.com", "E&C", 45414.34));
            //employees.Add(new Employee(4, "Ashirwad", "ashi@gmail.com", "EEE", 2454.47));

           
            Console.WriteLine("enter the employee_id:");
            int Employee_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the Employee name:");
            String name = Console.ReadLine();
            Console.WriteLine("enter the Employee email:");
            String email = Console.ReadLine();
            Console.WriteLine("enter the Employee dept:");
            String dept = Console.ReadLine();
            Console.WriteLine("Enter the Employee salary:");
            double salary = Console.Read();

            Employee employee = new Employee(Employee_id, name, email, dept, salary);

            Console.WriteLine(employee.display());
            //foreach (var item in employees)
            //{
            //  Console.WriteLine(item.display()+" ");
            //}

        }
    }
}
