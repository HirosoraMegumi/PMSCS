namespace WorkLog.Forms
{
    partial class WorkLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelWorkOrderNo = new System.Windows.Forms.Label();
            this.panelWorkOrderNo = new System.Windows.Forms.Panel();
            this.buttonWorkOrderChange = new System.Windows.Forms.Button();
            this.labelWorkOrderNoDisp = new System.Windows.Forms.Label();
            this.panelWorkSpan = new System.Windows.Forms.Panel();
            this.labelWorkSpanDisp = new System.Windows.Forms.Label();
            this.labelWorkSpan = new System.Windows.Forms.Label();
            this.panelCustomer = new System.Windows.Forms.Panel();
            this.CustomerName = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelWorkNameDisp = new System.Windows.Forms.Label();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.comboBoxProcess = new System.Windows.Forms.ComboBox();
            this.buttonProcessLog = new System.Windows.Forms.Button();
            this.labelProcess = new System.Windows.Forms.Label();
            this.panelRunningTime = new System.Windows.Forms.Panel();
            this.labelRunningTimeDisp = new System.Windows.Forms.Label();
            this.labelRunningTime = new System.Windows.Forms.Label();
            this.panelStartDateTime = new System.Windows.Forms.Panel();
            this.labelStartDateTimeDisp = new System.Windows.Forms.Label();
            this.labelStartDateTime = new System.Windows.Forms.Label();
            this.buttonLeaveWork = new System.Windows.Forms.Button();
            this.workTotalTime = new System.Windows.Forms.Timer(this.components);
            this.panelWorkOrderNo.SuspendLayout();
            this.panelWorkSpan.SuspendLayout();
            this.panelCustomer.SuspendLayout();
            this.panelProcess.SuspendLayout();
            this.panelRunningTime.SuspendLayout();
            this.panelStartDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWorkOrderNo
            // 
            this.labelWorkOrderNo.AutoSize = true;
            this.labelWorkOrderNo.Location = new System.Drawing.Point(4, 4);
            this.labelWorkOrderNo.Name = "labelWorkOrderNo";
            this.labelWorkOrderNo.Size = new System.Drawing.Size(83, 12);
            this.labelWorkOrderNo.TabIndex = 0;
            this.labelWorkOrderNo.Text = "社内オーダーNo.";
            // 
            // panelWorkOrderNo
            // 
            this.panelWorkOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkOrderNo.Controls.Add(this.buttonWorkOrderChange);
            this.panelWorkOrderNo.Controls.Add(this.labelWorkOrderNoDisp);
            this.panelWorkOrderNo.Controls.Add(this.labelWorkOrderNo);
            this.panelWorkOrderNo.Location = new System.Drawing.Point(5, 2);
            this.panelWorkOrderNo.Name = "panelWorkOrderNo";
            this.panelWorkOrderNo.Size = new System.Drawing.Size(177, 45);
            this.panelWorkOrderNo.TabIndex = 1;
            // 
            // buttonWorkOrderChange
            // 
            this.buttonWorkOrderChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWorkOrderChange.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonWorkOrderChange.Location = new System.Drawing.Point(123, 20);
            this.buttonWorkOrderChange.Name = "buttonWorkOrderChange";
            this.buttonWorkOrderChange.Size = new System.Drawing.Size(52, 22);
            this.buttonWorkOrderChange.TabIndex = 3;
            this.buttonWorkOrderChange.Text = "変更";
            this.buttonWorkOrderChange.UseVisualStyleBackColor = true;
            this.buttonWorkOrderChange.Click += new System.EventHandler(this.buttonWorkOrderChange_Click);
            // 
            // labelWorkOrderNoDisp
            // 
            this.labelWorkOrderNoDisp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkOrderNoDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelWorkOrderNoDisp.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelWorkOrderNoDisp.Location = new System.Drawing.Point(1, 20);
            this.labelWorkOrderNoDisp.Name = "labelWorkOrderNoDisp";
            this.labelWorkOrderNoDisp.Size = new System.Drawing.Size(116, 22);
            this.labelWorkOrderNoDisp.TabIndex = 2;
            this.labelWorkOrderNoDisp.Text = "SY43-034";
            this.labelWorkOrderNoDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelWorkSpan
            // 
            this.panelWorkSpan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkSpan.Controls.Add(this.labelWorkSpanDisp);
            this.panelWorkSpan.Controls.Add(this.labelWorkSpan);
            this.panelWorkSpan.Location = new System.Drawing.Point(188, 2);
            this.panelWorkSpan.Name = "panelWorkSpan";
            this.panelWorkSpan.Size = new System.Drawing.Size(238, 45);
            this.panelWorkSpan.TabIndex = 2;
            // 
            // labelWorkSpanDisp
            // 
            this.labelWorkSpanDisp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkSpanDisp.BackColor = System.Drawing.Color.White;
            this.labelWorkSpanDisp.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelWorkSpanDisp.Location = new System.Drawing.Point(1, 20);
            this.labelWorkSpanDisp.Name = "labelWorkSpanDisp";
            this.labelWorkSpanDisp.Size = new System.Drawing.Size(234, 22);
            this.labelWorkSpanDisp.TabIndex = 2;
            this.labelWorkSpanDisp.Text = "2019/9/26 ～ 2019/12/20";
            this.labelWorkSpanDisp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWorkSpan
            // 
            this.labelWorkSpan.AutoSize = true;
            this.labelWorkSpan.Location = new System.Drawing.Point(4, 4);
            this.labelWorkSpan.Name = "labelWorkSpan";
            this.labelWorkSpan.Size = new System.Drawing.Size(53, 12);
            this.labelWorkSpan.TabIndex = 0;
            this.labelWorkSpan.Text = "作業期間";
            // 
            // panelCustomer
            // 
            this.panelCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomer.Controls.Add(this.CustomerName);
            this.panelCustomer.Controls.Add(this.labelCustomer);
            this.panelCustomer.Location = new System.Drawing.Point(432, 2);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Size = new System.Drawing.Size(168, 45);
            this.panelCustomer.TabIndex = 3;
            // 
            // CustomerName
            // 
            this.CustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerName.BackColor = System.Drawing.Color.White;
            this.CustomerName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerName.Location = new System.Drawing.Point(1, 20);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(164, 22);
            this.CustomerName.TabIndex = 2;
            this.CustomerName.Text = "中電CTI";
            this.CustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(4, 4);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(41, 12);
            this.labelCustomer.TabIndex = 0;
            this.labelCustomer.Text = "顧客名";
            // 
            // labelWorkNameDisp
            // 
            this.labelWorkNameDisp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkNameDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelWorkNameDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWorkNameDisp.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelWorkNameDisp.Location = new System.Drawing.Point(5, 50);
            this.labelWorkNameDisp.Name = "labelWorkNameDisp";
            this.labelWorkNameDisp.Size = new System.Drawing.Size(595, 66);
            this.labelWorkNameDisp.TabIndex = 4;
            this.labelWorkNameDisp.Text = "床応答スペクトル作成システム開発業務（Phase1）";
            this.labelWorkNameDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelProcess
            // 
            this.panelProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProcess.Controls.Add(this.comboBoxProcess);
            this.panelProcess.Controls.Add(this.buttonProcessLog);
            this.panelProcess.Controls.Add(this.labelProcess);
            this.panelProcess.Location = new System.Drawing.Point(5, 119);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(326, 45);
            this.panelProcess.TabIndex = 5;
            // 
            // comboBoxProcess
            // 
            this.comboBoxProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxProcess.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.comboBoxProcess.FormattingEnabled = true;
            this.comboBoxProcess.Items.AddRange(new object[] {
            "受注活動",
            "作業計画・作業指示",
            "作業実施・検証",
            "納品"});
            this.comboBoxProcess.Location = new System.Drawing.Point(4, 18);
            this.comboBoxProcess.Name = "comboBoxProcess";
            this.comboBoxProcess.Size = new System.Drawing.Size(262, 24);
            this.comboBoxProcess.TabIndex = 5;
            this.comboBoxProcess.Text = "作業計画・作業指示";
            // 
            // buttonProcessLog
            // 
            this.buttonProcessLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcessLog.Location = new System.Drawing.Point(272, 20);
            this.buttonProcessLog.Name = "buttonProcessLog";
            this.buttonProcessLog.Size = new System.Drawing.Size(52, 22);
            this.buttonProcessLog.TabIndex = 4;
            this.buttonProcessLog.Text = "記録";
            this.buttonProcessLog.UseVisualStyleBackColor = true;
            this.buttonProcessLog.Click += new System.EventHandler(this.buttonProcessLog_Click);
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(4, 4);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(123, 12);
            this.labelProcess.TabIndex = 0;
            this.labelProcess.Text = "実施中のプロセスフェーズ";
            // 
            // panelRunningTime
            // 
            this.panelRunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRunningTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRunningTime.Controls.Add(this.labelRunningTimeDisp);
            this.panelRunningTime.Controls.Add(this.labelRunningTime);
            this.panelRunningTime.Location = new System.Drawing.Point(504, 119);
            this.panelRunningTime.Name = "panelRunningTime";
            this.panelRunningTime.Size = new System.Drawing.Size(96, 45);
            this.panelRunningTime.TabIndex = 6;
            // 
            // labelRunningTimeDisp
            // 
            this.labelRunningTimeDisp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRunningTimeDisp.BackColor = System.Drawing.Color.White;
            this.labelRunningTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.labelRunningTimeDisp.Location = new System.Drawing.Point(1, 21);
            this.labelRunningTimeDisp.Name = "labelRunningTimeDisp";
            this.labelRunningTimeDisp.Size = new System.Drawing.Size(92, 22);
            this.labelRunningTimeDisp.TabIndex = 2;
            this.labelRunningTimeDisp.Text = "0:00:00";
            this.labelRunningTimeDisp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRunningTime
            // 
            this.labelRunningTime.AutoSize = true;
            this.labelRunningTime.Location = new System.Drawing.Point(4, 4);
            this.labelRunningTime.Name = "labelRunningTime";
            this.labelRunningTime.Size = new System.Drawing.Size(53, 12);
            this.labelRunningTime.TabIndex = 0;
            this.labelRunningTime.Text = "経過時間";
            // 
            // panelStartDateTime
            // 
            this.panelStartDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStartDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStartDateTime.Controls.Add(this.labelStartDateTimeDisp);
            this.panelStartDateTime.Controls.Add(this.labelStartDateTime);
            this.panelStartDateTime.Location = new System.Drawing.Point(337, 119);
            this.panelStartDateTime.Name = "panelStartDateTime";
            this.panelStartDateTime.Size = new System.Drawing.Size(161, 45);
            this.panelStartDateTime.TabIndex = 7;
            // 
            // labelStartDateTimeDisp
            // 
            this.labelStartDateTimeDisp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDateTimeDisp.BackColor = System.Drawing.Color.White;
            this.labelStartDateTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.labelStartDateTimeDisp.Location = new System.Drawing.Point(1, 20);
            this.labelStartDateTimeDisp.Name = "labelStartDateTimeDisp";
            this.labelStartDateTimeDisp.Size = new System.Drawing.Size(157, 22);
            this.labelStartDateTimeDisp.TabIndex = 2;
            this.labelStartDateTimeDisp.Text = "2019/12/9 9:45";
            this.labelStartDateTimeDisp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartDateTime
            // 
            this.labelStartDateTime.AutoSize = true;
            this.labelStartDateTime.Location = new System.Drawing.Point(4, 4);
            this.labelStartDateTime.Name = "labelStartDateTime";
            this.labelStartDateTime.Size = new System.Drawing.Size(53, 12);
            this.labelStartDateTime.TabIndex = 0;
            this.labelStartDateTime.Text = "開始日時";
            // 
            // buttonLeaveWork
            // 
            this.buttonLeaveWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeaveWork.Location = new System.Drawing.Point(337, 170);
            this.buttonLeaveWork.Name = "buttonLeaveWork";
            this.buttonLeaveWork.Size = new System.Drawing.Size(263, 27);
            this.buttonLeaveWork.TabIndex = 8;
            this.buttonLeaveWork.Text = "本日の業務を終了し、管理表に記録する";
            this.buttonLeaveWork.UseVisualStyleBackColor = true;
            this.buttonLeaveWork.Click += new System.EventHandler(this.buttonLeaveWork_Click);
            // 
            // workTotalTime
            // 
            this.workTotalTime.Interval = 1000;
            this.workTotalTime.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WorkLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 202);
            this.Controls.Add(this.buttonLeaveWork);
            this.Controls.Add(this.panelStartDateTime);
            this.Controls.Add(this.panelRunningTime);
            this.Controls.Add(this.panelProcess);
            this.Controls.Add(this.labelWorkNameDisp);
            this.Controls.Add(this.panelCustomer);
            this.Controls.Add(this.panelWorkSpan);
            this.Controls.Add(this.panelWorkOrderNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WorkLog";
            this.ShowIcon = false;
            this.Text = "SY43-034 [ワークログ]";
            this.Load += new System.EventHandler(this.WorkLog_Load);
            this.panelWorkOrderNo.ResumeLayout(false);
            this.panelWorkOrderNo.PerformLayout();
            this.panelWorkSpan.ResumeLayout(false);
            this.panelWorkSpan.PerformLayout();
            this.panelCustomer.ResumeLayout(false);
            this.panelCustomer.PerformLayout();
            this.panelProcess.ResumeLayout(false);
            this.panelProcess.PerformLayout();
            this.panelRunningTime.ResumeLayout(false);
            this.panelRunningTime.PerformLayout();
            this.panelStartDateTime.ResumeLayout(false);
            this.panelStartDateTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWorkOrderNo;
        private System.Windows.Forms.Panel panelWorkOrderNo;
        private System.Windows.Forms.Label labelWorkOrderNoDisp;
        private System.Windows.Forms.Panel panelWorkSpan;
        private System.Windows.Forms.Label labelWorkSpanDisp;
        private System.Windows.Forms.Label labelWorkSpan;
        private System.Windows.Forms.Panel panelCustomer;
        private System.Windows.Forms.Label CustomerName;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelWorkNameDisp;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.Panel panelRunningTime;
        private System.Windows.Forms.Label labelRunningTimeDisp;
        private System.Windows.Forms.Label labelRunningTime;
        private System.Windows.Forms.Panel panelStartDateTime;
        private System.Windows.Forms.Label labelStartDateTimeDisp;
        private System.Windows.Forms.Label labelStartDateTime;
        private System.Windows.Forms.Button buttonWorkOrderChange;
        private System.Windows.Forms.ComboBox comboBoxProcess;
        private System.Windows.Forms.Button buttonProcessLog;
        private System.Windows.Forms.Button buttonLeaveWork;
        private System.Windows.Forms.Timer workTotalTime;
    }
}