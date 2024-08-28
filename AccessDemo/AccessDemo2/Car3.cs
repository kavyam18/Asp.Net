using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDemo2
{
    //Consuming members of a class from  child class of different project
     class Car3 : AccessDemo.Car
    {
        static void Main(string[] args)
        {
            Car3 car3 = new Car3(); 
            car3.Breeza();
            car3.Volvo();
            car3.Audi();
            Console.ReadLine();
        }
    }
}
