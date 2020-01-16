using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfControlSystem.Manage
{
    class WorkOrderViewManage
    {
        /// <summary>
        /// 作業項目情報を取得する(現在作業中のオーダーのみ)
        /// </summary>
        public List<Data.WorkOrderItem> GetWorkOrderInfoMaster()
        {
            return DAO.WorkOrderViewDAO.GetWorkOrder();
        }

        /// <summary>
        /// 作業項目情報を取得する(現在作業中のオーダーのみ)
        /// </summary>
        /// <param name="DepID">データベース接続</param>
        /// <param name="ConType">直接 = 0、間接 = 1</param>
        public List<Data.WorkOrderItem> GetWorkOrderInfoOfDepartment(string DepID, WorkType ConType)
        {
            return DAO.WorkOrderViewDAO.GetWorkOrderOfDepartment(DepID, ConType);
        }



    }
}
