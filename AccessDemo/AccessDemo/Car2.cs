using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDemo
{
    //Consuming memebers of a class from non-child class
    internal class Car2
    {
        static void Main() 
        {
           Car car = new Car(); 
            car.Breeza();
            car.Audi();
            car.Kia();
            Console.ReadLine();
        }
    }
}
