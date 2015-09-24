﻿using System;
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
            if (FridgeOpened != null)
            {
                FridgeOpened("You forget to close your fridge");
            }
        }

        public void Close()
        {
            openState = OpenState.Close;
        }
        public delegate void FridgeDelegate(string msg);

        public event FridgeDelegate FridgeOpened;

    }
}
