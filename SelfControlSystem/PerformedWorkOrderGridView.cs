using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SelfControlSystem
{

    public partial class PerformedWorkOrderGridView : UserControl
    {

        // 作業管理表に付けることができる作業時間単位
        private double WORK_TIME_UNIT = 0.05;

        // 0.05時間あたりの高さ
        private float WORK_HEIGHT_UNIT = 4;

        private List<Data.PerformedWorkOrderItem> _PerformedWorkList = null;
        private Data.WorkerItem _UserInfo = null;

        #region 公開しているプロパティ/メソッド


        /// <summary>
        /// 作業日
        /// (10/29 10:00～10/30 01:00 
        /// 　作業時間が上記の場合、作業日は「10/29」)
        /// </summary>
        public DateTime _WorkDate;

        /// <summary>
        /// 実施済み作業リスト取得
        /// </summary>
        public List<Data.PerformedWorkOrderItem> GetPerformedWorkList
        {
            get
            {
                // グリッドビューから調整した実施作業リストを取得
                return GetPerformedWorkNum();
            }
        }

        /// <summary>
        /// 実施作業の合計時間
        /// </summary>
        public float TotalWorkTime
        {
            get
            {
                return GetTotalWorkTime();
            }
        }

        /// <summary>
        /// 一日の作業開始日時
        /// </summary>
        public DateTime StartDayWorkTime
        {
            get
            {
                //グリッドの行数を取得
                int nGridRowCount = this.dataGridPerformedWorkOrder.Rows.Count;

                DateTime result = new DateTime();

                //行数が1行以上の時
                if (nGridRowCount >= 1)
                {
                    //1行目の値を取得
                    Data.PerformedWorkOrderItem StartWorkItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[0].Tag;
                    result = StartWorkItem.WorkStartDateTime;
                }
                return result;
            }
        }

        /// <summary>
        /// 一日の残業時間
        /// </summary>
        public float OverWorkTime
        {
            get
            {
                float result = 0;

                //グリッドの行数を取得
                int nGridRowCount = this.dataGridPerformedWorkOrder.Rows.Count;

                //行数が1以上の時
                if(nGridRowCount >= 1)
                {
                    //一日の合計作業時間から8時間を引く
                    float DayTotalWorkTime = GetTotalWorkTime() - 8;

                    //作業時間が8時間以上の時
                    if(DayTotalWorkTime >= 0)
                    {
                        result = DayTotalWorkTime;
                    }

                }
                //残業時間を返す
                return result;
            }
        }

        /// <summary>
        /// 一日の作業終了日時
        /// </summary>
        public DateTime EndDayWorkTime
        {
            get
            {
                DateTime result = new DateTime();

                //グリッドの行数を取得
                int nGridRowCount = this.dataGridPerformedWorkOrder.Rows.Count;

                //グリッドの行数が1行以上の時
                if (nGridRowCount >= 1)
                {
                    //表示されている最終行の行番号を取得
                    int nLastGridRowNumber = nGridRowCount - 1;

                    //最終行の作業終了時間を取得
                    Data.PerformedWorkOrderItem StartWorkItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[nLastGridRowNumber].Tag;
                    result = (DateTime)StartWorkItem.WorkEndDateTime;
                }

                //取得した値を返す
                return result;
            }
        }

        public PerformedWorkOrderGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実施作業リストを設定する
        /// </summary>
        public void SetPerformedWorkList(List<Data.PerformedWorkOrderItem> PerformedWorkList, Data.WorkerItem UserInfo, DateTime TargetDate)
        {

            this._PerformedWorkList = PerformedWorkList;
            this._UserInfo = UserInfo;
            this._WorkDate = TargetDate;

            SetData();

        }

        
        /// <summary>
        /// 変更した作業情報をデータベースに登録
        /// </summary>
        public void SetWorkData()
        {
            try
            {
                Manage.AdjustmentWorkTableManage am = new Manage.AdjustmentWorkTableManage();

                foreach (Data.PerformedWorkOrderItem pwiWorkOrderItem in this._PerformedWorkList)
                {
                    am.AddPerformedWorkInfo(pwiWorkOrderItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        #endregion

        #region イベント定義

        // 実施作業の内容が変更された時のイベント
        public event EventHandler ChangePerformedWork;

        #endregion

        #region フォームイベント

        /// <summary>
        /// 右クリックメニューの削除ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridPerformedWorkOrder.CurrentCell == null)
                {
                    // 未選択
                    return;
                }

                // 選択したセルの行
                DataGridViewRow deleterow = this.dataGridPerformedWorkOrder.CurrentCell.OwningRow;
                

                Data.PerformedWorkOrderItem pwiDeleteItem = (Data.PerformedWorkOrderItem)deleterow.Tag;

                string sText = string.Format("作業 {0} : {1}  のデータを削除します。よろしいですか？", pwiDeleteItem.WorkOrderInfo.WorkOrderNo, pwiDeleteItem.WorkOrderInfo.WorkName);

                if (MessageBox.Show(sText, this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteRow(deleterow.Index);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 目盛テキスト：アクティブコントロール変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbWorkTimeScale_Leave(object sender, EventArgs e)
        {
            try
            { 
                Console.WriteLine("tbWorkTimeScale_Leave");
                TextBox ChangeTextBox = (TextBox)sender;
                if(ChangeTextBox.Modified == true)
                {
                    Console.WriteLine("テキストの内容を変更しました。");

                    // Indexを取得
                    string sIndex = ChangeTextBox.Name.Replace(this.tbWorkTimeScale.Name, "");

                    if(sIndex == "")
                    {

                    }
                    else
                    {
                        // 変更目盛の内容をデータグリッドビューに反映
                        UpdateGridViewOfTime(ChangeTextBox.Text, Convert.ToInt32(sIndex));

                    }
                
                    // 目盛の位置再設定
                    RedeisplayScale();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// データグリッドビュー：セルの値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridPerformedWorkOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                Console.WriteLine("dataGridPerformedWorkOrder_CellEndEdit");
                if (this.dataGridPerformedWorkOrder.CurrentCell.ColumnIndex == this.ColWorkTime.Index)
                {
                    DataGridViewRow TargetRow = this.dataGridPerformedWorkOrder.CurrentRow;
                    float ChanegWorkTime = Convert.ToSingle(TargetRow.Cells[this.ColWorkTime.Index].Value);

                    // 工数列の値が変更された場合
                    UpdatePerformedWorkDataOfWorkTime(ChanegWorkTime, TargetRow.Index);

                    //対象行以降の行内容を変更
                    UpdateRowData(TargetRow.Index);

                    // 目盛の位置再設定
                    RedeisplayScale();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// データグリッドビュー セル：値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridPerformedWorkOrder_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            Console.WriteLine("dataGridPerformedWorkOrder_CellValidated");

        }

        /// <summary>
        /// 右クリックメニューの追加ボタン 前へ: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemAddPre_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridPerformedWorkOrder.CurrentCell == null)
                {
                    // 未選択
                    return;
                }

                SelectWorkOrderForm sf = new SelectWorkOrderForm(this._UserInfo.DepartmentID);
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    // 選択したセルの行
                    DataGridViewRow row = this.dataGridPerformedWorkOrder.CurrentCell.OwningRow;

                    AddWorkOrder(row.Index, sf.SelectWorkOrderItem);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 右クリックメニューの追加ボタン 次へ: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemAddNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridPerformedWorkOrder.CurrentCell == null)
                {
                    // 未選択
                    return;
                }

                SelectWorkOrderForm sf = new SelectWorkOrderForm(this._UserInfo.DepartmentID);
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    // 選択したセルの行
                    DataGridViewRow row = this.dataGridPerformedWorkOrder.CurrentCell.OwningRow;

                    // 1つ後の行数を指定
                    AddWorkOrder(row.Index + 1, sf.SelectWorkOrderItem);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// データグリッドビュー セル：ダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridPerformedWorkOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                // 選択したセルの行
                DataGridViewRow CurrentRow = this.dataGridPerformedWorkOrder.CurrentCell.OwningRow;

                if ((string)CurrentRow.Cells[this.ColOrderNo.Index].Value == null)
                {
                    SelectWorkOrderForm sf = new SelectWorkOrderForm(this._UserInfo.DepartmentID);
                    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Data.WorkOrderItem SelectWorkItem = sf.SelectWorkOrderItem;

                        // 空白行の場合、作業を設定する。
                        Data.PerformedWorkOrderItem pwoiChangeItem = (Data.PerformedWorkOrderItem)CurrentRow.Tag;
                        
                        pwoiChangeItem.EmpID = this._UserInfo.EmpID;
                        pwoiChangeItem.WorkOrderID = SelectWorkItem.WorkOrderID;
                        pwoiChangeItem.WorkOrderInfo = SelectWorkItem;

                        // 実施作業取得
                        List<Data.PerformedWorkOrderItem> workList = GetPerformedWorkNum();
                        // 作業数＋1 を実施作業IDとして付与
                        pwoiChangeItem.PerformedWorkOrderID = workList.Count + 1;

                        CurrentRow.Tag = pwoiChangeItem;

                        // 作業情報追加
                        CurrentRow.Cells[this.ColOrderNo.Index].Value = SelectWorkItem.WorkOrderNo;
                        CurrentRow.Cells[this.colWorkNameItem.Index].Value = SelectWorkItem.WorkName;
                        CurrentRow.Cells[this.ColWorkTime.Index].ReadOnly = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion




        /// <summary>
        /// 実施作業データをグリッドビューに設定する
        /// </summary>
        private void SetData()
        {
            // ******************************
            // 実施作業時間の設定
            // ******************************


            // 作業時間(H)合計
            float SumWorkTime = this._PerformedWorkList.Where(x => x.WorkTime > -1).Sum(x => x.WorkTime);


            // 作業時間(0.5H単位)合計
            double WorkManagementTableUnit = 0.5;
            float SumWorkTime_WorkManagementTableUnit = Convert.ToSingle(Math.Floor(SumWorkTime / WorkManagementTableUnit) * WorkManagementTableUnit);


            // 作業時間(0.05H単位)設定
            foreach (Data.PerformedWorkOrderItem item in this._PerformedWorkList)
            {
                item.ConvertWorkTime = ConvertWorkTime(item.WorkTime);
            }

            // 作業時間(0.05単位)合計
            float SumConvertWorkTime = this._PerformedWorkList.Where(x => x.ConvertWorkTime > -1).Sum(x => x.ConvertWorkTime);


            if (SumWorkTime_WorkManagementTableUnit < SumConvertWorkTime)
            {
                // ---------------------------------------------------------
                // 作業時間(0.5H単位)合計と作業時間(0.05単位)合計が異なる場合
                // ---------------------------------------------------------

                // 作業時間降順
                this._PerformedWorkList.Sort((a, b) => Convert.ToInt16(b.WorkTime - a.WorkTime));

                var Diff = SumConvertWorkTime - SumWorkTime_WorkManagementTableUnit;

                Console.WriteLine("1番作業時間が大きい作業ID：" + this._PerformedWorkList[0].WorkOrderID + "、作業時間：" + this._PerformedWorkList[0].ConvertWorkTime);
                Console.WriteLine("作業時間(H)合計と作業時間(0.05単位)合計の差分：" + Diff);

                if (this._PerformedWorkList[0].ConvertWorkTime > Diff)
                {
                    // 作業時間が1番大きい作業からオーバー分を引く
                    this._PerformedWorkList[0].ConvertWorkTime = this._PerformedWorkList[0].ConvertWorkTime - Diff;
                }

            }

            // 実施作業表示


            // 実施作業開始昇順
            this._PerformedWorkList.Sort((a, b) => Convert.ToInt16(a.PerformedWorkOrderID - b.PerformedWorkOrderID));

            Manage.WorkOrderViewManage woManage = new Manage.WorkOrderViewManage();
            List<Data.WorkOrderItem> woList = woManage.GetWorkOrderInfoMaster();

            TimeSpan LunchStart = TimeSpan.Parse("12:00"); // 12時
            TimeSpan LunchEnd = TimeSpan.Parse("13:00");   // 13時

            int index = 0;
            // グリッドビューに表示
            foreach (Data.PerformedWorkOrderItem pwiWorkOrderItem in this._PerformedWorkList)
            {

                //-----------------
                // 行の設定
                //-----------------
                // 新しい行の追加
                index = this.dataGridPerformedWorkOrder.Rows.Add();

                DataGridViewRow rAddItem = this.dataGridPerformedWorkOrder.Rows[index];

                // 作業情報追加
                var AddWorkItem = woList.Find(x => x.WorkOrderID == pwiWorkOrderItem.WorkOrderID);
                if (AddWorkItem != null)
                {
                    rAddItem.Cells[this.ColOrderNo.Index].Value = AddWorkItem.WorkOrderNo;
                    rAddItem.Cells[this.colWorkNameItem.Index].Value = AddWorkItem.WorkName;
                    rAddItem.Cells[this.ColWorkTime.Index].Value =  pwiWorkOrderItem.ConvertWorkTime;
                }
                else
                {
                    rAddItem.Cells[this.ColOrderNo.Index].Value = "-";
                    rAddItem.Cells[this.colWorkNameItem.Index].Value = "対象作業名がありません。";
                    rAddItem.Cells[this.ColWorkTime.Index].Value = pwiWorkOrderItem.ConvertWorkTime;
                }
                rAddItem.Cells[this.ColWorkTime.Index].ReadOnly = false;

                pwiWorkOrderItem.WorkOrderInfo = AddWorkItem;
                
                // 行の高さ
                rAddItem.Height = GetHeightToTime(pwiWorkOrderItem.ConvertWorkTime);
                rAddItem.Tag = pwiWorkOrderItem;


                //-----------------
                // 目盛り描画
                //-----------------
                string stext = Convert.ToDateTime(pwiWorkOrderItem.WorkEndDateTime).ToShortTimeString();
                CreateTextBox(this.tbWorkTimeScale.Name + index.ToString(), stext, this.tbWorkTimeScale.Location.Y);

                DateTime bufWorkEndTime = (DateTime)pwiWorkOrderItem.WorkEndDateTime;

                if (bufWorkEndTime.TimeOfDay >= LunchStart && bufWorkEndTime.TimeOfDay <= LunchEnd)
                {
                    // 昼休みの行を追加
                    CreateLunchRow(index);
                    
                }

            }
            

            if (this.dataGridPerformedWorkOrder.Rows.Count > 0)
            {
                TimeSpan tsWorkStart = TimeSpan.Parse("8:30");
                TimeSpan tsWorkEnd = TimeSpan.Parse("17:30");

                int nDay = this._WorkDate.Day;
                int nMonth = this._WorkDate.Month;
                int nYear = this._WorkDate.Year;

                // *** 空白行は「オーダーNo」列の値が null で作成 ***

                ////-----------------------------------------------------------------------------------------
                //// 開始時刻確認
                //// 　　最初の作業の作業開始日時が8:30以降の場合、「8:30～作業開始日時」のグリッドを追加
                ////-----------------------------------------------------------------------------------------
                Data.PerformedWorkOrderItem pwoiStartRowItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[0].Tag;
                if (pwoiStartRowItem.WorkStartDateTime.TimeOfDay > tsWorkStart)
                {
                    // 新しい行を最初に追加
                    this.dataGridPerformedWorkOrder.Rows.Insert(0);
                    DataGridViewRow rAddItem = this.dataGridPerformedWorkOrder.Rows[0];

                    // 実施作業作成
                    Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();

                    addItem.WorkStartDateTime = new DateTime(nYear, nMonth, nDay, 8, 30, 0);
                    addItem.WorkEndDateTime = pwoiStartRowItem.WorkStartDateTime;
                    addItem.ConvertWorkTime = ConvertWorkTime(addItem.WorkTime);

                    rAddItem.Height = GetHeightToTime(addItem.ConvertWorkTime);
                    rAddItem.Tag = addItem;
                    rAddItem.Cells[this.ColWorkTime.Index].Value = addItem.ConvertWorkTime;

                    // 目盛り描画
                    string stext = Convert.ToDateTime(addItem.WorkEndDateTime).ToShortTimeString();
                    int Heightbuf = GetHeightToTime(addItem.ConvertWorkTime);
                    CreateTextBox(this.tbWorkTimeScale.Name + (index + 1).ToString(), stext, Heightbuf);

                }

                //-----------------------------------------------------------------------------------------
                // 終了時刻確認
                // 　　最後の作業の作業終了日時が17:30以前の場合、「作業終了日時～17:30」のグリッドを追加
                //-----------------------------------------------------------------------------------------
                pwoiStartRowItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[this.dataGridPerformedWorkOrder.Rows.Count-1].Tag;
                DateTime dtEndDate = (DateTime)pwoiStartRowItem.WorkEndDateTime;
                if (dtEndDate.TimeOfDay < tsWorkEnd)
                {
                    // 新しい行の追加
                    index = this.dataGridPerformedWorkOrder.Rows.Add();
                    DataGridViewRow rAddItem = this.dataGridPerformedWorkOrder.Rows[index];

                    // 実施作業作成
                    Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();

                    addItem.WorkStartDateTime = dtEndDate;
                    addItem.WorkEndDateTime = new DateTime(nYear, nMonth, nDay, 17, 30, 0);
                    addItem.ConvertWorkTime = ConvertWorkTime(addItem.WorkTime);

                    rAddItem.Height = GetHeightToTime(addItem.ConvertWorkTime);
                    rAddItem.Tag = addItem;
                    rAddItem.Cells[this.ColWorkTime.Index].Value = addItem.ConvertWorkTime;

                    // 目盛り描画
                    string stext = Convert.ToDateTime(addItem.WorkEndDateTime).ToShortTimeString();
                    int Heightbuf = GetHeightToTime(addItem.ConvertWorkTime);
                    CreateTextBox(this.tbWorkTimeScale.Name + index.ToString(), stext, Heightbuf);
                }

                // 目盛の位置再設定
                RedeisplayScale();

            }

        }

        /// <summary>
        /// グリッドビューに昼休憩の行を作成
        /// </summary>
        /// <param name="index"></param>
        private void CreateLunchRow(int index)
        {
            // *** 昼休憩の行は「オーダーNo」列の値が null で作成 ***

            index = this.dataGridPerformedWorkOrder.Rows.Add();

            DataGridViewRow rLunchItem = this.dataGridPerformedWorkOrder.Rows[index];
            rLunchItem.Cells[this.colWorkNameItem.Index].Value = "昼休憩";
            rLunchItem.Cells[this.colWorkNameItem.Index].Style.BackColor = Color.LightGray;
            rLunchItem.Cells[this.ColOrderNo.Index].Style.BackColor = Color.LightGray;
            rLunchItem.Cells[this.ColWorkTime.Index].Style.BackColor = Color.LightGray;

            rLunchItem.Height = GetHeightToTime(1);

            // 実施作業作成
            Data.PerformedWorkOrderItem lunchItem = new Data.PerformedWorkOrderItem();

            int nLunchDay = this._WorkDate.Day;
            int nLunchMonth = this._WorkDate.Month;
            int nLunchYear = this._WorkDate.Year;

            lunchItem.WorkStartDateTime = new DateTime(nLunchYear, nLunchMonth, nLunchDay, 12, 00, 0);
            lunchItem.WorkEndDateTime = new DateTime(nLunchYear, nLunchMonth, nLunchDay, 13, 00, 0);
            lunchItem.ConvertWorkTime = ConvertWorkTime(lunchItem.WorkTime);

            rLunchItem.Tag = lunchItem;

            CreateTextBox(this.tbWorkTimeScale.Name + index.ToString(), "13:00", rLunchItem.Height);


        }

        /// <summary>
        /// グリッドビューの昼休憩行を開始時間に調整
        /// </summary>
        private void AdjustmentLunchRow()
        {
            int lunchIndex = -1;

            //昼休憩のindexを取得
            for (int i = 0;i < this.dataGridPerformedWorkOrder.Rows.Count;i++)
            {
                DataGridViewRow rLunchItem = this.dataGridPerformedWorkOrder.Rows[i];
                if (!(rLunchItem.Cells[this.colWorkNameItem.Index].Value is null) &&  rLunchItem.Cells[this.colWorkNameItem.Index].Value.Equals("昼休憩"))
                {
                    lunchIndex = i;
                    break;
                }
            }

            ///昼休憩のインデックスが見つかってるなら調整
            if (lunchIndex >= 0)
            {
                // 修正準備
                int nLunchDay = this._WorkDate.Day;
                int nLunchMonth = this._WorkDate.Month;
                int nLunchYear = this._WorkDate.Year;

                //昼休憩の修正
                Data.PerformedWorkOrderItem lunchItem = new Data.PerformedWorkOrderItem();

                lunchItem.WorkStartDateTime = new DateTime(nLunchYear, nLunchMonth, nLunchDay, 12, 00, 0);
                lunchItem.WorkEndDateTime = new DateTime(nLunchYear, nLunchMonth, nLunchDay, 13, 00, 0);
                lunchItem.ConvertWorkTime = ConvertWorkTime(lunchItem.WorkTime);

                this.dataGridPerformedWorkOrder.Rows[lunchIndex].Tag = lunchItem;


                //昼休憩の前作業修正(終了時間と作業時間を修正)
                Data.PerformedWorkOrderItem beforeLunchTime = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[lunchIndex - 1].Tag;

                beforeLunchTime.WorkEndDateTime = new DateTime(nLunchYear, nLunchMonth, nLunchDay, 12, 00, 0);
                beforeLunchTime.ConvertWorkTime = ConvertWorkTime(beforeLunchTime.WorkTime);

                this.dataGridPerformedWorkOrder.Rows[lunchIndex - 1].Tag = beforeLunchTime;


                // 工数列の値が変更された場合
                UpdatePerformedWorkDataOfWorkTime(beforeLunchTime.ConvertWorkTime, lunchIndex - 1);

                //対象行以降の行内容を変更
                UpdateRowData(lunchIndex - 1);

            }
            RedeisplayScale();
        }

        /// <summary>
        /// 目盛の位置を再設定する(再設定後、「ChangePerformedWork」イベントを発生)
        /// </summary>
        private void RedeisplayScale()
        {
            int nHeightY = this.tbWorkTimeScale.Location.Y;

            for (int i = 0; i < this.dataGridPerformedWorkOrder.Rows.Count; i++)
            {
                // 実施作業情報取得
                Data.PerformedWorkOrderItem pwoiRowItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[i].Tag;

                if (i==0)
                {
                    this.tbWorkTimeScale.Text= pwoiRowItem.WorkStartDateTime.ToShortTimeString();
                }

                // 行番号と同じ番号を持つ目盛を取得
                Control[] conTargetWorkTimeScale = this.Controls.Find(this.tbWorkTimeScale.Name + i.ToString(), false);
                if (conTargetWorkTimeScale.Count() > 0)
                {
                    Console.WriteLine(i + "の目盛が変更されました。");

                    TextBox tbScale = ((TextBox)conTargetWorkTimeScale[0]);
                    // 目盛の表示内容を変更
                    tbScale.Text = Convert.ToDateTime(pwoiRowItem.WorkEndDateTime).ToShortTimeString();

                    // 目盛の位置を変更
                    nHeightY = nHeightY + this.dataGridPerformedWorkOrder.Rows[i].Height;
                    tbScale.Location = new Point(this.tbWorkTimeScale.Location.X, nHeightY);


                }
                else
                {
                    Console.WriteLine("コントロール：" + this.tbWorkTimeScale.Name + i.ToString() + "が存在しません。");
                }
            }

            // イベント発生
            ChangePerformedWork(this, System.EventArgs.Empty);
        }

        /// <summary>
        /// テキストボックス(目盛)を作成します。
        /// </summary>
        /// <param name="ConName">テキストボックス名</param>
        /// <param name="ConText">テキスト</param>
        /// <param name="ConText">位置(Y軸)</param>
        private void CreateTextBox(string ConName, string ConText, int LocationY)
        {
            TextBox textboxBuf = new TextBox();

            textboxBuf.BorderStyle = BorderStyle.None;
            textboxBuf.TextAlign = HorizontalAlignment.Right;
            textboxBuf.BackColor = SystemColors.Menu;
            textboxBuf.Size = this.tbWorkTimeScale.Size;

            textboxBuf.Name = ConName;
            textboxBuf.Text = ConText;
            textboxBuf.Location = new Point(this.tbWorkTimeScale.Location.X, LocationY);

            textboxBuf.Leave += tbWorkTimeScale_Leave;

            this.Controls.Add(textboxBuf);
        }

        /// <summary>
        /// 作業時間(0.05H単位)を返す
        /// </summary>
        /// <remarks>
        /// 作業終了日時がnullの場合は"-1"を返す。
        /// </remarks>
        private float ConvertWorkTime(float WorkTime)
        {
            float result = -1;

            if (WorkTime > -1)
            {

                // 作業管理表単位(0.05H)
                // （0.05で四捨五入）
                result = Convert.ToSingle(Math.Round(WorkTime / WORK_TIME_UNIT, MidpointRounding.AwayFromZero) * WORK_TIME_UNIT);

            }

            return result;

        }

        /// <summary>
        /// 作業データを追加します。
        /// </summary>
        /// <param name="insertRowIndex">挿入する行</param>
        private void AddWorkOrder(int insertRowIndex, Data.WorkOrderItem woiItem)
        {

            // 新しい行
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(this.dataGridPerformedWorkOrder);

            // 行追加
            this.dataGridPerformedWorkOrder.Rows.Insert(insertRowIndex, newRow);
            newRow = this.dataGridPerformedWorkOrder.Rows[insertRowIndex];
            
            //---------------------------------------
            // 行の設定
            //---------------------------------------
            // 高さの時間(00:00:00 表記)
            TimeSpan tsDiff = GetTimeSpanToHeight(newRow.Height);


            // 実施作業作成
            Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();
            addItem.EmpID = this._UserInfo.EmpID;
            addItem.WorkOrderID = woiItem.WorkOrderID;
            addItem.WorkOrderInfo = woiItem;
            addItem.ConvertWorkTime = ConvertWorkTime(addItem.WorkTime);
            // 実施作業取得
            List<Data.PerformedWorkOrderItem> workList = GetPerformedWorkNum();
            // 作業数＋1 を実施作業IDとして付与
            addItem.PerformedWorkOrderID = workList.Count + 1;


            //行の前後から開始/終了時刻を取得
            //追加する作業がindex0の時
            if (insertRowIndex == 0)
            {
                //追加する作業の開始時間へindex+1の作業の開始時間を代入
                Data.PerformedWorkOrderItem bufaddItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[insertRowIndex + 1].Tag;
                addItem.WorkStartDateTime = bufaddItem.WorkStartDateTime;
            }
            else
            {
                //追加する作業がindex0以外の時
                //追加する作業の開始時間へindex-1の作業の終了時間を代入
                Data.PerformedWorkOrderItem bufaddItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[insertRowIndex - 1].Tag;
                addItem.WorkStartDateTime = (DateTime)bufaddItem.WorkEndDateTime;

            }

            // 作業情報追加
            newRow.Cells[this.ColOrderNo.Index].Value = woiItem.WorkOrderNo;
            newRow.Cells[this.colWorkNameItem.Index].Value = woiItem.WorkName;
            newRow.Cells[this.ColWorkTime.Index].ReadOnly = false;

            //工数から追加する作業の作業終了時間を更新する
            double fInsertWorkTime = 0.5;

            newRow.Tag = addItem;
            UpdatePerformedWorkDataOfWorkTime(Convert.ToSingle(fInsertWorkTime), insertRowIndex);

            // 目盛り描画
            string stext = Convert.ToDateTime(addItem.WorkEndDateTime).ToShortTimeString();
            int Heightbuf = GetHeightToTime(addItem.ConvertWorkTime);
            int iMaxRowNumber = this.dataGridPerformedWorkOrder.Rows.Count - 1;
            CreateTextBox(this.tbWorkTimeScale.Name + iMaxRowNumber.ToString(), stext, Heightbuf);

            //挿入行以降の情報を更新
            UpdateRowData(insertRowIndex);

            // 目盛の位置再設定
            RedeisplayScale();
        }



        /// <summary>
        /// 変更した作業情報をビューへ反映する
        /// </summary>
        /// <param name="ChangeTimeText">変更後の時間のテキスト(00：00)</param>
        /// <param name="StartIndex">開始行番号(行番号以降の行の値を変更する)</param>
        private void UpdateGridViewOfTime(string ChangeTimeText, int StartIndex)
        {
            //変更前と変更後の差分
            Data.PerformedWorkOrderItem bufTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[StartIndex].Tag;

            TimeSpan tsChangeWorkTime = ChangeTextToDateTime(ChangeTimeText) - (DateTime)bufTargetItem.WorkEndDateTime;

            for (int i = StartIndex; i < this.dataGridPerformedWorkOrder.Rows.Count; i++)
            {
                DataGridViewRow bufTargetRow = this.dataGridPerformedWorkOrder.Rows[i];

                //TagをPerformedWorkOrderItem型に変更してPerformedWorkOrderItemを代入
                bufTargetItem = (Data.PerformedWorkOrderItem)bufTargetRow.Tag;

                //引数を作る
                DateTime dtChangeStartTime = bufTargetItem.WorkStartDateTime;
                DateTime dtChangeEndTime = (DateTime)bufTargetItem.WorkEndDateTime + tsChangeWorkTime;

                if(i != StartIndex)
                {
                    dtChangeStartTime = bufTargetItem.WorkStartDateTime + tsChangeWorkTime;
                }

                //行情報を更新
                UpdatePerformedWorkDataOfTime(dtChangeStartTime, dtChangeEndTime, i);

            }

        }

        /// <summary>
        /// 目盛りの値をDateTime型に直す
        /// </summary>
        /// <param name="sChangeTime">目盛りの値</param>
        /// <returns>DateTime型の目盛りの値</returns>
        private DateTime ChangeTextToDateTime(string sChangeTime)
        {
            DateTime result;

            if (sChangeTime == "")
            {
                //目盛りが空白の時、「値が入力されていません」エラーメッセージ
                throw new Exception("目盛りに値がありません。");
            }


            //「__:__」コロンの左右が数字2桁以内の時正常
            if (Regex.IsMatch(sChangeTime, "^[0-9]{1,2}:[0-9]{1,2}$") == true)
            {

                //引数のstring型をTimeSpanに直す
                TimeSpan tsChangeTime = TimeSpan.Parse(sChangeTime);

                //変更する時間に型を変更した時分を結合する
                result = _WorkDate + tsChangeTime;

                //結合した値を返す
                return result;
            }
            else
            {
                throw new Exception("目盛りの値が正しくありません。");
            }

        }

        /// <summary>
        /// 現在グリッドビューに表示されている実施作業の合計時間を取得する
        /// </summary>
        /// <returns></returns>
        private float GetTotalWorkTime()
        {
            float result = 0;

            //グリッドビューに表示されている作業の個数分,作業の工数を回す
            foreach (DataGridViewRow TotalWorkTimeRow in this.dataGridPerformedWorkOrder.Rows)
            {
                
                if ((string)TotalWorkTimeRow.Cells[this.ColOrderNo.Index].Value != null )
                {
                    //条件：オーダーNoに値が格納されているとき
                    Data.PerformedWorkOrderItem TotalWorkTimeItem = (Data.PerformedWorkOrderItem)TotalWorkTimeRow.Tag;
                    result = result + TotalWorkTimeItem.ConvertWorkTime;
                }

            }
            return result;
        }



        /// <summary>
        /// 対象行番号以降の作業データを更新する
        /// </summary>
        /// <param name="index">対象行番号</param>
        private void UpdateRowData(int index)
        {

            //対象行の終了時間を一時保存
            Data.PerformedWorkOrderItem pwoiTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[index].Tag;
            DateTime dtBufStartTime = (DateTime)pwoiTargetItem.WorkEndDateTime;

            //対象行番号の次の行から最終行まで繰り返す
            for (int i = index + 1; i < this.dataGridPerformedWorkOrder.Rows.Count; i++)
            {
                //操作する行の情報を取得
                Data.PerformedWorkOrderItem pwoiChangeItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[i].Tag;
                float fBufChangeWorkTime = pwoiChangeItem.WorkTime;
                //i行の開始時間を、前行で一時的に保存した終了時間で更新
                pwoiChangeItem.WorkStartDateTime = dtBufStartTime;
                this.dataGridPerformedWorkOrder.Rows[i].Tag = pwoiChangeItem;

                //指定した行の終了時間と指定した行の次の行の作業時間から行の情報を更新
                UpdatePerformedWorkDataOfWorkTime(fBufChangeWorkTime, i);

                //i行の終了時間を一時的に保存
                dtBufStartTime = (DateTime)pwoiChangeItem.WorkEndDateTime;
            }
        }


        /// <summary>
        /// 指定した行番号の作業データを削除する
        /// </summary>
        /// <param name="index">削除する作業データの行番号</param>
        private void DeleteRow(int index)
        {      

            //削除対象の開始時間を一時保存する
            Data.PerformedWorkOrderItem pwoiRemoveTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[index].Tag;  //削除対象            
            DateTime dtBufStartTime = pwoiRemoveTargetItem.WorkStartDateTime;
                        
            //対象の行を削除する
            this.dataGridPerformedWorkOrder.Rows.RemoveAt(index);

            //削除対象の行から最終行まで繰り返す
            for (int i= index; i < this.dataGridPerformedWorkOrder.Rows.Count; i++)
            {
                //一時保存した作業開始時間を変更したい行へ更新する
                Data.PerformedWorkOrderItem pwoiChangeTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[i].Tag;  //削除対象の次の行

                float TargetWorkTime = pwoiChangeTargetItem.WorkTime;

                pwoiChangeTargetItem.WorkStartDateTime = dtBufStartTime;

                this.dataGridPerformedWorkOrder.Rows[i].Tag = pwoiChangeTargetItem;

                //削除対象の次の行の情報（PerformedWorkOrderItemの情報）を削除対象の開始時間と工数を使って変更する
                UpdatePerformedWorkDataOfWorkTime(TargetWorkTime, i);
                dtBufStartTime = (DateTime)pwoiChangeTargetItem.WorkEndDateTime;

            }

            // 最後尾の目盛を削除
            int lastIndex = this.dataGridPerformedWorkOrder.Rows.Count;
            Control[] conTargetWorkTimeScale = this.Controls.Find(this.tbWorkTimeScale.Name + lastIndex.ToString(), false);
            if (conTargetWorkTimeScale.Count() > 0)
            {
                TextBox tbScale = ((TextBox)conTargetWorkTimeScale[0]);
                this.Controls.Remove(tbScale);
            }
                
                // 目盛の位置再設定
                RedeisplayScale();
        }

        /// <summary>
        /// 変更した作業開始/終了時間からデータグリッドビューの情報を更新する
        /// </summary>
        /// <param name="dtChangeStartTime">変更後の作業開始時間</param>
        /// <param name="dtChangeEndTime">変更後の作業終了時間</param>
        /// <param name="TargetRowIndex">変更を加える行数</param>
        private void UpdatePerformedWorkDataOfTime(DateTime dtChangeStartTime , DateTime dtChangeEndTime, int TargetRowIndex)
        {
            //TagをPerformedWorkOrderItem型に変更してPerformedWorkOrderItemを代入
            Data.PerformedWorkOrderItem pwoiTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Tag;

            //変更後の開始時刻をTagの作業開始時間に代入
            pwoiTargetItem.WorkStartDateTime = dtChangeStartTime;

            //終了時刻をTagの作業終了時刻にdtChangeStartTime代入
            pwoiTargetItem.WorkEndDateTime = dtChangeEndTime;

            //ConvertWorkTimeにWorkTimeの値を0.05単位に直して代入
            pwoiTargetItem.ConvertWorkTime = ConvertWorkTime(pwoiTargetItem.WorkTime);

            //TargetPerformedWorkOrderItemの中身をTagへ入れる
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Tag = pwoiTargetItem;

            //TargetRowのHeightに高さを代入
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Height = GetHeightToTime(pwoiTargetItem.ConvertWorkTime);

            //TargetRowの工数列に工数を代入
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Cells[this.ColWorkTime.Index].Value = pwoiTargetItem.ConvertWorkTime;

        }

        /// <summary>
        /// 変更した工数からデータグリッドビューの情報を更新する
        /// </summary>
        /// <param name="fChangeWorkTime">変更後の工数</param>
        /// <param name="TargetRowIndex">変更を加える行数</param>
        private void UpdatePerformedWorkDataOfWorkTime(float fChangeWorkTime, int TargetRowIndex)
        {

            Data.PerformedWorkOrderItem pwoiTargetItem = (Data.PerformedWorkOrderItem)this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Tag;
            TimeSpan tsChangeWorkTime = TimeSpan.FromHours(fChangeWorkTime);

            //作業終了時間を更新（作業開始時間 + dtChangeWorkTime）
            pwoiTargetItem.WorkEndDateTime = pwoiTargetItem.WorkStartDateTime + tsChangeWorkTime;
            //作業時間（0.05単位）を更新
            pwoiTargetItem.ConvertWorkTime = ConvertWorkTime(pwoiTargetItem.WorkTime);

            //変更行の作業内容を更新
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Tag = pwoiTargetItem;

            //高さを代入する
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Height = GetHeightToTime(pwoiTargetItem.ConvertWorkTime);

            //工数を代入する
            this.dataGridPerformedWorkOrder.Rows[TargetRowIndex].Cells[this.ColWorkTime.Index].Value = pwoiTargetItem.ConvertWorkTime;

        }

        /// <summary>
        /// 高さ(ピクセル)から時間(0.05)を算出する
        /// </summary>
        private TimeSpan GetTimeSpanToHeight(int DiffHeight)
        {
            TimeSpan result;

            // 0.05単位
            float WorkTime = Convert.ToSingle(DiffHeight / WORK_HEIGHT_UNIT * WORK_TIME_UNIT);
            float ConWorkTime = ConvertWorkTime(WorkTime);

            // 時分(例：1.15 ⇒ 1時間9分)　に変更
            float ConWorkTime_minutes = ConWorkTime - Convert.ToInt32(ConWorkTime);
            result = new TimeSpan(Convert.ToInt32(ConWorkTime), Convert.ToInt32(60 * ConWorkTime_minutes), 0); // Diff分の時間

            return result;
        }


        /// <summary>
        /// 時間(0.05)から高さ(ピクセル)を算出する
        /// </summary>
        private int GetHeightToTime(float WorkTime)
        {
            return Convert.ToInt16(WORK_HEIGHT_UNIT) * Convert.ToInt16(WorkTime / WORK_TIME_UNIT);
        }

        /// <summary>
        /// データグリッドビューに表示されている実施作業を取得
        /// </summary>
        /// <returns></returns>
        private List<Data.PerformedWorkOrderItem> GetPerformedWorkNum()
        {
            List<Data.PerformedWorkOrderItem> result = new List<Data.PerformedWorkOrderItem>();
            
            foreach (DataGridViewRow row in this.dataGridPerformedWorkOrder.Rows)
            {

                if ((string)row.Cells[this.ColOrderNo.Index].Value != null)
                {
                    //条件：オーダーNoに値が格納されているとき
                    Data.PerformedWorkOrderItem item = (Data.PerformedWorkOrderItem)row.Tag;
                    result.Add(item);
                }

            }

            return result;
        }


    }
}
