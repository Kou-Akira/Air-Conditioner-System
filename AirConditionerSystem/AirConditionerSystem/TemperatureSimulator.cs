using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerSystem
{
     class TemperatureSimulator
     {
        private static object locker;
        private static TemperatureSimulator instance;
        public static TemperatureSimulator getInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        return new TemperatureSimulator();
                    }
                }
            }
            return instance;
        }
        private int roomNumber;
        private float roomTemperature;
        public TemperatureSimulator()
        {
           
        }

        public void startSimulating()
        {
            roomTemperature = 23.5F;
        }

        public float getRoomTemperature()
        {
            return roomTemperature;
        }

     }
}
