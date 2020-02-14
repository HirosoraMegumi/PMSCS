using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkLog.Forms
{
    public partial class TempWorkOrderForm : Form
    {
        public TempWorkOrderForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 一時作業情報
        /// </summary>
        private Data.TempWorkOrderItem _tempWorkOrderItem = new Data.TempWorkOrderItem();


        public Data.TempWorkOrderItem TempWorkOrderItem
        {
            get
            {
                return _tempWorkOrderItem;
            }
        }
        /// <summary>
        /// OKボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbTempWork.Text.Trim() == "")
                {
                    MessageBox.Show("作業名称を入力してください");
                }
                else
                {
                    _tempWorkOrderItem.WorkName = this.tbTempWork.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// キャンセルボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
