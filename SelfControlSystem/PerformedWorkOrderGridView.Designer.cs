namespace SelfControlSystem
{
    partial class PerformedWorkOrderGridView
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridPerformedWorkOrder = new System.Windows.Forms.DataGridView();
            this.ColOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkNameItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuPerformedWorkOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddPre = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddNext = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tbWorkTimeScale = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerformedWorkOrder)).BeginInit();
            this.contextMenuPerformedWorkOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridPerformedWorkOrder
            // 
            this.dataGridPerformedWorkOrder.AllowUserToAddRows = false;
            this.dataGridPerformedWorkOrder.AllowUserToResizeRows = false;
            this.dataGridPerformedWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPerformedWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPerformedWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPerformedWorkOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColOrderNo,
            this.colWorkNameItem,
            this.ColWorkTime});
            this.dataGridPerformedWorkOrder.ContextMenuStrip = this.contextMenuPerformedWorkOrder;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPerformedWorkOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridPerformedWorkOrder.Location = new System.Drawing.Point(83, 13);
            this.dataGridPerformedWorkOrder.MinimumSize = new System.Drawing.Size(174, 100);
            this.dataGridPerformedWorkOrder.MultiSelect = false;
            this.dataGridPerformedWorkOrder.Name = "dataGridPerformedWorkOrder";
            this.dataGridPerformedWorkOrder.RowHeadersVisible = false;
            this.dataGridPerformedWorkOrder.RowTemplate.Height = 21;
            this.dataGridPerformedWorkOrder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridPerformedWorkOrder.Size = new System.Drawing.Size(418, 635);
            this.dataGridPerformedWorkOrder.TabIndex = 0;
            this.dataGridPerformedWorkOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPerformedWorkOrder_CellDoubleClick);
            this.dataGridPerformedWorkOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPerformedWorkOrder_CellEndEdit);
            this.dataGridPerformedWorkOrder.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPerformedWorkOrder_CellValidated);
            // 
            // ColOrderNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColOrderNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColOrderNo.HeaderText = "オーダーNo.";
            this.ColOrderNo.Name = "ColOrderNo";
            this.ColOrderNo.Width = 90;
            // 
            // colWorkNameItem
            // 
            this.colWorkNameItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colWorkNameItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWorkNameItem.HeaderText = "作業名称";
            this.colWorkNameItem.Name = "colWorkNameItem";
            // 
            // ColWorkTime
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColWorkTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColWorkTime.HeaderText = "工数(H)";
            this.ColWorkTime.Name = "ColWorkTime";
            this.ColWorkTime.Width = 70;
            // 
            // contextMenuPerformedWorkOrder
            // 
            this.contextMenuPerformedWorkOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuAdd,
            this.ToolStripMenuDelete});
            this.contextMenuPerformedWorkOrder.Name = "contextMenuPerformedWorkOrder";
            this.contextMenuPerformedWorkOrder.Size = new System.Drawing.Size(99, 48);
            // 
            // ToolStripMenuAdd
            // 
            this.ToolStripMenuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPre,
            this.ToolStripMenuItemAddNext});
            this.ToolStripMenuAdd.Name = "ToolStripMenuAdd";
            this.ToolStripMenuAdd.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenuAdd.Text = "追加";
            // 
            // ToolStripMenuItemAddPre
            // 
            this.ToolStripMenuItemAddPre.Name = "ToolStripMenuItemAddPre";
            this.ToolStripMenuItemAddPre.Size = new System.Drawing.Size(96, 22);
            this.ToolStripMenuItemAddPre.Text = "前へ";
            this.ToolStripMenuItemAddPre.Click += new System.EventHandler(this.ToolStripMenuItemAddPre_Click);
            // 
            // ToolStripMenuItemAddNext
            // 
            this.ToolStripMenuItemAddNext.Name = "ToolStripMenuItemAddNext";
            this.ToolStripMenuItemAddNext.Size = new System.Drawing.Size(96, 22);
            this.ToolStripMenuItemAddNext.Text = "次へ";
            this.ToolStripMenuItemAddNext.Click += new System.EventHandler(this.ToolStripMenuItemAddNext_Click);
            // 
            // ToolStripMenuDelete
            // 
            this.ToolStripMenuDelete.Name = "ToolStripMenuDelete";
            this.ToolStripMenuDelete.Size = new System.Drawing.Size(98, 22);
            this.ToolStripMenuDelete.Text = "削除";
            this.ToolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDelete_Click);
            // 
            // tbWorkTimeScale
            // 
            this.tbWorkTimeScale.BackColor = System.Drawing.SystemColors.Menu;
            this.tbWorkTimeScale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWorkTimeScale.Location = new System.Drawing.Point(40, 29);
            this.tbWorkTimeScale.Name = "tbWorkTimeScale";
            this.tbWorkTimeScale.Size = new System.Drawing.Size(37, 12);
            this.tbWorkTimeScale.TabIndex = 3;
            this.tbWorkTimeScale.Text = "08:30";
            this.tbWorkTimeScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbWorkTimeScale.Leave += new System.EventHandler(this.tbWorkTimeScale_Leave);
            // 
            // PerformedWorkOrderGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.dataGridPerformedWorkOrder);
            this.Controls.Add(this.tbWorkTimeScale);
            this.Name = "PerformedWorkOrderGridView";
            this.Size = new System.Drawing.Size(504, 651);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerformedWorkOrder)).EndInit();
            this.contextMenuPerformedWorkOrder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPerformedWorkOrder;
        private System.Windows.Forms.ContextMenuStrip contextMenuPerformedWorkOrder;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuDelete;
        private System.Windows.Forms.TextBox tbWorkTimeScale;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPre;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkNameItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWorkTime;
    }
}
