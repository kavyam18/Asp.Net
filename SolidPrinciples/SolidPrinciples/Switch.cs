using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Switch
    {
       
        private readonly ISwitchable device;

        public Switch(ISwitchable device)
        {
            this.device = device;
        }
        public void Toggle()
        {
            if (device.isOn())
            {
                device.TurnOn();
            }
            else
            {
                device.TurnOff();
            }
        }
    }
}
