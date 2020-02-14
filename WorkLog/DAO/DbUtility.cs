using System;
using System.Data;

namespace WorkLog.DAO
{
    class DbUtility
    {
        /// <summary>
        /// 指定した引数が DBNull かどうかチェックします。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetValue(object value)
        {
            if (Convert.IsDBNull(value))
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 文字列型を、データベースで使用できるデータ型(<see cref="Object">Object</see>)に変換します。
        /// 空文字列は <see cref="DBNull">DBNull</see> に変換します。
        /// </summary>
        /// <param name="str">変換する値</param>
        /// <returns><see cref="Object">Object</see></returns>
        /// <remarks>
        /// データベースのクエリパラメータの値を設定するときに使用します。
        /// </remarks>
        public static object ConvertStringToDbType(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Convert.DBNull;
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 日付型を、データベースで使用できるデータ型(<see cref="Object">Object</see>)に変換します。
        /// nullは <see cref="DBNull">DBNull</see> に変換します。
        /// </summary>
        /// <param name="str">変換する値</param>
        /// <returns><see cref="Object">Object</see></returns>
        /// <remarks>
        /// データベースのクエリパラメータの値を設定するときに使用します。
        /// </remarks>
        public static object ConvertDateTimeToDbType(DateTime? Item)
        {
            if (Item.HasValue == false)
            {
                return Convert.DBNull;
            }
            else
            {
                return Item.Value;
            }
        }

    }
}
