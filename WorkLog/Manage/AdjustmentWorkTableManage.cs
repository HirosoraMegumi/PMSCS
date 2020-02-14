using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Manage
{
    class AdjustmentWorkTableManage
    {

        /// <summary>
        /// 対象実施作業を追加
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public void AddPerformedWorkInfo(Data.PerformedWorkOrderItem Item)
        {
            DAO.AdjustmentWorkResultTableDAO.AddAdjustmentWorkInfo(Item);
        }

    }
}
