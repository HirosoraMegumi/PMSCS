using System;
using System.Windows.Forms;

namespace WorkLog.Forms
{
    partial class SelectWorkOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInfo = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDisplayCondition = new System.Windows.Forms.GroupBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.combPeriod = new System.Windows.Forms.ComboBox();
            this.ckbOnlyUnfinishedWork = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColAcceptDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChargeDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWorkOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScheduleEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTempWork = new System.Windows.Forms.Button();
            this.tempDataGridView = new System.Windows.Forms.DataGridView();
            this.TempColWorkOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempColWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tempWorkForm = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbDisplayCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataGridView)).BeginInit();
            this.tempWorkForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(164, 12);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "開始する作業を選択してください。";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(2, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.gbDisplayCondition);
            this.splitContainer.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer.Panel2.Controls.Add(this.tbSearch);
            this.splitContainer.Panel2.Controls.Add(this.lblSearch);
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Size = new System.Drawing.Size(944, 338);
            this.splitContainer.SplitterDistance = 162;
            this.splitContainer.TabIndex = 9;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(9, 17);
            this.treeView.MinimumSize = new System.Drawing.Size(55, 55);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(150, 331);
            this.treeView.TabIndex = 3;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "表示条件：";
            // 
            // gbDisplayCondition
            // 
            this.gbDisplayCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDisplayCondition.Controls.Add(this.lblPeriod);
            this.gbDisplayCondition.Controls.Add(this.combPeriod);
            this.gbDisplayCondition.Controls.Add(this.ckbOnlyUnfinishedWork);
            this.gbDisplayCondition.Location = new System.Drawing.Point(97, 38);
            this.gbDisplayCondition.Name = "gbDisplayCondition";
            this.gbDisplayCondition.Size = new System.Drawing.Size(669, 40);
            this.gbDisplayCondition.TabIndex = 15;
            this.gbDisplayCondition.TabStop = false;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(160, 17);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(23, 12);
            this.lblPeriod.TabIndex = 3;
            this.lblPeriod.Text = "期：";
            // 
            // combPeriod
            // 
            this.combPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPeriod.FormattingEnabled = true;
            this.combPeriod.Location = new System.Drawing.Point(189, 13);
            this.combPeriod.Name = "combPeriod";
            this.combPeriod.Size = new System.Drawing.Size(121, 20);
            this.combPeriod.TabIndex = 2;
            this.combPeriod.SelectedIndexChanged += new System.EventHandler(this.combPeriod_SelectedIndexChanged);
            this.combPeriod.SelectionChangeCommitted += new System.EventHandler(this.combPeriod_SelectionChangeCommitted);
            // 
            // ckbOnlyUnfinishedWork
            // 
            this.ckbOnlyUnfinishedWork.AutoSize = true;
            this.ckbOnlyUnfinishedWork.Checked = true;
            this.ckbOnlyUnfinishedWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbOnlyUnfinishedWork.Location = new System.Drawing.Point(6, 15);
            this.ckbOnlyUnfinishedWork.Name = "ckbOnlyUnfinishedWork";
            this.ckbOnlyUnfinishedWork.Size = new System.Drawing.Size(105, 16);
            this.ckbOnlyUnfinishedWork.TabIndex = 1;
            this.ckbOnlyUnfinishedWork.Text = "未終了作業のみ";
            this.ckbOnlyUnfinishedWork.UseVisualStyleBackColor = true;
            this.ckbOnlyUnfinishedWork.CheckedChanged += new System.EventHandler(this.ckbOnlyUnfinishedWork_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(691, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(97, 14);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(588, 19);
            this.tbSearch.TabIndex = 10;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(7, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(83, 12);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "作業名称検索：";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAcceptDepartment,
            this.ColChargeDepartment,
            this.ColWorkOrderNo,
            this.ColWorkName,
            this.ColStartDate,
            this.ColScheduleEndDate,
            this.ColEndDate});
            this.dataGridView.Location = new System.Drawing.Point(9, 84);
            this.dataGridView.MinimumSize = new System.Drawing.Size(200, 50);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(757, 264);
            this.dataGridView.TabIndex = 12;
            // 
            // ColAcceptDepartment
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColAcceptDepartment.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColAcceptDepartment.FillWeight = 10F;
            this.ColAcceptDepartment.Frozen = true;
            this.ColAcceptDepartment.HeaderText = "管理部署";
            this.ColAcceptDepartment.Name = "ColAcceptDepartment";
            this.ColAcceptDepartment.ReadOnly = true;
            this.ColAcceptDepartment.Width = 90;
            // 
            // ColChargeDepartment
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColChargeDepartment.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColChargeDepartment.FillWeight = 10F;
            this.ColChargeDepartment.Frozen = true;
            this.ColChargeDepartment.HeaderText = "担当部署";
            this.ColChargeDepartment.Name = "ColChargeDepartment";
            this.ColChargeDepartment.ReadOnly = true;
            this.ColChargeDepartment.Width = 90;
            // 
            // ColWorkOrderNo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColWorkOrderNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColWorkOrderNo.FillWeight = 10F;
            this.ColWorkOrderNo.Frozen = true;
            this.ColWorkOrderNo.HeaderText = "オーダーNo";
            this.ColWorkOrderNo.Name = "ColWorkOrderNo";
            this.ColWorkOrderNo.ReadOnly = true;
            this.ColWorkOrderNo.Width = 90;
            // 
            // ColWorkName
            // 
            this.ColWorkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColWorkName.FillWeight = 130F;
            this.ColWorkName.HeaderText = "作業名称";
            this.ColWorkName.MinimumWidth = 80;
            this.ColWorkName.Name = "ColWorkName";
            this.ColWorkName.ReadOnly = true;
            // 
            // ColStartDate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColStartDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColStartDate.FillWeight = 10F;
            this.ColStartDate.HeaderText = "開始日";
            this.ColStartDate.Name = "ColStartDate";
            this.ColStartDate.ReadOnly = true;
            this.ColStartDate.Width = 85;
            // 
            // ColScheduleEndDate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColScheduleEndDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColScheduleEndDate.FillWeight = 10F;
            this.ColScheduleEndDate.HeaderText = "終了予定日";
            this.ColScheduleEndDate.Name = "ColScheduleEndDate";
            this.ColScheduleEndDate.ReadOnly = true;
            this.ColScheduleEndDate.Width = 90;
            // 
            // ColEndDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColEndDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColEndDate.FillWeight = 10F;
            this.ColEndDate.HeaderText = "終了日";
            this.ColEndDate.Name = "ColEndDate";
            this.ColEndDate.ReadOnly = true;
            this.ColEndDate.Width = 85;
            // 
            // btnTempWork
            // 
            this.btnTempWork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTempWork.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTempWork.Location = new System.Drawing.Point(10, 48);
            this.btnTempWork.Name = "btnTempWork";
            this.btnTempWork.Size = new System.Drawing.Size(149, 51);
            this.btnTempWork.TabIndex = 4;
            this.btnTempWork.Text = "一時オーダー作成";
            this.btnTempWork.UseVisualStyleBackColor = true;
            this.btnTempWork.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // tempDataGridView
            // 
            this.tempDataGridView.AllowUserToAddRows = false;
            this.tempDataGridView.AllowUserToDeleteRows = false;
            this.tempDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tempDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.tempDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tempDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TempColWorkOrderNo,
            this.TempColWorkName});
            this.tempDataGridView.Location = new System.Drawing.Point(175, 15);
            this.tempDataGridView.MinimumSize = new System.Drawing.Size(200, 40);
            this.tempDataGridView.MultiSelect = false;
            this.tempDataGridView.Name = "tempDataGridView";
            this.tempDataGridView.ReadOnly = true;
            this.tempDataGridView.RowTemplate.Height = 21;
            this.tempDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tempDataGridView.Size = new System.Drawing.Size(758, 117);
            this.tempDataGridView.TabIndex = 17;
            // 
            // TempColWorkOrderNo
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TempColWorkOrderNo.DefaultCellStyle = dataGridViewCellStyle9;
            this.TempColWorkOrderNo.FillWeight = 10F;
            this.TempColWorkOrderNo.Frozen = true;
            this.TempColWorkOrderNo.HeaderText = "オーダーNo";
            this.TempColWorkOrderNo.Name = "TempColWorkOrderNo";
            this.TempColWorkOrderNo.ReadOnly = true;
            this.TempColWorkOrderNo.Width = 90;
            // 
            // TempColWorkName
            // 
            this.TempColWorkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TempColWorkName.FillWeight = 130F;
            this.TempColWorkName.HeaderText = "作業名称";
            this.TempColWorkName.MinimumWidth = 80;
            this.TempColWorkName.Name = "TempColWorkName";
            this.TempColWorkName.ReadOnly = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(745, 509);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(860, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tempWorkForm
            // 
            this.tempWorkForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempWorkForm.Controls.Add(this.tempDataGridView);
            this.tempWorkForm.Controls.Add(this.btnTempWork);
            this.tempWorkForm.Location = new System.Drawing.Point(2, 365);
            this.tempWorkForm.Name = "tempWorkForm";
            this.tempWorkForm.Size = new System.Drawing.Size(944, 141);
            this.tempWorkForm.TabIndex = 18;
            this.tempWorkForm.TabStop = false;
            this.tempWorkForm.Text = "一時オーダー作成";
            // 
            // SelectWorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 544);
            this.Controls.Add(this.tempWorkForm);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(963, 583);
            this.Name = "SelectWorkOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "作業選択";
            this.Shown += new System.EventHandler(this.SelectWorkOrderForm_Shown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbDisplayCondition.ResumeLayout(false);
            this.gbDisplayCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataGridView)).EndInit();
            this.tempWorkForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       //private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            //throw new NotImplementedException();
       // }

        private void combPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbDisplayCondition;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox combPeriod;
        private System.Windows.Forms.CheckBox ckbOnlyUnfinishedWork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAcceptDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChargeDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWorkOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScheduleEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEndDate;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox tempWorkForm;
        private DataGridViewTextBoxColumn TempColWorkOrderNo;
        private DataGridViewTextBoxColumn TempColWorkName;
        public DataGridView tempDataGridView;
        public Button btnTempWork;
    }
}