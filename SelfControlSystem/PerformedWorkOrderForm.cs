using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfControlSystem
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
            this.performedWorkOrderGridView.SetWorkData();
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
