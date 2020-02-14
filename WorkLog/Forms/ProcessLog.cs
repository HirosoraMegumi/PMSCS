using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace WorkLog.Forms
{
    public partial class ProcessLog : Form
    {
        private string dataFileName;
        /// <summary>
        /// フォームを初期化する
        /// </summary>
        public ProcessLog(string processSheetDataFileName)
        {
            InitializeComponent();
            this.dataFileName = processSheetDataFileName;
        }

        /// <summary>
        /// フォームのデータをロードする
        /// </summary>
        private void ProcessLog_Load(object sender, EventArgs e)
        {
            loadProcessSheet();
        }

        /// <summary>
        /// 「ok」ボタンをクリックする機能
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 「リロード」ボタンをクリックする機能
        /// </summary>
        private void buttonReload_Click(object sender, EventArgs e)
        {
            loadProcessSheet();
        }
        /// <summary>
        /// 「実施」と「実施＆チェック」ボタンにテスト方法を追加する
        /// </summary>
        /// <param name="e">ボタン情報</param>
        private bool iEvent_Click(mshtml.IHTMLEventObj e)
        {
            MessageBox.Show("test");
            return true;
        }
        /// <summary>
        /// WebBrowserにデータを表示する
        /// </summary>
        private void loadProcessSheet()
        {
            // データベースからコンフィグ情報を取得する
            Manage.ConfigManage configManage = new Manage.ConfigManage();
            List<Data.ConfigItem> configList = configManage.GetConfigInfo();
            Data.ConfigPathItem configPathItem = configManage.SetConfigPathInfo(configList);
            //　データファイルとスタイルファイルのパスを取得する
            string xslFilePath = Path.Combine(configPathItem.StyleBaseDirPath, "pslogview.xsl");

            // XSLTファイルの読み込み
            XsltSettings xsltProp = new XsltSettings();
            xsltProp.EnableDocumentFunction = true;
            XmlResolver xmlResolv = new XmlUrlResolver();

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslFilePath, xsltProp, xmlResolv);

            // HTML変換
            StringBuilder sHtml = new StringBuilder();

            XmlReaderSettings xmlProp = new XmlReaderSettings();
            xmlProp.DtdProcessing = DtdProcessing.Ignore;

            using (XmlReader xmlRead = XmlReader.Create(this.dataFileName, xmlProp))
            {
                using (XmlWriter writer = XmlWriter.Create(sHtml))
                {
                    xslt.Transform(xmlRead, writer);
                }
            }

            //　webBrowserにプロセスシートデータを追加する
            webBrowserProcessSheet.DocumentText = sHtml.ToString();

        }

        /// <summary>
        /// 画面は全部ロードしたら、ボタンイベントを登録する
        /// </summary>
        private void webBrowserProcessSheet_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /*
             * ボタンイベント登録（テスト）
             */
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)webBrowserProcessSheet.Document.DomDocument;
            mshtml.IHTMLElementCollection elemCol = doc.getElementsByTagName("button");

            foreach (mshtml.HTMLButtonElementEvents2_Event btnEvt in elemCol)
            {
                btnEvt.onclick += new mshtml.HTMLButtonElementEvents2_onclickEventHandler(iEvent_Click);
            }
        }
    }
}
