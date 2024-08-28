using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Employee : IWrite, IDance
    {
        public void Write()
        {
            Console.WriteLine("Employee Writing the Documentation");
        }
        public void Dance()
        {
            Console.WriteLine("Dancing in function");
        }
    }
}
