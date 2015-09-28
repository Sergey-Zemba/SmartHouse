using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Fridge : Device, IOpenable
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
            
        }

        public void Close()
        {
            openState = OpenState.Close;
        }

    }
}
