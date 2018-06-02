using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	interface IRequest<T> {
		String ToString();
		T FromString(String s);
		int RoomNumber();
	}
}
