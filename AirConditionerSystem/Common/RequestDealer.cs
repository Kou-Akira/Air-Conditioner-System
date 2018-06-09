using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
	class RequestDealer {
		private Request request;
		public RequestDealer(Request request) {
			this.request = request;
			this.Deal();
		}
		public Request Deal() {
			switch (request.Cat) {
				case 1: {
					break;
				}
				case 2: {
					LoginRequest loginRequest = request as LoginRequest;

					break;
				}
				case 9: {
					throw new IOException();
				}
				default:
					break;
			}
		}
	}
}
