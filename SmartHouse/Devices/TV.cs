using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.States;

namespace SmartHouse.Devices
{
    class TV : Device, IVolumeable, IRecording
    {
        private int volume;
        private RecordMode recordMode;

        public void AddVolume()
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

        public void DecreaseVolume()
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

        public void Mute()
        {
            volume = 0;
        }

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
            str += " volume = " + volume;
            if (recordMode == RecordMode.Record)
            {
                str += " rec";
            }
            return str;
        }
    }
}
