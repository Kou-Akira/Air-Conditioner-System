using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    interface IDataClient
    {
        void onDataRefreshed(ClientStatus[] clientList);
    }
}
