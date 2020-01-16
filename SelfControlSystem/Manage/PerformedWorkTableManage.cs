using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfControlSystem.Manage
{
    class PerformedWorkTableManage
    {
        /// <summary>
        /// 対象社員の最新の実施作業情報を取得
        /// </summary>
        /// <param name="EmpID">社員ID</param>
        public Data.PerformedWorkOrderItem GetLatestPerformedWorkInfo(int EmpID)
        {
            return DAO.PerformedWorkTableDAO.GetLatestPerformedWorkInfo(EmpID);
        }

        /// <summary>
        /// 対象実施作業を更新
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public void UpdatePerformedWorkInfo(Data.PerformedWorkOrderItem Item)
        {
            DAO.PerformedWorkTableDAO.UpdatePerformedWorkInfo(Item);
        }

        /// <summary>
        /// 対象実施作業の終了日時を更新
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public void UpdateWorkEndDateOfPerformedWorkInfo(Data.PerformedWorkOrderItem Item, DateTime EndTime)
        {
            DAO.PerformedWorkTableDAO.UpdateWorkEndDateOfPerformedWorkInfo(Item, EndTime);
        }

        /// <summary>
        /// 対象実施作業を追加
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public void AddPerformedWorkInfo(Data.PerformedWorkOrderItem Item)
        {
            DAO.PerformedWorkTableDAO.AddPerformedWorkInfo(Item);
        }

        /// <summary>
        /// 対象社員が対象日に実施した作業を取得
        /// </summary>
        /// <param name="EmpID">社員ID</param>
        /// <param name="TargetDate">対象日</param>
        public List<Data.PerformedWorkOrderItem> GetPerformedWorkList(int EmpID, DateTime Targetdate)
        {
            return DAO.PerformedWorkTableDAO.GetPerformedWorkInfo(EmpID, Targetdate);
        }


    }
}
