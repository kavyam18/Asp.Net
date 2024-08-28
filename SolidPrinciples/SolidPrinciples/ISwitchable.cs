using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public interface ISwitchable
    {
       public bool isOn();
       public void TurnOn();
       public void TurnOff();
    }
}
