using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                //Thread.Sleep(1000);
                context.Post(cl.roomTpCallBack, roomTemperature);
            }
        }

        public float getRoomTemperature()
        {
            return roomTemperature;
        }

     }
}
