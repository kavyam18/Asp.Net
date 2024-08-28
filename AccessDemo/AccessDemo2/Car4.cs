using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDemo2
{
    //Consuming members of a class from non-child class of different Project
    class Car4
    {
        static void Main()
        {
            AccessDemo.Car car = new AccessDemo.Car();
            car.Breeza();
            Console.ReadLine();
        }
    }
}
