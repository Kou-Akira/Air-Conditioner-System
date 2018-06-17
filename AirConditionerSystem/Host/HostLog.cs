using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host {
	class HostLog {
		byte roomNum;
		DateTime time;
		/// <summary>
		/// 操作号
		/// 2调节风速
		/// 1关机 0开机
		/// </summary>
    int opera;
		int speed;
    float temperature;
		float cost;

		public byte RoomNum {
			get { return roomNum; }
			set {
				roomNum = value;
			}
		}
		public DateTime Time {
			get { return time; }
			set {
				time = value;
			}
		}
		/// <summary>
		/// 操作号
		/// 2调节风速
		/// 1关机 0开机
		/// </summary>
		public int Opera {
			get { return opera; }
			set {
				opera = value;
			}
		}
		public int Speed {
			get { return speed; }
			set {
				speed = value;
			}
		}
		public float Temperature {
			get { return temperature; }
			set {
				temperature = value;
			}
		}
		public float Cost {
			get { return cost; }
			set {
				cost = value;
			}
		}

		public HostLog(DbDataReader dr) {
			this.RoomNum = (byte)Convert.ToInt32(dr["RoomNum"].ToString());
			this.Time = Convert.ToDateTime(dr["Time"].ToString());
			this.Opera = Convert.ToInt32(dr["Opera"].ToString());
			this.Speed = Convert.ToInt32(dr["Speed"].ToString());
			this.Temperature = Convert.ToSingle(dr["Temperature"].ToString());
			this.Cost = Convert.ToSingle(dr["Cost"].ToString());
		}
	}
}
