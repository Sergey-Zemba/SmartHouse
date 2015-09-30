using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Devices
{
    interface IRecording
    {
        void StartRecording();
        void StopRecording();
    }
}
