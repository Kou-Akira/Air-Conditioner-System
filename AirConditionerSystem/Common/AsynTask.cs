using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Common
{
    public delegate void CallBack();
    public class AsynTask
    {
        private CallBack mCallBack;
        private Thread mThread;

        public AsynTask(Thread t, CallBack callBack)
        {
            mThread = t;
            mCallBack = callBack;
        }
        
        public void startTask()
        {
            
            mThread.Start(mCallBack);
        }
    }
}
