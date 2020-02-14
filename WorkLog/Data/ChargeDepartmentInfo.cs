using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Data
{


    /// <summary>
    /// 担当部署情報
    /// </summary>
    class ChargeDepartmentInfo : DepartmentItem
    {

        /// <summary>
        /// 作業一覧
        /// </summary>
        public List<Data.WorkOrderItem> WorkOrderList { get; set; }

        public ChargeDepartmentInfo(DepartmentItem Item)
        {
            this.DepartmentID = Item.DepartmentID;
            this.DepartmentName = Item.DepartmentName;
            this.DepartmentFullName = Item.DepartmentFullName;

        }
    }
}
