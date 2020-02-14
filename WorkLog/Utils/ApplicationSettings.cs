using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Utils
{
    class ApplicationSettings
    {
        /// <summary>
        /// ワークログシステムのデータベースの接続文字列
        /// </summary>
        public static string DBConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["WorkLogSystemDatabase"].ConnectionString;
            }
        }

        /// <summary>
        /// プロセスシートテンプレートが保存されているフォルダのフルパス
        /// </summary>
        public static string ProcessSheetTemplateDirPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ProcessSheetTemplateDirPath"];
            }
        }

        /// <summary>
        /// プロセスシートの保存先フォルダのフルパス
        /// </summary>
        public static string ProcessSheetStoreDirPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ProcessSheetStoreDirPath"];
            }
        }


    }
}
