using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Common;

namespace AirConditionerSystem
{
    class TemperatureSimulator
    {
        private SynchronizationContext context;
        private Client cl;
        private bool isStop;
        private static object locker = new Object();
        private static TemperatureSimulator instance;
        public static TemperatureSimulator getInstance(Client c)
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        return new TemperatureSimulator(c);
                    }
                }
            }
            return instance;
        }
        private int roomNumber;
        private float roomTemperature;
        private TemperatureSimulator(Client c)
        {
            context = c.context;
            cl = c;
            isStop = true;
        }

        public void startSimulating()
        {
            isStop = false;
            Thread t = new Thread(new ThreadStart(doSimulate));
            t.IsBackground = true;
            t.Start();
        }

        public void stopSimulate()
        {
            isStop = true;
        }

        private void doSimulate()
        {
            while (!isStop)
            {
                if (cl.speed == Constants.LOW_SPEED)
                {
                    Thread.Sleep(3000);
                }
                else if (cl.speed == Constants.MID_SPEED)
                {
                    Thread.Sleep(2000);
                }
                else if (cl.speed == Constants.HIGH_SPEED)
                {
                    Thread.Sleep(1000);
                }
                else if (cl.speed == Constants.NONE_SPEED)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (cl.mode == 0 && cl.nowTp > roomTemperature)
                {
                    roomTemperature--;
                }
                else if (cl.mode == 1 && cl.nowTp < roomTemperature)
                {
                    roomTemperature++;
                }
                context.Post(cl.roomTpCallBack, roomTemperature);
            }
        }

        public float getRoomTemperature()
        {
            return roomTemperature;
        }

    }
}
