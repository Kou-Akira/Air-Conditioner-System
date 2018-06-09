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
        private int roomTemperature;
        public TemperatureSimulator()
        {
           
        }

        public void startSimulating()
        {

        }

        public int getRoomTemperature()
        {
            return roomTemperature;
        }

     }
}
