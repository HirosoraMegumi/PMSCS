namespace SelfControlSystem
{
    partial class PerformedWorkOrderForm
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSumWorkTime = new System.Windows.Forms.Label();
            this.tbSumWorkTime = new System.Windows.Forms.TextBox();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.tbOverWorkTime = new System.Windows.Forms.TextBox();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lblOverWorkTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.performedWorkOrderGridView = new SelfControlSystem.PerformedWorkOrderGridView();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(247, 906);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "完了";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(347, 906);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSumWorkTime
            // 
            this.lblSumWorkTime.AutoSize = true;
            this.lblSumWorkTime.Location = new System.Drawing.Point(245, 38);
            this.lblSumWorkTime.Name = "lblSumWorkTime";
            this.lblSumWorkTime.Size = new System.Drawing.Size(59, 12);
            this.lblSumWorkTime.TabIndex = 3;
            this.lblSumWorkTime.Text = "合計時間：";
            // 
            // tbSumWorkTime
            // 
            this.tbSumWorkTime.Location = new System.Drawing.Point(318, 38);
            this.tbSumWorkTime.Name = "tbSumWorkTime";
            this.tbSumWorkTime.ReadOnly = true;
            this.tbSumWorkTime.Size = new System.Drawing.Size(100, 19);
            this.tbSumWorkTime.TabIndex = 4;
            // 
            // tbEndTime
            // 
            this.tbEndTime.BackColor = System.Drawing.SystemColors.Control;
            this.tbEndTime.Location = new System.Drawing.Point(121, 38);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(100, 19);
            this.tbEndTime.TabIndex = 5;
            this.tbEndTime.TabStop = false;
            // 
            // tbOverWorkTime
            // 
            this.tbOverWorkTime.BackColor = System.Drawing.SystemColors.Control;
            this.tbOverWorkTime.Location = new System.Drawing.Point(318, 9);
            this.tbOverWorkTime.Name = "tbOverWorkTime";
            this.tbOverWorkTime.ReadOnly = true;
            this.tbOverWorkTime.Size = new System.Drawing.Size(100, 19);
            this.tbOverWorkTime.TabIndex = 6;
            // 
            // tbStartTime
            // 
            this.tbStartTime.BackColor = System.Drawing.SystemColors.Control;
            this.tbStartTime.Location = new System.Drawing.Point(121, 9);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(100, 19);
            this.tbStartTime.TabIndex = 7;
            // 
            // lblOverWorkTime
            // 
            this.lblOverWorkTime.AutoSize = true;
            this.lblOverWorkTime.Location = new System.Drawing.Point(245, 12);
            this.lblOverWorkTime.Name = "lblOverWorkTime";
            this.lblOverWorkTime.Size = new System.Drawing.Size(59, 12);
            this.lblOverWorkTime.TabIndex = 8;
            this.lblOverWorkTime.Text = "残業時間：";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(44, 38);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(59, 12);
            this.lblEndTime.TabIndex = 9;
            this.lblEndTime.Text = "退社時刻：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(44, 12);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 12);
            this.lblStartTime.TabIndex = 10;
            this.lblStartTime.Text = "出勤時刻：";
            // 
            // performedWorkOrderGridView
            // 
            this.performedWorkOrderGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.performedWorkOrderGridView.AutoScroll = true;
            this.performedWorkOrderGridView.Location = new System.Drawing.Point(12, 63);
            this.performedWorkOrderGridView.MinimumSize = new System.Drawing.Size(340, 320);
            this.performedWorkOrderGridView.Name = "performedWorkOrderGridView";
            this.performedWorkOrderGridView.Size = new System.Drawing.Size(410, 824);
            this.performedWorkOrderGridView.TabIndex = 2;
            this.performedWorkOrderGridView.ChangePerformedWork += new System.EventHandler(this.performedWorkOrderGridView_ChangePerformedWork);
            this.performedWorkOrderGridView.Load += new System.EventHandler(this.performedWorkOrderGridView_Load);
            // 
            // PerformedWorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 941);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblOverWorkTime);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.tbOverWorkTime);
            this.Controls.Add(this.tbEndTime);
            this.Controls.Add(this.tbSumWorkTime);
            this.Controls.Add(this.lblSumWorkTime);
            this.Controls.Add(this.performedWorkOrderGridView);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExecute);
            this.MinimumSize = new System.Drawing.Size(450, 460);
            this.Name = "PerformedWorkOrderForm";
            this.Text = "実施作業一覧";
            this.Load += new System.EventHandler(this.PerformedWorkOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnCancel;
        private PerformedWorkOrderGridView performedWorkOrderGridView;
        private System.Windows.Forms.Label lblSumWorkTime;
        private System.Windows.Forms.TextBox tbSumWorkTime;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.TextBox tbOverWorkTime;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.Label lblOverWorkTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
    }
}