using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    abstract class StereoSystem : Device, IVolumeable
    {
        public Loudspeakers Loudspeakers { get; set; }

        public virtual void AddVolume()
        {
            Loudspeakers.AddVolume();
        }

        public void DecreaseVolume()
        {
            Loudspeakers.DecreaseVolume();
        }

        public void Mute()
        {
            Loudspeakers.Mute();
        }

        public override void On()
        {
            base.On();
            Loudspeakers.On();
        }

        public override void Off()
        {
            base.Off();
            Loudspeakers.Off();
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += "\t" + Loudspeakers.ToString();
            return str;
        }
    }
}
