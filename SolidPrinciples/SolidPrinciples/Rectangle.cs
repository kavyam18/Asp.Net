using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Rectangle : ICalculation
    {
        public int width;
        public int height;
        double c;
        public void CalculateArea()
        {
            width = 4;
            height = 4;
            c = width * height;
            Console.WriteLine(c);
        }
    }
}
