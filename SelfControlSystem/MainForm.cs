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
    /// <summary>
    /// 直接/間接作業
    /// </summary>
    public enum WorkType
    {
        Direct = 0,
        Indirect = 1
    }

    public partial class MainForm : Form
    {
        /// <summary>
        /// ユーザーの社員情報
        /// </summary>
        private Data.WorkerItem _UserInfo;

        /// <summary>
        /// 現在行っている作業の開始時間
        /// </summary>
        private DateTime _WorkStartTime;

        /// <summary>
        /// 作業日
        /// (10/29 10:00～10/30 01:00 
        /// 　作業時間が上記の場合、作業日は「10/29」)
        /// </summary>
        private DateTime? _WorkDate;

        /// <summary>
        /// 昼休憩の開始時間12時
        /// </summary>
        private TimeSpan _tsBeforeNoonTime = TimeSpan.Parse("12:00"); // 12時

        /// <summary>
        /// 昼休憩の終了時間13時
        /// </summary>
        private TimeSpan _tsAfterNoonTime = TimeSpan.Parse("13:00");   // 13時

        public MainForm()
        {
            InitializeComponent();
            
        }


        #region フォームイベント

        /// <summary>
        /// フォーム: ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckUser();
            this.tbTotalTime.Text = "00:00:00";
        }


        /// <summary>
        /// 作業選択ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SelectWorkOrderForm sf = new SelectWorkOrderForm(this._UserInfo.DepartmentID);
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _WorkStartTime = DateTime.Now;
                    SetWorkData(_WorkStartTime, sf.SelectWorkOrderItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 帰宅ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndWork_Click(object sender, EventArgs e)
        {
            try
            {

                // 現在実施している作業を終了
                Manage.PerformedWorkTableManage pm = new Manage.PerformedWorkTableManage();
                Data.PerformedWorkOrderItem LatestItem = pm.GetLatestPerformedWorkInfo(this._UserInfo.EmpID);


                _WorkStartTime = DateTime.Now;
                DateTime bufWorkEndTime = CheckWorkEndTime(_WorkStartTime);

                //昼休憩直後の作業開始時間を設定
                TimeSpan AfterNoonStartTime = TimeSpan.Parse("13:01"); //13時1分

                //作業開始時間が12:00よりも小さく終了時間が比較用の時間よりも大きい時
                if (LatestItem.WorkStartDateTime.TimeOfDay < _tsBeforeNoonTime && bufWorkEndTime.TimeOfDay > AfterNoonStartTime)
                {
                    //作業データが昼を跨ぐとき午前と午後に分ける
                    //追加したい新しいレコードの開始時間を13時に設定
                    DateTime bufStartAfternoonDateTime = LatestItem.WorkStartDateTime.Date + _tsAfterNoonTime;  //13時
                    Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();
                    addItem.PerformedWorkOrderID = LatestItem.PerformedWorkOrderID + 1;
                    addItem.EmpID = this._UserInfo.EmpID;
                    addItem.PerformedDate = Convert.ToDateTime(this._WorkDate).Date;
                    addItem.WorkOrderID = LatestItem.WorkOrderID;
                    addItem.WorkStartDateTime = bufStartAfternoonDateTime;

                    //追加したいレコードの作業終了時間に現在時刻を追加
                    addItem.WorkEndDateTime = bufWorkEndTime;

                    //午後のレコードを追加
                    pm.AddPerformedWorkInfo(addItem);

                    //午前の作業終了時間を一時保存
                    DateTime bufStartBeforenoonDateTime = LatestItem.WorkStartDateTime.Date + _tsBeforeNoonTime; //12時
                    bufWorkEndTime = bufStartBeforenoonDateTime;
                }

                //分けた午前作業の終了時間を更新
                pm.UpdateWorkEndDateOfPerformedWorkInfo(LatestItem, bufWorkEndTime);


                PerformedWorkOrderForm pf = new PerformedWorkOrderForm(this._UserInfo, Convert.ToDateTime(this._WorkDate));
                if (pf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    // 実施日初期化
                    this._WorkDate = null;
                    this.tmTotalTime.Enabled = false;
                    this.tbTotalTime.Text = "00:00:00";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion

        #region プライベートメソッド

        /// <summary>
        /// ユーザー情報を確認
        /// </summary>
        private void CheckUser()
        {
            // ユーザー名取得
            string UserName = Environment.UserName;

            // ユーザー情報取得
            Manage.WorkerViewManage wvMaster = new Manage.WorkerViewManage();
            this._UserInfo = wvMaster.GetWorkOrderInfoMaster(UserName);

            if(this._UserInfo == null)
            {
                throw new Exception("ユーザーが データベース に登録されていません。" + Environment.NewLine + "ユーザー登録を依頼してください。");
            }


        }

        /// <summary>
        /// 実施中の作業時間の表示：1秒毎に自動起動するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmTotalTime_Tick(object sender, EventArgs e)
        {
            TimeSpan WorkTotalTime = DateTime.Now - _WorkStartTime;
            //実施中の作業時間をhh:mm:ssの形式で表示
            this.tbTotalTime.Text = WorkTotalTime.ToString("hh':'mm':'ss");
        }


        /// <summary>
        /// 作業終了時間を確認
        /// </summary>
        /// <param name="dtTargetTime">作業終了時間</param>
        /// <returns>作業終了時間が昼休憩の時に作業終了時間を12時として返す</returns>
        private DateTime CheckWorkEndTime(DateTime dtTargetTime) {

            DateTime Result = dtTargetTime;
            if (dtTargetTime.TimeOfDay > _tsBeforeNoonTime && dtTargetTime.TimeOfDay < _tsAfterNoonTime)
            {
                //作業狩猟時間が12:00～13:00の時

                //Resultに12時を代入
                Result = dtTargetTime.Date + _tsBeforeNoonTime;
                
            }
            
            return Result;
        }


        /// <summary>
        /// 作業開始時間を確認
        /// </summary>
        /// <param name="dtTargetTime">作業開始時間</param>
        /// <returns>作業開始時間が昼休憩の時に新しいレコードの作業開始時間を13時として返す</returns>
        private DateTime CheckWorkStartTime(DateTime dtTargetTime)
        {
            DateTime Result = dtTargetTime;
            //作業開始時間が12:00～13:00の時
            if (dtTargetTime.TimeOfDay > _tsBeforeNoonTime && dtTargetTime.TimeOfDay < _tsAfterNoonTime)
            {

                //作業開始時間に13時を代入
                Result = dtTargetTime.Date + _tsAfterNoonTime;

            }
            //Resultを返す
            return Result;
        }

        /// <summary>
        /// 対象作業を現在行っている作業としてデータベースに登録
        /// </summary>
        /// <param name="SwitchTime">作業切り替え日時</param>
        /// <param name="SwitchItem">対象作業</param>
        private void SetWorkData(DateTime SwitchTime, Data.WorkOrderItem SwitchItem)
        {
            //作業登録判定フラグ
            Boolean WorkRegistFlag = false;

            // 最新のレコード取得
            Manage.PerformedWorkTableManage pm = new Manage.PerformedWorkTableManage();
            Data.PerformedWorkOrderItem LatestItem = pm.GetLatestPerformedWorkInfo(this._UserInfo.EmpID);
            if (this._WorkDate == null)
            {
                // 実施日
                // (作業を終了した(帰宅ボタンを押した)とき、nullを入れるため、作業開始時に実施日を入れる)
                this._WorkDate = DateTime.Now.Date;
            }

            if (LatestItem == null || LatestItem.WorkEndDateTime != null)
            {
                
                Console.WriteLine("実施中の作業がないため、今日最初の作業として追加します。");

                // レコードを追加
                Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();
                addItem.PerformedWorkOrderID = 1;
                addItem.EmpID = this._UserInfo.EmpID;
                addItem.PerformedDate = Convert.ToDateTime(this._WorkDate).Date;
                addItem.WorkOrderID = SwitchItem.WorkOrderID;
                addItem.WorkStartDateTime = SwitchTime;

                pm.AddPerformedWorkInfo(addItem);

                WorkRegistFlag = true;

            }
            else
            {

                if (SwitchItem.WorkOrderID == LatestItem.WorkOrderID)
                {
                    throw new Exception("選択した作業は、現在実施中です。");
                }


                Console.WriteLine("実施中の作業の開始時刻は「" + LatestItem.WorkStartDateTime + "」です。");

                // 切り替え前の作業の開始時刻が「実施日」中かどうか確認
                if (LatestItem.WorkStartDateTime >= SwitchTime.Date && LatestItem.WorkStartDateTime < SwitchTime.Date.AddDays(1))
                {
                    // 1分未満の作業は1作業として計上せず、次の作業内に含める
                    TimeSpan ts = SwitchTime - LatestItem.WorkStartDateTime;

                    Console.WriteLine("実施中の作業の開始時刻と作業切り替え時刻との差分は「" + ts.TotalMinutes + "」です。");

                    if (ts.TotalMinutes < 1)
                    {
                        //--------------
                        // 1分未満
                        //--------------
                        // 対象作業で最新レコードを上書き
                        LatestItem.WorkOrderID = SwitchItem.WorkOrderID;
                        pm.UpdatePerformedWorkInfo(LatestItem);

                    }
                    else
                    {
                        //--------------
                        // 1分以上
                        //--------------

                        //比較用の午後作業開始時間を作成
                        TimeSpan AfterNoonStartTime = TimeSpan.Parse("13:01"); //13時1分
                        DateTime bufWorkEndTime;
                        
                        if (LatestItem.WorkStartDateTime.TimeOfDay < _tsBeforeNoonTime && SwitchTime.TimeOfDay > AfterNoonStartTime)
                        {
                            
                            // 切り替え前の作業時間が昼休憩時間を含むとき、作業を「午前」と「午後」に分けて登録する

 
                            //切り替え前の「午前」作業の作業終了時間を12時として登録する
                            bufWorkEndTime = LatestItem.WorkStartDateTime.Date + _tsBeforeNoonTime; //12時
                            DateTime bufStartAfternoonDateTime = LatestItem.WorkStartDateTime.Date + _tsAfterNoonTime;  //13時

                            // *****************************************************************************************
                            // 切り替え前の「午後」作業をデータベースに追加（addItem.WorkStartDateTimeに13時を格納）
                            // *****************************************************************************************
                            Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();
                            addItem.PerformedWorkOrderID = LatestItem.PerformedWorkOrderID + 1;
                            addItem.EmpID = this._UserInfo.EmpID;
                            addItem.PerformedDate = Convert.ToDateTime(this._WorkDate).Date;
                            addItem.WorkOrderID = LatestItem.WorkOrderID;
                            addItem.WorkStartDateTime = bufStartAfternoonDateTime;
                            //addItemのWorkEndDateTimeに作業切り替え日時を追加
                            addItem.WorkEndDateTime = SwitchTime;

                            pm.AddPerformedWorkInfo(addItem);


                            // *****************************************************************************************
                            // 切り替え後の作業をデータベースに追加（addItem.WorkStartDateTimeに13時を格納、終了時刻はnull）
                            // *****************************************************************************************
                            
                            addItem = new Data.PerformedWorkOrderItem();
                            addItem.PerformedWorkOrderID = LatestItem.PerformedWorkOrderID + 2;
                            addItem.EmpID = this._UserInfo.EmpID;
                            addItem.PerformedDate = Convert.ToDateTime(this._WorkDate).Date;
                            addItem.WorkOrderID = SwitchItem.WorkOrderID;
                            addItem.WorkStartDateTime = SwitchTime;

                            pm.AddPerformedWorkInfo(addItem);

                            
                        }
                        else
                        {

                            
                            bufWorkEndTime = CheckWorkEndTime(SwitchTime);

                            // *****************************************************************************************
                            // 切り替え後の作業をデータベースに追加（終了時刻はnull）
                            // *****************************************************************************************
                            Data.PerformedWorkOrderItem addItem = new Data.PerformedWorkOrderItem();
                            addItem.PerformedWorkOrderID = LatestItem.PerformedWorkOrderID + 1;
                            addItem.EmpID = this._UserInfo.EmpID;
                            addItem.PerformedDate = Convert.ToDateTime(this._WorkDate).Date;
                            addItem.WorkOrderID = SwitchItem.WorkOrderID;

                            //作業開始時間が昼休憩の時にレコードの作業開始時間を13時で返す
                            DateTime bufStartBeforenoonDateTime = CheckWorkStartTime(SwitchTime);

                            addItem.WorkStartDateTime = bufStartBeforenoonDateTime;

                            pm.AddPerformedWorkInfo(addItem);

                        }

                        // *****************************************************************************************
                        // 切り替え前の作業(昼休憩を含む場合は「午前」)の終了時刻を更新する
                        // *****************************************************************************************
                        pm.UpdateWorkEndDateOfPerformedWorkInfo(LatestItem, bufWorkEndTime);
                        WorkRegistFlag = true;
                    }
                }
                else
                {
                    // 本日以外に実施した作業レコードで、終了日時に値がないレコード
                    throw new Exception("今日行った作業以外で、終了時間が入っていない作業がデータベース に存在します。");
                }
 

            }

            // 表示変更
            this.tbWorkNane.Text = SwitchItem.WorkName;
            this.tbWorkNane.ForeColor = Color.Black;
            this.tbWorkOrder.Text = SwitchItem.WorkOrderNo;
            this.tbWorkOrder.ForeColor = Color.Black;

            //作業登録時に作業経過時間に表示するタイマーを初期化
            //作業開始時間を表示
            if (WorkRegistFlag == true)
            {
                this.tmTotalTime.Enabled = true;
                this.tbStartTime.Text = SwitchTime.ToLongTimeString();
            }
        }

        #endregion

    }
}

