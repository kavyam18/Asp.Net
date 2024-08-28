using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Square : Rectangle
    {
        public void CalculateArea()
        {
            width = 2;
            double result=width * width;
            Console.WriteLine(result);
        }
    }
}
