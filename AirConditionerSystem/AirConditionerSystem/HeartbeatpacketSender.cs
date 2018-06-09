using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AirConditionerSystem
{
    class HeartbeatpacketSender
    {
        private Timer mTimer;
        private const int SEND_INTERVAL = 1000 * 5; // 5 sescond per send 
        public HeartbeatpacketSender()
        {
            mTimer = new Timer(SEND_INTERVAL);
            mTimer.AutoReset = true;
            mTimer.Elapsed += onTimeSend;
        }

        private void onTimeSend(object source, ElapsedEventArgs e)
        {
            int tp = TemperatureSimulator.getInstance().getRoomTemperature();
            ApiClient.sendRoomTemperature();
        }

        public void startSend()
        {
            mTimer.Enabled = true;
        }

        public void stopSend()
        {
            mTimer.Enabled = false;
        }
    }
}
