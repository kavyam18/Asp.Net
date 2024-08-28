namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentService studentService = new StudentService(new StudentDAO());
            List<Student> students = studentService.GetAllStudents();
            foreach (Student stud in students)
            {
                Console.WriteLine($"ID={stud.Id}, Name = {stud.Name}, Email = {stud.Email}, Department = {stud.Department}");
            }
            Console.ReadKey();
        }
    }
}
