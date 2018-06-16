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
            byte[] buffer = PackageHelper.GetByte(new ClientLoginPackage(roomNumber, id));
            Client.sendPackage(buffer);
        }

        public static void sendClientCloseRequest()
        {
            byte[] buffer = PackageHelper.GetByte(new ClientClosePackage(TemperatureSimulator.getInstance().getRoomTemperature()));
            Client.sendPackage(buffer);
        }

        public static void sendRoomTemperature() { }

        public static bool sendSpeedMode(int mode)
        {
            Thread.Sleep(2000);
            return true;
        }
    }
}
