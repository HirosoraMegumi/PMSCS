using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace WorkLog.DAO
{
    class ConfigDAO
    {
        /// <summary>
        /// コンフィグ情報（テンプレート/データ/スタイルファイルパス）を取得する
        /// </summary>
        public static List<Data.ConfigItem> GetConfigPathList()
        {
            List<Data.ConfigItem> result;
            using (SqlConnection connect = new SqlConnection(Utils.ApplicationSettings.DBConnectionString))
            {
                connect.Open();
                // コンフィグ情報取得
                result = SelectConfigPathData(connect, null);
            }
            return result;
        }

        /// <summary>
        /// コンフィグ情報を取得します
        /// </summary>
        /// <param name="connect">データベース接続</param>
        /// <param name="transaction">トランザクション</param>
        private static List<Data.ConfigItem> SelectConfigPathData(SqlConnection connect, SqlTransaction transaction)
        {
            List<Data.ConfigItem> result = new List<Data.ConfigItem>();
            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT * FROM T_CONFIG";
                cmd.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Data.ConfigItem item = ConvertRecordToConfigItem(reader);
                        result.Add(item);
                    }
                }
            }
            return result;
        }
        
        private static Data.ConfigItem ConvertRecordToConfigItem(SqlDataReader reader)
        {
            Data.ConfigItem result = new Data.ConfigItem();
            result.PathName = Convert.ToString(DbUtility.GetValue(reader["NAME"]));
            result.PathValue = Convert.ToString(DbUtility.GetValue(reader["VALUE"]));

            return result;
        }
    }
}
