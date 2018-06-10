using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class TcpConnector
    {
        private static TcpClient client;
        private static NetworkStream networkStream;
        private static RunWorkerCompletedEventHandler callBack;
        private static AsynTask asynTask;
        private static Object writeLock = new Object();

        public static void beginConnect(RunWorkerCompletedEventHandler callback)
        {
            callBack = callback;
            asynTask = new AsynTask(tcpConnect,tcpCallBack);
            asynTask.startTask();
        }
        public static void sendPackage(byte[] buffer)
        {
            lock (writeLock)
            {
                networkStream.Write(buffer, 0, buffer.Length);
            }     
        }

        private static void tcpConnect(object sender, DoWorkEventArgs e)
        {
            client = new TcpClient(Constants.IP_ADDRESS, Constants.PORT);
            networkStream = client.GetStream();
            while (true)
            {
                //get package
                Package req = PackageHelper.GetRequest(networkStream);
                new AsynTask(handleResponse, callBack).startTask(req);
            }
        }

        private static void tcpCallBack(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private static void handleResponse(object sender, DoWorkEventArgs e)
        {
            Package req = (Package)e.Argument;
            e.Result = req;
        }
    }
}
