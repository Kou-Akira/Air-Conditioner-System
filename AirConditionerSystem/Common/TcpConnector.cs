using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class TcpConnector
    {
        private TcpClient client;
        private NetworkStream networkStream;
        public TcpConnector()
        {
            client = new TcpClient(Constants.IP_ADDRESS, Constants.PORT);
            networkStream = client.GetStream();
            byte[] buffer = RequestHelper.GetByte(new ClientLoginRequest(632, "650204199612181235"));
            networkStream.Write(buffer, 0, buffer.Length);
        }
    }
}
