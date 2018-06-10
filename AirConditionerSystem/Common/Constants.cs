using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerSystem
{
    public class Constants
    {
        public const int LOW_SPEED = 0;
        public const int MID_SPEED = 1;
        public const int HIGH_SPEED = 2;

        public const int PANEL_INTERVAL = 3000;

        public const int DEFAULT_TEMPERATURE = 26;
        public const int TEMPERATURE_MAX = 30;
        public const int TEMPERATURE_MIN = 18;

        public const String CONNECT_COUNT_STR = "连接数量：";
        public const String WORKING_MODE_STR = "工作模式：";
        public const String NOW_PAYMENT = "当前费用：";
        public const String ROOM_TP = "房间温度：";

    }
}
