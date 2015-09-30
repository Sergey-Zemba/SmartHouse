using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse.Devices
{
    class PanasonicLoudspeakers : Loudspeakers, IBass
    {
        private bool bass;


        public void BassOn()
        {
            bass = true;
        }

        public void BassOff()
        {
            bass = false;
        }
        public override string ToString()
        {
            string str = base.ToString();
            if (bass)
            {
                str += " Bass is on";
            }
            else
            {
                str += " Bass is off";
            }
            return str;
        }
    }
}
