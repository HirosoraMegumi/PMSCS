using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Data
{
    public class TempWorkOrderItem
    {
        /// <summary>
        /// 社員ID
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 一時作業オーダーID
        /// </summary>
        public string WorkOrderID { get; set; }

        /// <summary>
        /// 一時作業名称
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 一時作業オーダーNo
        /// </summary>
        public string WorkOrderNo { get; set; }
    }
}
