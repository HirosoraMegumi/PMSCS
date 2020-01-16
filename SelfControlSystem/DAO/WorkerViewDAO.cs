using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SelfControlSystem.DAO
{
    class WorkerViewDAO
    {
        /// <summary>
        /// ユーザーの社員情報を取得する
        /// </summary>
        public static Data.WorkerItem GetWorkerInfo(string LoginID)
        {
            Data.WorkerItem result;
            using (SqlConnection connect = new SqlConnection(SelfControlSystem.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectWorkerInfo(connect, null, LoginID);
                }
                finally
                {
                    connect.Close();
                }

            }

            return result;
        }

        /// <summary>
        /// 社員情報を取得します
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static Data.WorkerItem SelectWorkerInfo(SqlConnection connect, SqlTransaction transaction, string LoginID)
        {
            Data.WorkerItem result = null;
            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM WORKER_VIEW WHERE LOGIN_ID = @LOGIN_ID";
                cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", LoginID));

                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = ConvevrtRecordToWorkerItem(reader);
                    }
                }

            }
            return result;
        }



        private static Data.WorkerItem ConvevrtRecordToWorkerItem(SqlDataReader reader)
        {
            Data.WorkerItem result = new Data.WorkerItem();

            result.EmpID = Convert.ToInt32(DbUtility.GetValue(reader["EMP_ID"]));
            result.EmpNo = Convert.ToString(DbUtility.GetValue(reader["EMP_NO"]));
            result.EmpName = Convert.ToString(DbUtility.GetValue(reader["EMP_NAME"]));
            result.DepartmentID = Convert.ToString(DbUtility.GetValue(reader["DEPARTMENT_ID"]));
            result.DepartmentName = Convert.ToString(DbUtility.GetValue(reader["DEPARTMENT_NAME"]));


            return result;
        }

    }
}
