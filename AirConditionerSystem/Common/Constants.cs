using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	public class Constants {
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
		public const String ROOM_NUM = "Room ";
        public const String WAITING_CONN_COUNT = "当前等待队列：";


        public const String IP_ADDRESS = "10.105.249.190";
		public const int PORT = 6000;
		public const int MAXBYTES = 20;
		public const int IDLENTH = 18;

		public const int REFRESH_INTERVAL = 5;

		public const int HotMaxTemperature = 30;
		public const int HotMinTemperature = 25;
		public const int HotTemperatureDefault = 28;

		public const int ColdMaxTemperature = 25;
		public const int ColdMinTemperature = 18;
		public const int ColdTemperatureDefault = 22;

		public const float MidSpeedPower = 1.0F;
		public const float LowSpeedPower = 0.8F;
		public const float HighSpeedPower = 1.3F;
		public const int CostPrePower = 5;
	}
}
