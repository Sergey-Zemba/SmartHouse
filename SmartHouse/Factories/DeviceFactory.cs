using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    abstract class DeviceFactory
    {
        public abstract StereoSystem MakeStereoSystem();
        public abstract Loudspeakers MakeLoudspeakers();

    }
}
