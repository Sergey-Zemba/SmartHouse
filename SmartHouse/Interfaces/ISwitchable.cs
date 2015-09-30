using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    interface ISwitchable
    {
        SwitchState SwitchState { get; }
        void On();
        void Off();
    }
}
