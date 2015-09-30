using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse.Devices
{
    class PanasonicStereoSystem : StereoSystem, IBass
    {
        public PanasonicStereoSystem(PanasonicLoudspeakers p) : base(p)
        {
            
        }

        public void BassOn()
        {
            (Loudspeakers as PanasonicLoudspeakers).BassOn();
        }

        public void BassOff()
        {
            (Loudspeakers as PanasonicLoudspeakers).BassOff();
        }
    }
}
