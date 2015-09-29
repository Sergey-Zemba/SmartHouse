using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class PanasonicFactory : StereoSystemFactory
    {

        public override StereoSystem MakeStereoSystem()
        {
            PanasonicStereoSystem p = new PanasonicStereoSystem();
            p.Loudspeakers = MakeLoudspeakers();
            return p;
        }

        public override Loudspeakers MakeLoudspeakers()
        {
            return new PanasonicLoudspeakers();
        }
    }
}
