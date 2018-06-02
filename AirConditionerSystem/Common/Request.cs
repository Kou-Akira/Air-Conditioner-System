using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class Request : IRequest<Request> {
		public Request FromString(string s) {
			throw new NotImplementedException();
		}

		public string ToString() {
			throw new NotImplementedException();
		}
	}
}
