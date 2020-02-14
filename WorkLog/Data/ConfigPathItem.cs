using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Data
{
    class ConfigPathItem
    {
        /// <summary>
        /// テンプレートファイルパス
        /// </summary>
        public string TemplateBaseDirPath { get; set; }

        /// <summary>
        /// データファイルパス
        /// </summary>
        public string DataBaseDirPath { get; set; }

        /// <summary>
        /// スタイルファイルパス
        /// </summary>
        public string StyleBaseDirPath { get; set; }
    }
}
