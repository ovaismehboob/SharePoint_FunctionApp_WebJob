using adichostedapp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace adichostedapp
{
    internal class AppService
    {

        public void ExecuteTask()
        {

            List<SPData> lst= Manager.GetListData();
            DataManager.InsertListCount(lst.Count); 
        }
    }
}
