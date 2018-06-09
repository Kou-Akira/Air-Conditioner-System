using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace Common
{
    public class AsynTask
    {
        private BackgroundWorker worker;
        public AsynTask(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler callBack)
        {
            worker = new BackgroundWorker();
            worker.DoWork += doWork;
            worker.RunWorkerCompleted += callBack;
        }
        
        public void startTask()
        {
            worker.RunWorkerAsync();
        }

        public void startTask(object o)
        {
            worker.RunWorkerAsync(o);
        }
    }
}
