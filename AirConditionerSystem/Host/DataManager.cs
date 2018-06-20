using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    static class DataManager
    {
        private static List<IDataClient> subscriberList;
        private static ClientStatus[] clientList;

        public static void regist(IDataClient client)
        {
            for(int i = 0; i < subscriberList.Count; i++)
            {
                if(subscriberList[i] == client)
                {
                    return;
                }
            }
            subscriberList.Add(client);
        }

        public static void unRegist(IDataClient client)
        {
            subscriberList.Remove(client);
        }

        private static void notifyDataChanged()
        {
            for(int i = 0; i < subscriberList.Count; i++)
            {
                subscriberList[i].onDataRefreshed(clientList);
            }
        }
    }
}
