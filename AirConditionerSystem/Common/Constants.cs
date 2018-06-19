using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Common {
	public static class Constants {
        public const int NONE_SPEED = 0;
		public const int LOW_SPEED = 1;
		public const int MID_SPEED = 2;
		public const int HIGH_SPEED = 3;

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
        public const String WORKING_STATE = "主机状态：";


        public const String IP_ADDRESS = "10.105.249.190";
		public const int PORT = 6000;
		public const int MAXBYTES = 20;
		public const int IDLENTH = 18;

		public const int REFRESH_INTERVAL = 5;
		public const int TOTAL_SERVICE_AMOUNT = 3;

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

		private static XmlNode sqlNode;
		private static XmlNode root;
		private static string sqlName;
		private static string loginName;
		private static string loginPassword;
		private static string initialCatalog;
		private static SqlConnectionStringBuilder builder;

		static Constants() {
			//XmlDocument doc = new XmlDocument();
			//doc.Load("Constants.config");
			//root = doc.DocumentElement;
			//sqlNode = root.SelectSingleNode("sqlconfig");
			//sqlName = sqlNode.SelectSingleNode("sqlname").InnerText;
			//loginName = sqlNode.SelectSingleNode("loginname").InnerText;
			//loginPassword = sqlNode.SelectSingleNode("loginpassword").InnerText;
			//initialCatalog = sqlNode.SelectSingleNode("initialcatalog").InnerText;

		}
	}
}
