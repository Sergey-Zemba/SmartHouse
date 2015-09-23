using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    abstract class Device : ISwitchable
    {
    {
        public SwitchState State { get; set; }

        public Device()
        {

        }
        public void On()
        {
            State = SwitchState.On;
        }

        public void Off()
        {
            State = SwitchState.Off;
        }
    }
}
