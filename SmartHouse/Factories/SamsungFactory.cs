using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class SamsungFactory : DeviceFactory
    {

        public override StereoSystem MakeStereoSystem()
        {
            SamsungStereoSystem s = new SamsungStereoSystem();
            s.Loudspeakers = MakeLoudspeakers();
            return s;
        }

        public override Loudspeakers MakeLoudspeakers()
        {
            return new SamsungLoudspeakers();
        }
    }
}
