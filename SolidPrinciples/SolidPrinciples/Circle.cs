using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Circle : ICalculation
    {
        public double radius;
        public void CalculateArea()
        {
         radius = 2.16;
         double result = double.Pi * radius;
         Console.WriteLine(result);
        }
    }
}
