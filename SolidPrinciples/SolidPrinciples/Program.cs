namespace SolidPrinciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open Close Principle

            //Circle circle = new Circle();
            //Rectangle rect = new Rectangle();
            //circle.CalculateArea();
            //rect.CalculateArea();
            
            //Liskov Substitution Principle
            //Square square = new Square();
            //square.CalculateArea();

            //Dependency Inversion Principle
            //ISwitchable switchable = new LightBulb();
            //Switch s = new Switch(switchable);
            //s.Toggle();
            
            //Interface Segregation Principle
            Student student = new Student();
            student.Write();
            student.Read();
            student.Game();
            Employee employee = new Employee(); 
            employee.Write();
            employee.Dance();
        }
    }
}
