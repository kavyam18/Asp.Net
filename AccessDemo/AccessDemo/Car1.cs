using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDemo
{
    //Consuming members of a class from child class of same project
    internal class Car1 : Car
    {
        static void Main()
        {
            Car1 c = new Car1();
            c.Breeza();
            c.Audi();
            c.Volvo();
            c.Kia();
            Console.ReadLine();
        }
    }
}
