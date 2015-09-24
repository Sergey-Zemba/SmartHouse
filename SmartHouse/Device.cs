﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    abstract class Device : ISwitchable
    {
        private SwitchState switchState;
        public SwitchState SwitchState
        {
            get
            {
                return switchState;
            }

        }
        public Device()
        {

        }
        public void On()
        {
            switchState = SwitchState.On;
        }

        public void Off()
        {
            switchState = SwitchState.Off;
        }

        public override string ToString()
        {
            string str = this.GetType().Name + " is " + SwitchState;
            if (this is IOpenable)
            {
                str += " and " + (this as IOpenable).OpenState;
            }
            return str;
        }
    }
}
