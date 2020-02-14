using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorkLog.Forms;

namespace WorkLog.DAO
{
    class DepartmentMasterDAO
    {
        /// <summary>
        /// 部署情報を取得する
        /// </summary>
        public static List<Data.DepartmentItem> GetDepartmentInfoList()
        {
            List<Data.DepartmentItem> result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectDepartmentData(connect, null);
                }
                finally
                {
                    connect.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 直接/間接作業を扱う部署情報を取得する
        /// </summary>
        public static List<Data.DepartmentItem> GetDepartmentInfoListOfConstructType(WorkType ConType)
        {
            List<Data.DepartmentItem> result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectDepartmentDataOfConstructType(connect, null, ConType);
                }
                finally
                {
                    connect.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 部署情報を取得します
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static List<Data.DepartmentItem> SelectDepartmentData(SqlConnection connect, SqlTransaction transaction)
        {
            List<Data.DepartmentItem> result = new List<Data.DepartmentItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM DEPARTMENT_MASTER WHERE DELETE_FLAG = 0";
                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.DepartmentItem item = ConvevrtRecordToDepartmentItem(reader);
                        result.Add(item);
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// 直接/間接作業を扱う部署情報を取得します
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="ConType">直接 = 0、間接 = 1</param>
        private static List<Data.DepartmentItem> SelectDepartmentDataOfConstructType(SqlConnection connect, SqlTransaction transaction, WorkType ConType)
        {
            List<Data.DepartmentItem> result = new List<Data.DepartmentItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.Transaction = transaction;
                if(ConType == 0)
                {
                    cmd.CommandText = "SELECT * FROM DEPARTMENT_MASTER WHERE DELETE_FLAG = 0 AND USE_DIRECT_CONSTRUCT_ORDER = 1";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM DEPARTMENT_MASTER WHERE DELETE_FLAG = 0 AND USE_INDIRECT_CONSTRUCT_ORDER = 1";
                }
                
                cmd.CommandType = System.Data.CommandType.Text;


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.DepartmentItem item = ConvevrtRecordToDepartmentItem(reader);
                        result.Add(item);
                    }
                }

            }
            return result;
        }


        private static Data.DepartmentItem ConvevrtRecordToDepartmentItem(SqlDataReader reader)
        {
            Data.DepartmentItem result = new Data.DepartmentItem();
            result.DepartmentID = Convert.ToString(DbUtility.GetValue(reader["DEPARTMENT_ID"]));
            result.DepartmentName = Convert.ToString(DbUtility.GetValue(reader["DEPARTMENT_NAME"]));
            result.DepartmentFullName = Convert.ToString(DbUtility.GetValue(reader["DEPARTMENT_FULL_NAME"]));

            return result;
        }




    }
}
