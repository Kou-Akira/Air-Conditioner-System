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
        private Client cl;
        private Timer mTimer;
        private int SEND_INTERVAL = 1000 * 5; // 5 sescond per send 
        public HeartbeatpacketSender(Client c)
        {
            cl = c;
            mTimer = new Timer(SEND_INTERVAL);
            mTimer.AutoReset = true;
            mTimer.Elapsed += onTimeSend;
        }

        private void onTimeSend(object source, ElapsedEventArgs e)
        {
            float tp = TemperatureSimulator.getInstance(cl).getRoomTemperature();
            ApiClient.sendRoomTemperature(tp);
        }

        public void startSend()
        {
            mTimer.Enabled = true;
        }

        public void stopSend()
        {
            mTimer.Enabled = false;
        }

        public void resetTimer(int interVal)
        {
            stopSend();
            mTimer.Dispose();
            mTimer = new Timer(interVal * 1000);
            mTimer.AutoReset = true;
            mTimer.Elapsed += onTimeSend;
            startSend();
        }
    }
}
