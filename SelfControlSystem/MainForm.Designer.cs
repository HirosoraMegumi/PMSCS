namespace SelfControlSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plWorkOrder = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblWorkName = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.tbWorkOrder = new System.Windows.Forms.TextBox();
            this.tbWorkNane = new System.Windows.Forms.TextBox();
            this.plWorkTime = new System.Windows.Forms.Panel();
            this.tbTotalTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.btnSelectWorkOrder = new System.Windows.Forms.Button();
            this.btnEndWork = new System.Windows.Forms.Button();
            this.tmTotalTime = new System.Windows.Forms.Timer(this.components);
            this.plWorkOrder.SuspendLayout();
            this.plWorkTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // plWorkOrder
            // 
            this.plWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plWorkOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.plWorkOrder.Controls.Add(this.textBox2);
            this.plWorkOrder.Controls.Add(this.textBox1);
            this.plWorkOrder.Controls.Add(this.lblWorkName);
            this.plWorkOrder.Controls.Add(this.lblOrderNo);
            this.plWorkOrder.Controls.Add(this.tbWorkOrder);
            this.plWorkOrder.Controls.Add(this.tbWorkNane);
            this.plWorkOrder.Location = new System.Drawing.Point(-1, 64);
            this.plWorkOrder.Name = "plWorkOrder";
            this.plWorkOrder.Size = new System.Drawing.Size(478, 111);
            this.plWorkOrder.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox2.Location = new System.Drawing.Point(3, 29);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(85, 1);
            this.textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox1.Location = new System.Drawing.Point(89, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(386, 1);
            this.textBox1.TabIndex = 16;
            // 
            // lblWorkName
            // 
            this.lblWorkName.AutoSize = true;
            this.lblWorkName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWorkName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblWorkName.Location = new System.Drawing.Point(-1, 58);
            this.lblWorkName.Name = "lblWorkName";
            this.lblWorkName.Size = new System.Drawing.Size(89, 19);
            this.lblWorkName.TabIndex = 15;
            this.lblWorkName.Text = "作業名称";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOrderNo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblOrderNo.Location = new System.Drawing.Point(3, 7);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(86, 16);
            this.lblOrderNo.TabIndex = 14;
            this.lblOrderNo.Text = "オーダーNo.";
            // 
            // tbWorkOrder
            // 
            this.tbWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkOrder.BackColor = System.Drawing.Color.FloralWhite;
            this.tbWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWorkOrder.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.tbWorkOrder.Location = new System.Drawing.Point(89, 3);
            this.tbWorkOrder.Multiline = true;
            this.tbWorkOrder.Name = "tbWorkOrder";
            this.tbWorkOrder.ReadOnly = true;
            this.tbWorkOrder.Size = new System.Drawing.Size(386, 34);
            this.tbWorkOrder.TabIndex = 13;
            // 
            // tbWorkNane
            // 
            this.tbWorkNane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkNane.BackColor = System.Drawing.Color.FloralWhite;
            this.tbWorkNane.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWorkNane.Font = new System.Drawing.Font("MS UI Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbWorkNane.ForeColor = System.Drawing.Color.Red;
            this.tbWorkNane.Location = new System.Drawing.Point(89, 33);
            this.tbWorkNane.Multiline = true;
            this.tbWorkNane.Name = "tbWorkNane";
            this.tbWorkNane.ReadOnly = true;
            this.tbWorkNane.Size = new System.Drawing.Size(386, 78);
            this.tbWorkNane.TabIndex = 12;
            this.tbWorkNane.Text = "作業を選択してください。";
            // 
            // plWorkTime
            // 
            this.plWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plWorkTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(241)))));
            this.plWorkTime.Controls.Add(this.tbTotalTime);
            this.plWorkTime.Controls.Add(this.label2);
            this.plWorkTime.Controls.Add(this.tbStartTime);
            this.plWorkTime.Controls.Add(this.lblTotalTime);
            this.plWorkTime.Controls.Add(this.lblStartTime);
            this.plWorkTime.Location = new System.Drawing.Point(-3, 47);
            this.plWorkTime.Name = "plWorkTime";
            this.plWorkTime.Size = new System.Drawing.Size(478, 20);
            this.plWorkTime.TabIndex = 13;
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalTime.BackColor = System.Drawing.Color.White;
            this.tbTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotalTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTotalTime.Font = new System.Drawing.Font("MS UI Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTotalTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbTotalTime.Location = new System.Drawing.Point(325, 0);
            this.tbTotalTime.Multiline = true;
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.ReadOnly = true;
            this.tbTotalTime.Size = new System.Drawing.Size(153, 22);
            this.tbTotalTime.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 14;
            // 
            // tbStartTime
            // 
            this.tbStartTime.BackColor = System.Drawing.Color.White;
            this.tbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStartTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStartTime.Font = new System.Drawing.Font("MS UI Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbStartTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbStartTime.Location = new System.Drawing.Point(91, 0);
            this.tbStartTime.Multiline = true;
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(146, 22);
            this.tbStartTime.TabIndex = 13;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTotalTime.Location = new System.Drawing.Point(242, 4);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(76, 16);
            this.lblTotalTime.TabIndex = 16;
            this.lblTotalTime.Text = "経過時間";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStartTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStartTime.Location = new System.Drawing.Point(8, 4);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(76, 16);
            this.lblStartTime.TabIndex = 15;
            this.lblStartTime.Text = "開始時間";
            // 
            // btnSelectWorkOrder
            // 
            this.btnSelectWorkOrder.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSelectWorkOrder.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSelectWorkOrder.Location = new System.Drawing.Point(88, 8);
            this.btnSelectWorkOrder.Name = "btnSelectWorkOrder";
            this.btnSelectWorkOrder.Size = new System.Drawing.Size(93, 23);
            this.btnSelectWorkOrder.TabIndex = 1;
            this.btnSelectWorkOrder.Text = "作業選択";
            this.btnSelectWorkOrder.UseVisualStyleBackColor = true;
            this.btnSelectWorkOrder.Click += new System.EventHandler(this.btnSelectWorkOrder_Click);
            // 
            // btnEndWork
            // 
            this.btnEndWork.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEndWork.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEndWork.Location = new System.Drawing.Point(322, 8);
            this.btnEndWork.Name = "btnEndWork";
            this.btnEndWork.Size = new System.Drawing.Size(93, 23);
            this.btnEndWork.TabIndex = 5;
            this.btnEndWork.Text = "帰宅";
            this.btnEndWork.UseVisualStyleBackColor = true;
            this.btnEndWork.Click += new System.EventHandler(this.btnEndWork_Click);
            // 
            // tmTotalTime
            // 
            this.tmTotalTime.Interval = 1000;
            this.tmTotalTime.Tick += new System.EventHandler(this.tmTotalTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(180)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(473, 171);
            this.Controls.Add(this.plWorkTime);
            this.Controls.Add(this.btnEndWork);
            this.Controls.Add(this.plWorkOrder);
            this.Controls.Add(this.btnSelectWorkOrder);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 150);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "セルフコントロールシステム";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.plWorkOrder.ResumeLayout(false);
            this.plWorkOrder.PerformLayout();
            this.plWorkTime.ResumeLayout(false);
            this.plWorkTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel plWorkOrder;
        private System.Windows.Forms.Label lblWorkName;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.TextBox tbWorkOrder;
        private System.Windows.Forms.TextBox tbWorkNane;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel plWorkTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btnSelectWorkOrder;
        private System.Windows.Forms.Button btnEndWork;
        private System.Windows.Forms.Timer tmTotalTime;
        private System.Windows.Forms.TextBox tbTotalTime;
    }
}

