using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Data
{
    public class WorkerItem
    {
        /// <summary>
        /// 社員ID
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 社員番号
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 氏名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 所属部署ID
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 所属部署名
        /// </summary>
        public string DepartmentName { get; set; }

    }
}