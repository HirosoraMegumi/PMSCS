using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Manage
{
    class WorkerViewManage
    {

        /// <summary>
        /// 社員情報取得
        /// </summary>
        /// /// <param name="LoginID">ログインID</param>
        public Data.WorkerItem GetWorkOrderInfoMaster(string LoginID)
        {
            return DAO.WorkerViewDAO.GetWorkerInfo(LoginID);
        }

    }
}
