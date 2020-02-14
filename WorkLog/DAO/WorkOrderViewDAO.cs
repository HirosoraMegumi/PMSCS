using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WorkLog.Forms;

namespace WorkLog.DAO
{
    class WorkOrderViewDAO
    {
        /// <summary>
        /// 現在作業中の作業項目情報を取得する
        /// </summary>
        public static List<Data.WorkOrderItem> GetWorkOrder()
        {
            List<Data.WorkOrderItem> result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectWorkData(connect, null);
                }
                finally
                {
                    connect.Close();
                }
                
            }
            
                return result;
        }

        /// <summary>
        /// 現在作業中の担当部署ごとの作業項目情報を取得する
        /// </summary>
        public static List<Data.WorkOrderItem> GetWorkOrderOfDepartment(string DepID, WorkType ConType)
        {
            List<Data.WorkOrderItem> result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectWorkDataOfDepartment(connect, null, DepID, ConType);
                }
                finally
                {
                    connect.Close();
                }

            }

            return result;
        }



        /// <summary>
        /// 作業項目を取得します(END_DATE がNULLのレコードを取得)
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static List<Data.WorkOrderItem> SelectWorkData(SqlConnection connect, SqlTransaction transaction)
        {
            List<Data.WorkOrderItem> result = new List<Data.WorkOrderItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM WORK_ORDER_VIEW ORDER BY WORK_ORDER_NO DESC";
                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.WorkOrderItem item = ConvevrtRecordToWorkOrderItem(reader);
                        result.Add(item);
                    }
                }

            }
            return result;
        }


        /// <summary>
        /// 作業項目を取得します(END_DATE がNULLのレコードを取得)
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static List<Data.WorkOrderItem> SelectWorkDataOfDepartment(SqlConnection connect, SqlTransaction transaction, string DepID, WorkType ConType)
        {
            List<Data.WorkOrderItem> result = new List<Data.WorkOrderItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM WORK_ORDER_VIEW WHERE ACCEPT_DEPARTMENT_ID = @DEP_ID AND CONSTRUCT_ORDER_TYPE = @CON_TYPE ORDER BY WORK_ORDER_NO DESC";
                cmd.Parameters.Add(new SqlParameter("@DEP_ID", DepID));
                cmd.Parameters.Add(new SqlParameter("@CON_TYPE", ConType));

                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.WorkOrderItem item = ConvevrtRecordToWorkOrderItem(reader);
                        result.Add(item);
                    }
                }

            }
            return result;
        }


        private static Data.WorkOrderItem ConvevrtRecordToWorkOrderItem(SqlDataReader reader)
        {
            Data.WorkOrderItem result = new Data.WorkOrderItem();
            result.WorkOrderID = Convert.ToString(DbUtility.GetValue(reader["WORK_ORDER_ID"]));
            result.WorkOrderNo = Convert.ToString(DbUtility.GetValue(reader["WORK_ORDER_NO"]));
            result.WorkName = Convert.ToString(DbUtility.GetValue(reader["WORK_NAME"]));

            result.ChargeDepartmentName = Convert.ToString(DbUtility.GetValue(reader["CHARGE_DEPARTMENT_NAME"]));
            result.ChargeDepartmentID = Convert.ToString(DbUtility.GetValue(reader["CHARGE_DEPARTMENT_ID"]));

            result.AcceptDepartmentName = Convert.ToString(DbUtility.GetValue(reader["ACCEPT_DEPARTMENT_NAME"]));
            result.AcceptDepartmentID = Convert.ToString(DbUtility.GetValue(reader["ACCEPT_DEPARTMENT_ID"]));
            result.ConstructOrderType = Convert.ToInt32(DbUtility.GetValue(reader["CONSTRUCT_ORDER_TYPE"]));
            result.StartDate = (DateTime?)(DbUtility.GetValue(reader["START_DATE"]));
            result.ScheduleEndDate = (DateTime?)(DbUtility.GetValue(reader["SCHEDULE_END_DATE"]));

            result.EndDate = (DateTime?)(DbUtility.GetValue(reader["END_DATE"]));
            result.Period = Convert.ToInt32(DbUtility.GetValue(reader["PERIOD"]));

            result.ProcessNo = Convert.ToString(DbUtility.GetValue(reader["PROCESS_NO"]));
            result.CustomerName = Convert.ToString(DbUtility.GetValue(reader["CUSTOMER_NAME"]));

            return result;
        }

    }
}
