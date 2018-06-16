using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace AirConditionerSystem
{
    static class ApiClient
    {
        public static void sendLoginRequest(int roomNumber, String id)
        {
            byte[] buffer = PackageHelper.GetByte(new ClientLoginPackage(632, "650204199612181235"));
            TcpConnector.sendPackage(buffer);
        }


        public static bool sendTurnOnRequest()
        {
            //Network send request
           // byte[] buffer = PackageHelper.GetByte(new )
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
            Thread.Sleep(2000);
            return true;
        }
    }
}
