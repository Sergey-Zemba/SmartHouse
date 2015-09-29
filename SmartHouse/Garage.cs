using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Garage : Device, IOpenable
    {
        private OpenState openState;
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
            if (GarageOpened != null)
            {
                GarageOpened("You forget to close your garage");
            }
        }

        public void Close()
        {
            openState = OpenState.Close;
        }
        public delegate void GarageDelegate(string msg);

        public event GarageDelegate GarageOpened;

    }
}
