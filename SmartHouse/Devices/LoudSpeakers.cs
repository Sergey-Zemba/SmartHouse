using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse.Devices
{
    abstract class Loudspeakers : Device, IVolumeable
    {
        private int volume;

        public virtual void AddVolume()
        {
            if (volume < 100)
            {
                volume++;
            }
            else
            {
                volume = 100;
            }
        }

        public virtual void DecreaseVolume()
        {
            if (volume > 0)
            {
                volume--;
            }
            else
            {
                volume = 0;
            }
        }

        public virtual void Mute()
        {
            volume = 0;
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += " volume = " + volume;
            return str;
        }
    }
}
