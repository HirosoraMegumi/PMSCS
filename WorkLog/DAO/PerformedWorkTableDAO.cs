using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace WorkLog.DAO
{
    class PerformedWorkTableDAO
    {
        /// <summary>
        /// 対象社員の最新の実施作業情報を取得
        /// </summary>
        /// <param name="EmpID">社員ID</param>
        public static Data.PerformedWorkOrderItem GetLatestPerformedWorkInfo(int EmpID)
        {
            Data.PerformedWorkOrderItem result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = SelectLatestPerformedWorkInfo(connect, null, EmpID);
                }
                finally
                {
                    connect.Close();
                }

            }

            return result;
        }

        /// <summary>
        /// 対象実施作業を更新
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public static void UpdatePerformedWorkInfo(Data.PerformedWorkOrderItem Item)
        {
            
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    UpdatePerformedWork(connect, null, Item);
                }
                finally
                {
                    connect.Close();
                }

            }

        }

        /// <summary>
        /// 対象実施作業を更新
        /// </summary>
        /// <param name="Item">対象実施作業</param>
        public static void UpdateWorkEndDateOfPerformedWorkInfo(Data.PerformedWorkOrderItem Item, DateTime EndTime)
        {

            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    UpdatePerformedWork(connect, null, Item, EndTime);
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
        /// <param name="Item">対象実施作業</param>
        public static void AddPerformedWorkInfo(Data.PerformedWorkOrderItem Item)
        {

            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    AddPerformedWorkInfo(connect, null, Item);
                }
                finally
                {
                    connect.Close();
                }

            }

        }

        /// <summary>
        /// 対象社員が対象日実施した作業を取得
        /// </summary>
        /// <param name="EmpID">対象社員</param>
        /// <param name="TargetDate">対象日</param>
        public static List<Data.PerformedWorkOrderItem> GetPerformedWorkInfo(int EmpID, DateTime TargetDate)
        {
            List<Data.PerformedWorkOrderItem> result;
            using (SqlConnection connect = new SqlConnection(WorkLog.Properties.Settings.Default.ConnectionString))
            {
                connect.Open();
                try
                {
                    // 作業項目取得
                    result = GetPerformedWorkInfo(connect, null, EmpID, TargetDate);
                }
                finally
                {
                    connect.Close();
                }

            }

            return result;
        }

        /// <summary>
        /// 最新の実施作業情報を取得
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="EmpID">社員ID</param>
        private static Data.PerformedWorkOrderItem SelectLatestPerformedWorkInfo(SqlConnection connect, SqlTransaction transaction, int EmpID)
        {
            Data.PerformedWorkOrderItem result = null;
            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM dbo.T_PERFORMED_WORK_ORDER WHERE WORK_START_DT IN( " +
                                        "SELECT MAX(WORK_START_DT) FROM dbo.T_PERFORMED_WORK_ORDER WHERE EMP_ID = @EMP_ID)";

                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(EmpID);

                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = ConvevrtRecordToPerformedWorkerItem(reader);
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// 対象実施作業を更新
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="Item">対象実施作業</param>
        private static void UpdatePerformedWork(SqlConnection connect, SqlTransaction transaction, Data.PerformedWorkOrderItem Item)
        {

            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "UPDATE dbo.T_PERFORMED_WORK_ORDER " +
                                    "SET WORK_ORDER_ID = @WORK_ORDER_ID " +
                                    "WHERE PERFORMED_WORK_ORDER_ID = @PERFORMED_WORK_ID AND EMP_ID = @EMP_ID AND PERFORMED_DATE = @PERFORMED_DATE";

                cmd.Parameters.Add(new SqlParameter("@WORK_ORDER_ID", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_WORK_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_DATE", SqlDbType.Date));

                cmd.Parameters["@WORK_ORDER_ID"].Value = DbUtility.ConvertStringToDbType(Item.WorkOrderID);
                cmd.Parameters["@PERFORMED_WORK_ID"].Value = Convert.ToInt32(Item.PerformedWorkOrderID);
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(Item.EmpID);
                cmd.Parameters["@PERFORMED_DATE"].Value = Item.PerformedDate.Date;

                cmd.CommandType = System.Data.CommandType.Text;

                var result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + "行更新されました。");

            }

        }


        /// <summary>
        /// 対象実施作業の終了日時を更新
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="Item">対象実施作業</param>
        private static void UpdatePerformedWork(SqlConnection connect, SqlTransaction transaction, Data.PerformedWorkOrderItem Item, DateTime EndTime)
        {

            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "UPDATE dbo.T_PERFORMED_WORK_ORDER " +
                                    "SET WORK_END_DT = @WORK_END_DT " +
                                    "WHERE EMP_ID = @EMP_ID AND PERFORMED_DATE = @PERFORMED_DATE AND PERFORMED_WORK_ORDER_ID = @PERFORMED_WORK_ID";

                cmd.Parameters.Add(new SqlParameter("@WORK_END_DT", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_WORK_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_DATE", SqlDbType.Date));

                cmd.Parameters["@WORK_END_DT"].Value = EndTime;
                cmd.Parameters["@PERFORMED_WORK_ID"].Value = Convert.ToInt32(Item.PerformedWorkOrderID);
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(Item.EmpID);
                cmd.Parameters["@PERFORMED_DATE"].Value = Item.PerformedDate.Date;

                cmd.CommandType = System.Data.CommandType.Text;

                var result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + "行更新されました。");

            }

        }

        /// <summary>
        /// 対象実施作業を追加
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="Item">対象実施作業</param>
        private static void AddPerformedWorkInfo(SqlConnection connect, SqlTransaction transaction, Data.PerformedWorkOrderItem Item)
        {

            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO dbo.T_PERFORMED_WORK_ORDER(EMP_ID, PERFORMED_DATE, PERFORMED_WORK_ORDER_ID, WORK_ORDER_ID, WORK_START_DT, WORK_END_DT) " +
                                    "VALUES (@EMP_ID, @PERFORMED_DATE, @PERFORMED_WORK_ORDER_ID, @WORK_ORDER_ID, @WORK_START_DT, @WORK_END_DT)";

                cmd.Parameters.Add(new SqlParameter("@PERFORMED_WORK_ORDER_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_DATE", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@WORK_ORDER_ID", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@WORK_START_DT", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@WORK_END_DT", SqlDbType.DateTime));

                cmd.Parameters["@PERFORMED_WORK_ORDER_ID"].Value = Convert.ToInt32(Item.PerformedWorkOrderID);
                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(Item.EmpID);
                cmd.Parameters["@PERFORMED_DATE"].Value = Item.PerformedDate.Date;
                cmd.Parameters["@WORK_ORDER_ID"].Value = DbUtility.ConvertStringToDbType(Item.WorkOrderID);
                cmd.Parameters["@WORK_START_DT"].Value = DbUtility.ConvertDateTimeToDbType(Item.WorkStartDateTime);
                cmd.Parameters["@WORK_END_DT"].Value = DbUtility.ConvertDateTimeToDbType(Item.WorkEndDateTime);


                cmd.CommandType = System.Data.CommandType.Text;

                var result = cmd.ExecuteNonQuery();

                Console.WriteLine(result + "行追加されました。");

            }

        }

        /// <summary>
        /// 対象社員が対象日実施した作業を取得
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        /// <param name="EmpID">対象社員</param>
        /// <param name="TargetDate">対象日</param>
        private static List<Data.PerformedWorkOrderItem> GetPerformedWorkInfo(SqlConnection connect, SqlTransaction transaction, int EmpID, DateTime TargetDate)
        {
            List<Data.PerformedWorkOrderItem> result = new List<Data.PerformedWorkOrderItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {

                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM dbo.T_PERFORMED_WORK_ORDER WHERE EMP_ID = @EMP_ID AND PERFORMED_DATE = @PERFORMED_DATE";

                cmd.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@PERFORMED_DATE", SqlDbType.Date));

                cmd.Parameters["@EMP_ID"].Value = Convert.ToInt32(EmpID);
                cmd.Parameters["@PERFORMED_DATE"].Value = TargetDate.Date;

                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.PerformedWorkOrderItem item = ConvevrtRecordToPerformedWorkerItem(reader);
                        result.Add(item);
                    }
                }

           
            }
            return result;
        }



        private static Data.PerformedWorkOrderItem ConvevrtRecordToPerformedWorkerItem(SqlDataReader reader)
        {
            Data.PerformedWorkOrderItem result = new Data.PerformedWorkOrderItem();

            result.PerformedWorkOrderID = Convert.ToInt32(DbUtility.GetValue(reader["PERFORMED_WORK_ORDER_ID"]));
            result.EmpID = Convert.ToInt32(DbUtility.GetValue(reader["EMP_ID"]));
            result.PerformedDate = (DateTime)(DbUtility.GetValue(reader["PERFORMED_DATE"]));
            result.WorkOrderID = Convert.ToString(DbUtility.GetValue(reader["WORK_ORDER_ID"]));
            result.WorkStartDateTime = (DateTime)(DbUtility.GetValue(reader["WORK_START_DT"]));
            result.WorkEndDateTime = (DateTime?)(DbUtility.GetValue(reader["WORK_END_DT"]));


            return result;
        }
    }
}
