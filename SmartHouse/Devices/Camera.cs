using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.States;

namespace SmartHouse.Devices
{
    class Camera : Device, IRecording
    {
        private RecordMode recordMode;
        public void StartRecording()
        {
            recordMode = RecordMode.Record;
        }

        public void StopRecording()
        {
            recordMode = RecordMode.Live;
        }

        public override string ToString()
        {
            string str = base.ToString();
            if (recordMode == RecordMode.Record)
            {
                str += " rec";
            }
            return str;
        }
    }
}
