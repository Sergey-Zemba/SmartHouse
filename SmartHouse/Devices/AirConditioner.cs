using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse.Devices
{
    class AirConditioner : Device, ITemperature
    {
        private int temperature;

        public AirConditioner()
        {
            temperature = 18;
        }
        public void AddTemperture()
        {
            if (temperature < 25)
            {
                temperature++;
            }
            else
            {
                temperature = 25;
            }

        }

        public void DecreaseTemperature()
        {
            if (temperature > 16)
            {
                temperature--;
            }
            else
            {
                temperature = 16;
            }
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += " Current temperature: " + temperature;
            return str;
        }
    }
}
