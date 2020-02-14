namespace WorkLog.Forms
{
    partial class TempWorkOrderForm
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
            this.lblTempWork = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbTempWork = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTempWork
            // 
            this.lblTempWork.AutoSize = true;
            this.lblTempWork.Location = new System.Drawing.Point(13, 43);
            this.lblTempWork.Name = "lblTempWork";
            this.lblTempWork.Size = new System.Drawing.Size(59, 12);
            this.lblTempWork.TabIndex = 11;
            this.lblTempWork.Text = "作業名称：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(490, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(376, 78);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbTempWork
            // 
            this.tbTempWork.Location = new System.Drawing.Point(72, 40);
            this.tbTempWork.MaxLength = 128;
            this.tbTempWork.Name = "tbTempWork";
            this.tbTempWork.Size = new System.Drawing.Size(493, 19);
            this.tbTempWork.TabIndex = 7;
            // 
            // TempWorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 111);
            this.Controls.Add(this.lblTempWork);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbTempWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TempWorkOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一時オーダー作成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTempWork;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox tbTempWork;
    }
}