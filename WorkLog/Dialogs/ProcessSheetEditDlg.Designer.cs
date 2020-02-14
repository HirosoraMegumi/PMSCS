namespace WorkLog.Dialogs
{
    partial class ProcessSheetEditDlg
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
            this.labelWorkOrderNo = new System.Windows.Forms.Label();
            this.groupBoxWorkOrderSelect = new System.Windows.Forms.GroupBox();
            this.labelWorkOrderSelect = new System.Windows.Forms.Label();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.comboBoxWorkOrder = new System.Windows.Forms.ComboBox();
            this.comboBoxAcceptDepartment = new System.Windows.Forms.ComboBox();
            this.labelAcceptDepartment = new System.Windows.Forms.Label();
            this.groupBoxPSTypeSelect = new System.Windows.Forms.GroupBox();
            this.labelPSTypeSelect = new System.Windows.Forms.Label();
            this.listBoxPSType = new System.Windows.Forms.ListBox();
            this.groupBoxPSNo = new System.Windows.Forms.GroupBox();
            this.labelPSNo = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxWorkOrderSelect.SuspendLayout();
            this.groupBoxPSTypeSelect.SuspendLayout();
            this.groupBoxPSNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWorkOrderNo
            // 
            this.labelWorkOrderNo.AutoSize = true;
            this.labelWorkOrderNo.Location = new System.Drawing.Point(10, 86);
            this.labelWorkOrderNo.Name = "labelWorkOrderNo";
            this.labelWorkOrderNo.Size = new System.Drawing.Size(89, 12);
            this.labelWorkOrderNo.TabIndex = 0;
            this.labelWorkOrderNo.Text = "社内オーダーNo.：";
            // 
            // groupBoxWorkOrderSelect
            // 
            this.groupBoxWorkOrderSelect.Controls.Add(this.labelWorkOrderSelect);
            this.groupBoxWorkOrderSelect.Controls.Add(this.textBoxCustomer);
            this.groupBoxWorkOrderSelect.Controls.Add(this.labelCustomer);
            this.groupBoxWorkOrderSelect.Controls.Add(this.comboBoxWorkOrder);
            this.groupBoxWorkOrderSelect.Controls.Add(this.comboBoxAcceptDepartment);
            this.groupBoxWorkOrderSelect.Controls.Add(this.labelAcceptDepartment);
            this.groupBoxWorkOrderSelect.Controls.Add(this.labelWorkOrderNo);
            this.groupBoxWorkOrderSelect.Location = new System.Drawing.Point(12, 26);
            this.groupBoxWorkOrderSelect.Name = "groupBoxWorkOrderSelect";
            this.groupBoxWorkOrderSelect.Size = new System.Drawing.Size(361, 157);
            this.groupBoxWorkOrderSelect.TabIndex = 1;
            this.groupBoxWorkOrderSelect.TabStop = false;
            this.groupBoxWorkOrderSelect.Text = "社内オーダー選択";
            // 
            // labelWorkOrderSelect
            // 
            this.labelWorkOrderSelect.AutoSize = true;
            this.labelWorkOrderSelect.Location = new System.Drawing.Point(10, 24);
            this.labelWorkOrderSelect.Name = "labelWorkOrderSelect";
            this.labelWorkOrderSelect.Size = new System.Drawing.Size(239, 12);
            this.labelWorkOrderSelect.TabIndex = 6;
            this.labelWorkOrderSelect.Text = "プロセス管理する社内オーダーを選択してください。";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Enabled = false;
            this.textBoxCustomer.Location = new System.Drawing.Point(105, 118);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(241, 19);
            this.textBoxCustomer.TabIndex = 3;
            this.textBoxCustomer.Text = "中電シーティーアイ";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(10, 121);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(47, 12);
            this.labelCustomer.TabIndex = 5;
            this.labelCustomer.Text = "顧客名：";
            // 
            // comboBoxWorkOrder
            // 
            this.comboBoxWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWorkOrder.FormattingEnabled = true;
            this.comboBoxWorkOrder.Items.AddRange(new object[] {
            "SY43-054"});
            this.comboBoxWorkOrder.Location = new System.Drawing.Point(105, 83);
            this.comboBoxWorkOrder.Name = "comboBoxWorkOrder";
            this.comboBoxWorkOrder.Size = new System.Drawing.Size(241, 20);
            this.comboBoxWorkOrder.TabIndex = 3;
            this.comboBoxWorkOrder.Text = "SY43-054";
            // 
            // comboBoxAcceptDepartment
            // 
            this.comboBoxAcceptDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAcceptDepartment.FormattingEnabled = true;
            this.comboBoxAcceptDepartment.Items.AddRange(new object[] {
            "O&Mソリューション課 システムデザイングループ"});
            this.comboBoxAcceptDepartment.Location = new System.Drawing.Point(105, 49);
            this.comboBoxAcceptDepartment.Name = "comboBoxAcceptDepartment";
            this.comboBoxAcceptDepartment.Size = new System.Drawing.Size(241, 20);
            this.comboBoxAcceptDepartment.TabIndex = 2;
            this.comboBoxAcceptDepartment.Text = "O&Mソリューション課 システムデザイングループ";
            // 
            // labelAcceptDepartment
            // 
            this.labelAcceptDepartment.AutoSize = true;
            this.labelAcceptDepartment.Location = new System.Drawing.Point(10, 52);
            this.labelAcceptDepartment.Name = "labelAcceptDepartment";
            this.labelAcceptDepartment.Size = new System.Drawing.Size(59, 12);
            this.labelAcceptDepartment.TabIndex = 1;
            this.labelAcceptDepartment.Text = "管理部署：";
            // 
            // groupBoxPSTypeSelect
            // 
            this.groupBoxPSTypeSelect.Controls.Add(this.labelPSTypeSelect);
            this.groupBoxPSTypeSelect.Controls.Add(this.listBoxPSType);
            this.groupBoxPSTypeSelect.Location = new System.Drawing.Point(388, 26);
            this.groupBoxPSTypeSelect.Name = "groupBoxPSTypeSelect";
            this.groupBoxPSTypeSelect.Size = new System.Drawing.Size(297, 237);
            this.groupBoxPSTypeSelect.TabIndex = 2;
            this.groupBoxPSTypeSelect.TabStop = false;
            this.groupBoxPSTypeSelect.Text = "プロセスシート選択";
            // 
            // labelPSTypeSelect
            // 
            this.labelPSTypeSelect.AutoSize = true;
            this.labelPSTypeSelect.Location = new System.Drawing.Point(13, 24);
            this.labelPSTypeSelect.Name = "labelPSTypeSelect";
            this.labelPSTypeSelect.Size = new System.Drawing.Size(241, 12);
            this.labelPSTypeSelect.TabIndex = 7;
            this.labelPSTypeSelect.Text = "使用するプロセスシートのタイプを選択してください。";
            // 
            // listBoxPSType
            // 
            this.listBoxPSType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPSType.FormattingEnabled = true;
            this.listBoxPSType.ItemHeight = 12;
            this.listBoxPSType.Items.AddRange(new object[] {
            "受託システム開発",
            "ドキュメントソリューション",
            "ソフトウェア販売",
            "民間航空機マニュアル（原稿）",
            "民間航空機マニュアル（編集）",
            "官需固定翼マニュアル（編集）",
            "官需回転翼マニュアル（編集）"});
            this.listBoxPSType.Location = new System.Drawing.Point(15, 49);
            this.listBoxPSType.Name = "listBoxPSType";
            this.listBoxPSType.Size = new System.Drawing.Size(266, 172);
            this.listBoxPSType.TabIndex = 0;
            // 
            // groupBoxPSNo
            // 
            this.groupBoxPSNo.Controls.Add(this.labelPSNo);
            this.groupBoxPSNo.Location = new System.Drawing.Point(14, 200);
            this.groupBoxPSNo.Name = "groupBoxPSNo";
            this.groupBoxPSNo.Size = new System.Drawing.Size(359, 63);
            this.groupBoxPSNo.TabIndex = 3;
            this.groupBoxPSNo.TabStop = false;
            this.groupBoxPSNo.Text = "作成されるプロセスNo.";
            // 
            // labelPSNo
            // 
            this.labelPSNo.AutoSize = true;
            this.labelPSNo.Location = new System.Drawing.Point(22, 26);
            this.labelPSNo.Name = "labelPSNo";
            this.labelPSNo.Size = new System.Drawing.Size(93, 12);
            this.labelPSNo.TabIndex = 0;
            this.labelPSNo.Text = "PS19SY-CTI-021";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(592, 281);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(93, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(493, 281);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(93, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // ProcessSheetEditDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 316);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxPSNo);
            this.Controls.Add(this.groupBoxPSTypeSelect);
            this.Controls.Add(this.groupBoxWorkOrderSelect);
            this.Name = "ProcessSheetEditDlg";
            this.Text = "プロセスシート作成";
            this.groupBoxWorkOrderSelect.ResumeLayout(false);
            this.groupBoxWorkOrderSelect.PerformLayout();
            this.groupBoxPSTypeSelect.ResumeLayout(false);
            this.groupBoxPSTypeSelect.PerformLayout();
            this.groupBoxPSNo.ResumeLayout(false);
            this.groupBoxPSNo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWorkOrderNo;
        private System.Windows.Forms.GroupBox groupBoxWorkOrderSelect;
        private System.Windows.Forms.ComboBox comboBoxAcceptDepartment;
        private System.Windows.Forms.Label labelAcceptDepartment;
        private System.Windows.Forms.ComboBox comboBoxWorkOrder;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.GroupBox groupBoxPSTypeSelect;
        private System.Windows.Forms.ListBox listBoxPSType;
        private System.Windows.Forms.Label labelWorkOrderSelect;
        private System.Windows.Forms.Label labelPSTypeSelect;
        private System.Windows.Forms.GroupBox groupBoxPSNo;
        private System.Windows.Forms.Label labelPSNo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}