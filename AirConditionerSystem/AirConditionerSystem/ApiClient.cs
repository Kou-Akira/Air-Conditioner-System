using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirConditionerSystem
{
    static class ApiClient
    {
        public static bool sendTurnOnRequest()
        {
            //Network send request
            Thread.Sleep(2000);
            return false;
        }

        public static bool sendTurnOffRequest()
        {
            return true;
        }

        public static void sendRoomTemperature() { }

        public static bool sendSpeedMode(int mode)
        {
            return true;
        }

        public static bool sendLoginInfo(string roomNum,string ID)
        {
            return true;
        }
    }
}
