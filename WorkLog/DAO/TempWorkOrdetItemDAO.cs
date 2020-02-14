using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WorkLog.Forms;

namespace WorkLog.DAO
{
    class TempWorkOrdetItemDAO
    {
        /// <summary>
        /// 一時作業情報を追加
        /// </summary>
        /// <param name="connect"></param>
        /// <param name="transaction"></param>
        /// <param name="Item"></param>
        private static void AddTempWorkOrderItem(SqlConnection connect, SqlTransaction transaction, Data.TempWorkOrderItem Item)
        {

            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO dbo.T_TEMP_WORK_ORDER(EMP_ID, TEMP_WORK_ORDER_ID, TEMP_WORK_ORDER_NO, TEMP_WORK_NAME) " +
                                    "VALUES (@EMP_ID, newid(), @TEMP_WORK_ORDER_NO, @TEMP_WORK_NAME )";

                
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@TEMP_WORK_ORDER_NO", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@TEMP_WORK_NAME", SqlDbType.Char));

                cmd.Parameters["@TEMP_WORK_ORDER_NO"].Value = DbUtility.ConvertStringToDbType(Item.WorkOrderNo);
                cmd.Parameters["@TEMP_WORK_NAME"].Value = DbUtility.ConvertStringToDbType(Item.WorkName);
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(Item.EmpID);


                cmd.CommandType = System.Data.CommandType.Text;

                var result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + "行追加されました。");

            }

        }
        /// <summary>
        /// 一時作業情報を追加
        /// </summary>
        /// <param name="Item"></param>
        public static void AddTempWorkOrderItemInfo(Data.TempWorkOrderItem Item)
        {

            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    AddTempWorkOrderItem(connect, null, Item);
                }
                finally
                {
                    connect.Close();
                }

            }

        }



        /// <summary>
        /// 一時の作業情報を取得する
        /// </summary>
        public static List<Data.TempWorkOrderItem> GetTempWorkOrder(int EmpID)
            {
                List<Data.TempWorkOrderItem> result;
                using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
                {
                    connect.Open();
                    try
                    {
                        // 一時作業項目取得
                        result = SelectWorkData(connect, null, EmpID);
                    }
                    finally
                    {
                        connect.Close();
                    }

                }

                return result;
            }



        /// <summary>
        /// 一時作業情報を取得します
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static List<Data.TempWorkOrderItem> SelectWorkData(SqlConnection connect, SqlTransaction transaction, int EmpID)
        {
            List<Data.TempWorkOrderItem> result = new List<Data.TempWorkOrderItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM T_TEMP_WORK_ORDER WHERE EMP_ID = @EMP_ID ORDER BY TEMP_WORK_ORDER_NO";

                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(EmpID);
                
                cmd.CommandType = System.Data.CommandType.Text;



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.TempWorkOrderItem item = ConvevrtRecordToTempWorkOrderItem(reader);
                        result.Add(item);
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// 一時作業情報をデータベースで使用できるデータ型(<see cref="Object">Object</see>)に変換します。
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Data.TempWorkOrderItem ConvevrtRecordToTempWorkOrderItem(SqlDataReader reader)
        {
            Data.TempWorkOrderItem result = new Data.TempWorkOrderItem();
            result.WorkOrderID = Convert.ToString(DbUtility.GetValue(reader["TEMP_WORK_ORDER_ID"]));
            result.WorkOrderNo = Convert.ToString(DbUtility.GetValue(reader["TEMP_WORK_ORDER_NO"]));
            result.WorkName = Convert.ToString(DbUtility.GetValue(reader["TEMP_WORK_NAME"]));

            return result;
        }

    }
}
