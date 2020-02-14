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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace WorkLog.Forms
{
    public partial class PerformedWorkOrderForm : Form
    {

        /// <summary>
        /// ユーザーの社員情報
        /// </summary>
        private Data.WorkerItem _UserInfo;

        /// <summary>
        /// 実施日
        /// </summary>
        private DateTime _TagertDate;

        public PerformedWorkOrderForm(Data.WorkerItem UserInfo, DateTime TagertDate)
        {
            InitializeComponent();

            this._UserInfo = UserInfo;
            this._TagertDate = TagertDate;

            
        }

        /// <summary>
        /// フォーム: ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerformedWorkOrderForm_Load(object sender, EventArgs e)
        {
            Manage.PerformedWorkTableManage pm = new Manage.PerformedWorkTableManage();
            List<Data.PerformedWorkOrderItem> PerformedWorkList = pm.GetPerformedWorkList(this._UserInfo.EmpID, this._TagertDate);

            // 実施作業表示
            this.performedWorkOrderGridView.SetPerformedWorkList(PerformedWorkList, this._UserInfo, this._TagertDate);
            

        }


        /// <summary>
        /// 完了ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (this.performedWorkOrderGridView.CheckEmptyRow())
            {
                MessageBox.Show("記録なしの行が存在します！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.performedWorkOrderGridView.SetWorkData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// キャンセルボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string sText = string.Format("編集したデータは保存されません。よろしいですか？");

            if (MessageBox.Show(sText, this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

        }

        /// <summary>
        /// 作業時間変更: イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void performedWorkOrderGridView_ChangePerformedWork(object sender, EventArgs e)
        {
            this.tbSumWorkTime.Text = Convert.ToString(this.performedWorkOrderGridView.TotalWorkTime);
            this.tbStartTime.Text = Convert.ToString(this.performedWorkOrderGridView.StartDayWorkTime.ToShortTimeString());
            this.tbEndTime.Text = Convert.ToString(this.performedWorkOrderGridView.EndDayWorkTime.ToShortTimeString());
            this.tbOverWorkTime.Text = Convert.ToString(Math.Round(this.performedWorkOrderGridView.OverWorkTime,1));
        }

        private void performedWorkOrderGridView_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// outputボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void output_Click(object sender, EventArgs e)
        {
            //ここで作業管理表の選択機能とデータを自動的入力する機能を実現する。
            //正式の作業管理表のサンプルがない、ここでは不正式のサンプルを使用します。
            //下の定数は一時的に使用します。

            //個人表内勤務日開始行数
            int workDateStartRow = 7;

            int todayRow = DateTime.Now.Day + workDateStartRow;

            //"G業務管理"表内管理番号記録の開始行数
            int directWorkNoStartRow = 4;

            //"G間接管理"表内管理番号記録の開始行数
            int indirectWorkNoStartRow = 4;

            //"G業務管理"表内管理番号記録の列数
            int directWorkNoColumn = 7;

            //"G間接管理"表内管理番号記録の列数
            int indirectWorkNoColumn = 6;

            //"G業務管理"表内作業名記録の列数
            int directWorkNameColumn = 3;

            //"G間接管理"表内作業名記録の列数
            int indirectWorkNameColumn = 3;

            //個人表内直接作業時間記録の開始列数
            int directWorkStartColumn = 31;

            //個人表内間接作業時間記録の開始列数
            int indirectWorkStartColumn = 85;

            //個人表内間接作業時間記録の終了列数
            int indirectWorkEndColumn = 135;

            //作業管理表内の作業名
            string workNameInBook = null;

            //ファイル選択画面を出す
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(fileDialog.FileName);
                
                string[] str = new string[] { ".xls", ".xlsx" };
                if (!str.Contains(extension))
                {
                    MessageBox.Show("Excelファイルを選択してください！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                    //選択したExcelファイルを操作する
                    Microsoft.Office.Interop.Excel.Application xApp = new Excel.Application();

                    xApp.Visible = true;

                    Excel.Workbook xBook = xApp.Workbooks.Open(fileInfo.FullName);

                    Excel.Worksheet xSheet = new Excel.Worksheet();

                    //社員番号の存在性チェック
                    bool idNotExist = true;

                    foreach (Excel.Worksheet item in xBook.Worksheets)
                    {
                        //Cells[3,7]は個人表内社員番号の場所。
                        if (item.Cells[3, 7].Text == Convert.ToString(this._UserInfo.EmpID))
                        {
                            xSheet = item;

                            xSheet.Cells[todayRow, 2].Value = this.performedWorkOrderGridView.StartDayWorkTime.ToShortTimeString().ToString();
                            for (int a = 0; a < this.performedWorkOrderGridView._PerformedWorkList.Count; a++)
                            {
                                Data.WorkOrderItem workInProcess = this.performedWorkOrderGridView._PerformedWorkList[a].WorkOrderInfo;

                                //作業の業務種別を判断します。
                                if (workInProcess.ConstructOrderType == 0)
                                {
                                    Excel.Worksheet directWorkSheet = xBook.Worksheets.get_Item("G業務管理");

                                    //業務表内最後の管理番号記録の行数
                                    int directWorkNoEndRow = directWorkSheet.Cells[directWorkSheet.Rows.Count,directWorkNoColumn].End(Excel.XlDirection.xlUp).Row;

                                    if (directWorkNoEndRow < directWorkNoStartRow)
                                    {
                                        string sText = string.Format("G業務管理表内管理番号{0}が存在しません。", workInProcess.WorkOrderNo);
                                        MessageBox.Show(sText, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }

                                    //業務表内作業の存在性チェック
                                    bool workNoExist = false;

                                    for (int b = directWorkNoStartRow;b < (directWorkNoEndRow+1);b++)
                                    {
                                        if (directWorkSheet.Cells[b,directWorkNoColumn].Text == workInProcess.WorkOrderNo)
                                        {
                                            workNameInBook = directWorkSheet.Cells[b,directWorkNameColumn].Text;
                                            workNoExist = true;
                                        }
                                    }

                                    if (!workNoExist)
                                    {
                                        string sText = string.Format("G業務管理表内管理番号{0}が存在しません。", workInProcess.WorkOrderNo);
                                        MessageBox.Show(sText, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }

                                    //個人表内作業の存在性チェック
                                    bool workOrderExist = false;

                                    for (int c = directWorkStartColumn; c < indirectWorkStartColumn; c++)
                                    {
                                        if (xSheet.Cells[3, c].Text == workNameInBook)
                                        {
                                            xSheet.Cells[todayRow, c].Value += this.performedWorkOrderGridView._PerformedWorkList[a].ConvertWorkTime;
                                            workOrderExist = true;
                                            Console.WriteLine(workNameInBook);
                                            break;
                                        }
                                    }

                                    if (!workOrderExist)
                                    {
                                        for (int d = directWorkStartColumn; d < indirectWorkStartColumn; d++)
                                        {
                                            if (xSheet.Cells[3, d].Text == "")
                                            {
                                                xSheet.Cells[3, d].Value = workNameInBook;
                                                xSheet.Cells[todayRow, d].Value = this.performedWorkOrderGridView._PerformedWorkList[a].ConvertWorkTime;
                                                Console.WriteLine(workNameInBook);
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Excel.Worksheet indirectWorkSheet = xBook.Worksheets.get_Item("G間接管理");

                                    //業務表内最後の管理番号記録の行数
                                    int indirectWorkNoEndRow = indirectWorkSheet.Cells[indirectWorkSheet.Rows.Count, indirectWorkNoColumn].End(Excel.XlDirection.xlUp).Row;

                                    if (indirectWorkNoEndRow < indirectWorkNoStartRow)
                                    {
                                        string sText = string.Format("G間接管理表内管理番号{0}が存在しません。", workInProcess.WorkOrderNo);
                                        MessageBox.Show(sText, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }

                                    //業務表内作業の存在性チェック
                                    bool workNoExist = false;

                                    for (int b = indirectWorkNoStartRow; b < (indirectWorkNoEndRow + 1); b++)
                                    {
                                        if (indirectWorkSheet.Cells[b, indirectWorkNoColumn].Text == workInProcess.WorkOrderNo)
                                        {
                                            workNameInBook = indirectWorkSheet.Cells[b, indirectWorkNameColumn].Text;
                                            workNoExist = true;
                                        }
                                    }

                                    if (!workNoExist)
                                    {
                                        string sText = string.Format("G間接管理表内管理番号{0}が存在しません。", workInProcess.WorkOrderNo);
                                        MessageBox.Show(sText, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    }

                                    //個人表内作業の存在性チェック
                                    bool workOrderExist = false;

                                    for (int c = indirectWorkStartColumn; c < indirectWorkEndColumn; c++)
                                    {
                                        if (xSheet.Cells[3, c].Text == workNameInBook)
                                        {
                                            xSheet.Cells[todayRow, c].Value += this.performedWorkOrderGridView._PerformedWorkList[a].ConvertWorkTime;
                                            workOrderExist = true;
                                            break;
                                        }
                                    }

                                    if (!workOrderExist)
                                    {
                                        for (int d = indirectWorkStartColumn; d < indirectWorkEndColumn; d++)
                                        {
                                            if (xSheet.Cells[3, d].Text == "")
                                            {
                                                xSheet.Cells[3, d].Value = workNameInBook;
                                                xSheet.Cells[todayRow, d].Value = this.performedWorkOrderGridView._PerformedWorkList[a].ConvertWorkTime;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            xBook.Save();

                            xSheet = null;
                            xBook = null;
                            xApp.Quit();
                            xApp = null;

                            idNotExist = false;
                        }
                    }
                    
                    if (idNotExist)
                    {
                        MessageBox.Show("社員番号が存在しません。確認してください！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        xSheet = null;
                        xBook = null;
                        xApp.Quit();
                        xApp = null;
                    }
                }
            }
        }
    }
}
