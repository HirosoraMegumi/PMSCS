using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfControlSystem.Data
{
    public class WorkOrderItem
    {
        /// <summary>
        /// 作業オーダーID
        /// </summary>
        public string WorkOrderID { get; set; }

        /// <summary>
        /// 作業名称
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 作業オーダーNo
        /// </summary>
        public string WorkOrderNo { get; set; }

        /// <summary>
        /// 担当部署名
        /// </summary>
        public string ChargeDepartmentName { get; set; }

        /// <summary>
        /// 担当部署ID
        /// </summary>
        public string ChargeDepartmentID { get; set; }

        /// <summary>
        /// 管理部署名
        /// </summary>
        public string AcceptDepartmentName { get; set; }

        /// <summary>
        /// 管理部署ID
        /// </summary>
        public string AcceptDepartmentID { get; set; }

        /// <summary>
        /// 業務種別
        ///  0:直接、1:間接
        /// </summary>
        public Int32 ConstructOrderType{ get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 終了予定日
        /// </summary>
        public DateTime? ScheduleEndDate { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 期
        /// </summary>
        public int Period { get; set; }




    }
}
