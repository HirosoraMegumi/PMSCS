namespace WorkLog.Forms
{
    partial class ProcessLog
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
            this.webBrowserProcessSheet = new System.Windows.Forms.WebBrowser();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelProcessSheet = new System.Windows.Forms.Panel();
            this.buttonReload = new System.Windows.Forms.Button();
            this.panelProcessSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserProcessSheet
            // 
            this.webBrowserProcessSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserProcessSheet.Location = new System.Drawing.Point(0, 0);
            this.webBrowserProcessSheet.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserProcessSheet.Name = "webBrowserProcessSheet";
            this.webBrowserProcessSheet.Size = new System.Drawing.Size(801, 526);
            this.webBrowserProcessSheet.TabIndex = 1;
            this.webBrowserProcessSheet.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserProcessSheet_DocumentCompleted);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(715, 573);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "閉じる";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panelProcessSheet
            // 
            this.panelProcessSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProcessSheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProcessSheet.Controls.Add(this.webBrowserProcessSheet);
            this.panelProcessSheet.Location = new System.Drawing.Point(3, 37);
            this.panelProcessSheet.Name = "panelProcessSheet";
            this.panelProcessSheet.Size = new System.Drawing.Size(805, 530);
            this.panelProcessSheet.TabIndex = 7;
            // 
            // buttonReload
            // 
            this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReload.Location = new System.Drawing.Point(731, 8);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 8;
            this.buttonReload.Text = "リロード";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // ProcessLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 599);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.panelProcessSheet);
            this.Controls.Add(this.buttonOk);
            this.Name = "ProcessLog";
            this.Text = "プロセス記録";
            this.Load += new System.EventHandler(this.ProcessLog_Load);
            this.panelProcessSheet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.WebBrowser webBrowserProcessSheet;
        private System.Windows.Forms.Panel panelProcessSheet;
        private System.Windows.Forms.Button buttonReload;
    }
}