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
            byte[] buffer = PackageHelper.GetByte(new ClientLoginPackage((byte)roomNumber, id));
            Client.sendPackage(buffer);
        }

        public static void sendClientCloseRequest()
        {
            byte[] buffer = PackageHelper.GetByte(new ClientClosePackage(TemperatureSimulator.getInstance().getRoomTemperature()));
            Client.sendPackage(buffer);
        }

        public static void sendRoomTemperature(float tp)
        {
            byte[] buffer = PackageHelper.GetByte(new ClientTemperaturePackage(tp));
            Client.sendPackage(buffer);
        }

        public static void sendTpChange(float tp)
        {
            byte[] buffer = PackageHelper.GetByte(new ClientTargetTemperaturePackage(tp));
            Client.sendPackage(buffer);
        }

        public static void sendSpeedRequest(int speed, float tp)
        {
            byte[] buffer = PackageHelper.GetByte(new ClientSpeedPackage(speed, tp));
            Client.sendPackage(buffer);
        }
    }
}
