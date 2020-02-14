using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkLog.Forms;

namespace WorkLog.Manage
{
    class TempWorkOrderManage
    {
        /// <summary>
        /// 一時作業情報を挿入する
        /// </summary>
        /// <returns></returns>
        public void AddTempWorkOrderItem(Data.TempWorkOrderItem item)
        {
            DAO.TempWorkOrdetItemDAO.AddTempWorkOrderItemInfo(item);
        }


        /// <summary>
        /// 一時作業情報を取得する
        /// </summary>
        public List<Data.TempWorkOrderItem> GetTempWorkOrderInfo(int EmpID)
        {
            return DAO.TempWorkOrdetItemDAO.GetTempWorkOrder(EmpID);
        }


    }
}
