using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WorkLog.Forms
{

    /// <summary>
    /// 直接/間接作業
    /// </summary>
    public enum WorkType
    {
        Direct = 0,
        Indirect = 1
    }


    public partial class WorkLog : Form
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

        /// <summary>
        /// プロセス番号
        /// </summary>
        private string _ProcessNo;

        /// <summary>
        /// 作業のプロセスシートデータファイルパス
        /// </summary>
        private string _ProcessSheetDataFileName = null;

        /// <summary>
        /// プロセスシートが存在するかどうかのフラグ
        /// true:ある　false:ない
        /// </summary>
        private Boolean _ProcessSheetExist = false;

        /// <summary>
        /// 現在の作業が一時作業かどうかのフラグ
        /// true:実際作業　false:一時作業
        /// </summary>
        private Boolean _WorkOrderNotTemporary = true;

        /// <summary>
        /// プロセスシートがないリマインダ
        /// </summary>
        private Timer processsheetReminderTimer = new Timer();

        /// <summary>
        /// 一時オーダーを使うリマインダ
        /// </summary>
        private Timer workIsTemporaryReminderTimer = new Timer();


        /// <summary>
        /// コンストラクター
        /// </summary>
        public WorkLog()
        {
            InitializeComponent();
            labelStartDateTimeDisp.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 記録ボタン：クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProcessLog_Click(object sender, EventArgs e)
        {
            try
            {
                Form dlg = new Forms.ProcessLog(this._ProcessSheetDataFileName);
                dlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        /// <summary>
        /// 変更ボタン
        /// </summary>
        private void buttonWorkOrderChange_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                SelectWorkOrderForm sf = new SelectWorkOrderForm(this._UserInfo.DepartmentID, this._UserInfo.EmpID);
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _WorkStartTime = DateTime.Now;
                    SetWorkData(_WorkStartTime, sf.SelectWorkOrderItem);
                    labelStartDateTimeDisp.Text = DateTime.Now.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
            }

        }


        /// <summary>
        /// ユーザー情報チェック
        /// </summary>
        private void CheckUser()
        {
            // ユーザー名取得
            string UserName = Environment.UserName;

            // ユーザー情報取得
            Manage.WorkerViewManage wvMaster = new Manage.WorkerViewManage();
            this._UserInfo = wvMaster.GetWorkOrderInfoMaster(UserName);

            if (this._UserInfo == null)
            {
                throw new Exception("ユーザーが データベース に登録されていません。" + Environment.NewLine + "ユーザー登録を依頼してください。");
            }


        }

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
            if (SwitchItem.ChargeDepartmentID == null)
            {
                _WorkOrderNotTemporary = false;
                this.CustomerName.Text = "";
                this.labelWorkSpanDisp.Text = "";
                this.buttonProcessLog.Enabled = false;

                // 社内オーダーと作業名称の背景色を赤にする
                this.labelWorkOrderNoDisp.BackColor = Color.FromArgb(255, 0, 0);
                this.labelWorkNameDisp.BackColor = Color.FromArgb(255, 0, 0);

            }
            else
            {
                _WorkOrderNotTemporary = true;
                this.buttonProcessLog.Enabled = true;
                this.CustomerName.Text = SwitchItem.CustomerName;
                this.labelWorkSpanDisp.Text = SwitchItem.StartDate.ToString().Substring(0, 10) + "～" + SwitchItem.ScheduleEndDate.ToString().Substring(0, 10);

                // 実際作業をするとき、社内オーダーと作業名称の背景色を元のイエローにする
                this.labelWorkOrderNoDisp.BackColor = Color.FromArgb(255, 255, 192);
                this.labelWorkNameDisp.BackColor = Color.FromArgb(255, 255, 192);
            }

            this.labelWorkNameDisp.Text = SwitchItem.WorkName;
            this.labelWorkOrderNoDisp.Text = SwitchItem.WorkOrderNo;
            this.labelWorkNameDisp.ForeColor = Color.Black;
            this.labelWorkOrderNoDisp.ForeColor = Color.Black;

            //作業登録時に作業経過時間に表示するタイマーを初期化
            //作業開始時間を表示
            if (WorkRegistFlag == true)
            {
                this.workTotalTime.Enabled = true;
                this.labelStartDateTimeDisp.Text = SwitchTime.ToLongTimeString();
            }

            // 一時オーダーを使うとき、リマインダフォームを生成する
            if (!this._WorkOrderNotTemporary)
            {
                startTemporaryWorkReminderTimer();
            }
            else
            {
                // 本物の作業をするとき

                // 作業のプロセスシートがあるかを判断する
                this._ProcessNo = SwitchItem.ProcessNo;
                this._ProcessSheetExist = CheckProcessSheetExist(this._ProcessNo);

                // プロセスシートがないとき、リマインダフォームを生成する
                if (!this._ProcessSheetExist)
                {
                    // 社内オーダーと作業名称の背景色を赤にする
                    this.labelWorkOrderNoDisp.BackColor = Color.FromArgb(255, 0, 0);
                    this.labelWorkNameDisp.BackColor = Color.FromArgb(255, 0, 0);

                    this.buttonProcessLog.Enabled = false;

                    MessageBox.Show("プロセスシートを作成してください。", "警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    startProcessSheetReminderTimer();
                }
            }
        }

        /// <summary>
        /// 作業開始時間チャック
        /// </summary>
        /// <param name="dtTargetTime"></param>
        /// <returns></returns>
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
        /// 作業終了時間チャック
        /// </summary>
        /// <param name="dtTargetTime"></param>
        /// <returns></returns>
        private DateTime CheckWorkEndTime(DateTime dtTargetTime)
        {

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
        /// 経過時間を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkLog_Load(object sender, EventArgs e)
        {
            CheckUser();
            this.labelRunningTimeDisp.Text = "00:00:00";
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeaveWork_Click(object sender, EventArgs e)
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
                    //this.tmTotalTime.Enabled = false;
                    //this.tbTotalTime.Text = "00:00:00";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 実施中の作業時間の表示：1秒毎に自動起動するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan WorkTotalTime = DateTime.Now - _WorkStartTime;
            //実施中の作業時間をhh:mm:ssの形式で表示
            this.labelRunningTimeDisp.Text = WorkTotalTime.ToString("hh':'mm':'ss");
        }

        /// <summary>
        /// プロセスシートがないことをリマインダするタイマーを設定する
        /// </summary>
        private void startProcessSheetReminderTimer()
        {
            processsheetReminderTimer.Interval = 600000;
            processsheetReminderTimer.Tick += new EventHandler(showProcessSheetReminderForm);

            // タイマーを起こす
            processsheetReminderTimer.Start();
        }

        /// <summary>
        /// 一時オーダーを使っていることをリマインダするタイマーを設定する
        /// </summary>
        private void startTemporaryWorkReminderTimer()
        {
            workIsTemporaryReminderTimer.Interval = 600000;
            workIsTemporaryReminderTimer.Tick += new EventHandler(showTemporaryWorkReminderForm);

            // タイマーを起こす
            workIsTemporaryReminderTimer.Start();
        }

        /// <summary>
        /// プロセスシートの状態を確認する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showProcessSheetReminderForm(object sender, EventArgs e)
        {
            if (this._ProcessSheetExist)
            {
                // プロセスシートがあるとき、社内オーダーと作業名称の背景色を元のイエローにする
                this.labelWorkOrderNoDisp.BackColor = Color.FromArgb(255, 255, 192);
                this.labelWorkNameDisp.BackColor = Color.FromArgb(255, 255, 192);

                this.buttonProcessLog.Enabled = true;
                // タイマーを停止する
                processsheetReminderTimer.Stop();
            }
            else
            {
                // プロセスシートがないとき、もう一度プロセスシートの状態を確認する
                this._ProcessSheetExist = CheckProcessSheetExist(this._ProcessNo);

                // プロセスシートがないとき、リマインダフォームを表示する
                if (!this._ProcessSheetExist)
                {
                    MessageBox.Show("プロセスシートを作成てください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 一時オーダーを使っている状態を確認する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showTemporaryWorkReminderForm(object sender, EventArgs e)
        {
            if (!this._WorkOrderNotTemporary)
            {
                // 一時オーダーを使っているとき、リマインダフォームを表示する
                MessageBox.Show("作業の社内オーダーを作成てください。", "警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                // 一時オーダーを使わないとき、タイマーを停止する
                workIsTemporaryReminderTimer.Stop();
            }
        }

        /// <summary>
        /// プロセスシートが存在するかしないかを判断する
        /// </summary>
        /// <param name="ProcessNo"></param>
        /// <returns></returns>
        private Boolean CheckProcessSheetExist(string ProcessNo)
        {
            // ProcessNoがない
            if (String.IsNullOrWhiteSpace(ProcessNo))
            {
                return false;
            }

            // 作業のプロセスシートが存在するかしないかを判断する
            // データベースからコンフィグ情報を取得する
            Manage.ConfigManage configManage = new Manage.ConfigManage();
            List<Data.ConfigItem> configList = configManage.GetConfigInfo();
            Data.ConfigPathItem configPathItem = configManage.SetConfigPathInfo(configList);

            // configPathItem.DataBaseDirPath = @"C:\Users\jc-sun-f\Desktop\test";

            //　保存されたフォルダ名はProcessNoと同じ
            String folderPath = Path.Combine(configPathItem.DataBaseDirPath, ProcessNo);

            try
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);

                FileInfo[] files = di.GetFiles("PS*-MAP.ditamap");
                if (files.Length == 1)
                {
                    // ファイルある
                    this._ProcessSheetDataFileName = Path.Combine(folderPath, files[0].Name);
                    return true;
                }
                else if (files.Length == 0)
                {
                    // ファイルない
                    return false;
                }
                else if (files.Length > 1)
                {
                    // 複数のファイルがある
                    MessageBox.Show("複数のプロセスシートがあります。チェックしてください。","警告", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch (DirectoryNotFoundException e)
            {
                // フォルダない
                MessageBox.Show(e.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return false;

        }
    }
}
