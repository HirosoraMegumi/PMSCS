using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace WorkLog.DAO
{
    class AdjustmentWorkResultTableDAO
    {

        /// <summary>
        /// 対象実施作業を追加
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public static void AddAdjustmentWorkInfo(Data.PerformedWorkOrderItem Item)
        {

            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    AddAdjustmentWorkInfo(connect, null, Item);
                }
                finally
                {
                    connect.Close();
                }

            }

        }

 
        /// <summary>
        /// 対象実施作業を追加
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="Item">対象実施作業</param>
        private static void AddAdjustmentWorkInfo(SqlConnection connect, SqlTransaction transaction, Data.PerformedWorkOrderItem Item)
        {

            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO dbo.T_ADJUSTMENT_WORK_ORDER(EMP_ID, ADJUSTMENT_DATE, ADJUSTMENT_WORK_ORDER_ID, WORK_ORDER_ID, WORK_START_DT, WORK_END_DT) " +
                                    "VALUES (@EMP_ID, @ADJUSTMENT_DATE, @ADJUSTMENT_WORK_ORDER_ID, @WORK_ORDER_ID, @WORK_START_DT, @WORK_END_DT)";

                cmd.Parameters.Add(new SqlParameter("@ADJUSTMENT_WORK_ORDER_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@ADJUSTMENT_DATE", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@WORK_ORDER_ID", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@WORK_START_DT", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@WORK_END_DT", SqlDbType.DateTime));

                cmd.Parameters["@ADJUSTMENT_WORK_ORDER_ID"].Value = Convert.ToInt32(Item.PerformedWorkOrderID);
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(Item.EmpID);
                cmd.Parameters["@ADJUSTMENT_DATE"].Value = Item.PerformedDate.Date;
                cmd.Parameters["@WORK_ORDER_ID"].Value = DbUtility.ConvertStringToDbType(Item.WorkOrderID);
                cmd.Parameters["@WORK_START_DT"].Value = DbUtility.ConvertDateTimeToDbType(Item.WorkStartDateTime);
                cmd.Parameters["@WORK_END_DT"].Value = DbUtility.ConvertDateTimeToDbType(Item.WorkEndDateTime);


                cmd.CommandType = System.Data.CommandType.Text;

                var result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + "行追加されました。");

            }

        }

    }
}
