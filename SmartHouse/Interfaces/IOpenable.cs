using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.States;

namespace SmartHouse.Interfaces
{
    interface IOpenable
    {
        OpenState OpenState { get; }
        void Open();
        void Close();


    }
}
