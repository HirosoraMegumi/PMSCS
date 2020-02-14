using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog.Manage
{
    class ConfigManage
    {
        public List<Data.ConfigItem> GetConfigInfo()
        {
            return DAO.ConfigDAO.GetConfigPathList();
        }
        /// <summary>
        /// 「T_Config」テーブルからコンフィグ情報をオブジェクトに追加する
        /// </summary>
        /// <param name="configItemList">「T_Config」テーブルから取得した情報</param>
        public Data.ConfigPathItem SetConfigPathInfo(List<Data.ConfigItem> configItemList)
        {
            Data.ConfigPathItem configPathItem = new Data.ConfigPathItem();
            foreach (Data.ConfigItem item in configItemList)
            {
                if (item.PathName.Equals("DATA_BASE_DIR_PATH"))
                {
                    // データファイルパス
                    configPathItem.DataBaseDirPath = item.PathValue;
                }
                else if (item.PathName.Equals("STYLE_BASE_DIR_PATH"))
                {
                    // スタイルファイルパス
                    configPathItem.StyleBaseDirPath = item.PathValue;
                }
                else if (item.PathName.Equals("TEMPLATE_BASE_DIR_PATH"))
                {
                    //　テンプレートファイルパス
                    configPathItem.TemplateBaseDirPath = item.PathValue;
                }
            }
            return configPathItem;
        }
    }
}
