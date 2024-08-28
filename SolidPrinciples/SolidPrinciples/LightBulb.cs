using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class LightBulb : ISwitchable
    {
         public void TurnOn()
        {
            Console.WriteLine("Light On");
        }
         public void TurnOff()
        {
            Console.WriteLine("Light Off");
        }
        public bool isOn()
        {
            return true;
        }

    }
}
