using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDemo
{
    //Consuming members of a class from the same class
    public class Car
    {
        public void Breeza() 
        {
            Console.WriteLine("public car Breeza");
        }
        private void Verna() 
        {
            Console.WriteLine("private car Verna");
        }
        internal void Kia()
        {
            Console.WriteLine("Internal car Kia");
        }
        protected void Volvo()
        {
            Console.WriteLine("Protected car Volvo");
        }
        protected internal void Audi()
        {
            Console.WriteLine("Protected internal car Audi");
        }
        static void Main(string[] args)
        {
            Car p = new Car();
            p.Breeza();
            p.Verna();
            p.Audi();
            p.Volvo();
            p.Kia();
            Console.ReadLine();
        }
    }
}
