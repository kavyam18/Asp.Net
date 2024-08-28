namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("From Employee");

            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");

            Console.WriteLine("------------------------------");

            //Singleton.DerivedSingleton derivedObj = new Singleton.DerivedSingleton();
            //derivedObj.PrintDetails("From Derived Class");

            Console.ReadLine();
        }
    }
}
