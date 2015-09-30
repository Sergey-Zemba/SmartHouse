using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;

namespace SmartHouse
{
    class Fridge : Device, IOpenable, ITemperature
    {
        private OpenState openState;
        private int temperature;

        public OpenState OpenState
        {
            get
            {
                return openState;
            }

        }

        public void Open()
        {

            openState = OpenState.Open;

        }

        public void Close()
        {
            openState = OpenState.Close;
        }
        public void AddTemperture()
        {
            if (temperature < 5)
            {
                temperature++;
            }
            else
            {
                temperature = 5;
            }

        }

        public void DecreaseTemperature()
        {
            if (temperature > -5)
            {
                temperature--;
            }
            else
            {
                temperature = -5;
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
