using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkLog.Forms;

namespace WorkLog.Manage
{
    class DepartmentMasterManage
    {

        /// <summary>
        /// 部署情報を取得する
        /// </summary>
        public List<Data.DepartmentItem> GetDepartmentInfo()
        {
            return DAO.DepartmentMasterDAO.GetDepartmentInfoList();
        }

        /// <summary>
        /// 部署情報を取得する
        /// </summary>
        /// <param name="ConType">直接 = 0、間接 = 1</param>
        public List<Data.DepartmentItem> GetDepartmentInfoOfConstructType(WorkType ConType)
        {
            return DAO.DepartmentMasterDAO.GetDepartmentInfoListOfConstructType(ConType);
        }


    }
}