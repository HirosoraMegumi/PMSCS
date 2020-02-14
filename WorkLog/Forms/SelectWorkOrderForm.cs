using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WorkLog.Forms
{
    public partial class SelectWorkOrderForm : Form
    {
        private string DIRECT_NODE_NAME = "直接作業";
        private string INDIRECT_NODE_NAME = "間接作業";

        private Data.WorkOrderItem _selectworkorderItem = null;

        private Data.TempWorkOrderItem _selectTempWorkOrderItem = null;

        private string _UsersDepartmentID = "";

        private int _UserEmpID;

        /// <summary>
        /// 一時作業情報が新しいかフラグ
        /// </summary>
        private Boolean _tempWorkIsNew = false;

        /// <summary>
        /// 追加された一時オーダー情報
        /// </summary>
        private string _newTempWorkNo = null;

        /// <summary>
        /// 選択した作業情報
        /// </summary>
        public Data.WorkOrderItem SelectWorkOrderItem
        { get
            {
                if (_selectworkorderItem == null)
                {
                    _selectworkorderItem = new Data.WorkOrderItem();
                    _selectworkorderItem.WorkOrderNo = _selectTempWorkOrderItem.WorkOrderNo;
                    _selectworkorderItem.WorkOrderID = _selectTempWorkOrderItem.WorkOrderID;
                    _selectworkorderItem.WorkName = _selectTempWorkOrderItem.WorkName;
                }
                return _selectworkorderItem;
            }
        }
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="UsersDepartmentID"></param>
        /// <param name="UserEmpID"></param>
        public SelectWorkOrderForm(string UsersDepartmentID, int UserEmpID)
        {
            InitializeComponent();

            this._UsersDepartmentID = UsersDepartmentID;
            this._UserEmpID = UserEmpID;

            //初期設定
            SetData();

        }

        #region フォームイベント

        /// <summary>
        /// フォーム: ショーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectWorkOrderForm_Shown(object sender, EventArgs e)
        {
            // ツリービューでユーザーの部署を選択
            foreach (TreeNode rootitem in this.treeView.Nodes[0].Nodes)
            {
                if (rootitem.Text == DIRECT_NODE_NAME)
                {
                    foreach (TreeNode item in rootitem.Nodes)
                    {
                        Data.AcceptDepartmentInfo info = (Data.AcceptDepartmentInfo)item.Tag;
                        if (this._UsersDepartmentID == info.DepartmentID)
                        {
                            this.treeView.SelectedNode = item;
                            this.treeView.Focus();
                            break;
                        }
                    }
                }
            }

            // 初期表示
            SetDataInDataGridView(this.treeView.SelectedNode);

            SetDataInTempDataGridView();

        }

        /// <summary>
        /// キャンセルボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// OKボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // チェック
                if (this.dataGridView.SelectedRows.Count > 1 || this.tempDataGridView.SelectedRows.Count > 1)
                {
                    throw new Exception("複数の作業を選択しています。");
                }
                else if (this.dataGridView.SelectedRows.Count == 0)
                {
                    if (this.tempDataGridView.SelectedRows.Count == 0)
                    {
                        throw new Exception("開始する作業を選択してください。");
                    }
                }
                if (this.dataGridView.SelectedRows.Count == 1)
                {
                    this._selectworkorderItem = (Data.WorkOrderItem)this.dataGridView.SelectedRows[0].Tag;
                }
                else
                {
                    this._selectTempWorkOrderItem = (Data.TempWorkOrderItem)this.tempDataGridView.SelectedRows[0].Tag;

                    if (this._tempWorkIsNew)
                    {
                        // 一時作業情報が追加された場合
                        if (this._selectTempWorkOrderItem.WorkOrderNo.Equals(this._newTempWorkNo))
                        {
                            addTempWorkItemInfo(this._selectTempWorkOrderItem);

                            Manage.TempWorkOrderManage tempWorkOrderManage = new Manage.TempWorkOrderManage();
                            List<Data.TempWorkOrderItem> tempWorkList = tempWorkOrderManage.GetTempWorkOrderInfo(this._UserEmpID);
                            this._selectTempWorkOrderItem.WorkOrderID = tempWorkList[tempWorkList.Count - 1].WorkOrderID;
                        }
                        else
                        {
                            MessageBox.Show("追加された一時オーダー情報を廃棄されますか？");
                        }
                    }
                    
                    this.dataGridView.ClearSelection();

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addTempWorkItemInfo(Data.TempWorkOrderItem tempWorkOrderItem)
        {
            Manage.TempWorkOrderManage tempWorkOrderManage = new Manage.TempWorkOrderManage();
            tempWorkOrderItem.EmpID = this._UserEmpID;
            tempWorkOrderManage.AddTempWorkOrderItem(tempWorkOrderItem);
        }

        /// <summary>
        /// TreeView: ノードクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo ht = this.treeView.HitTest(e.Location);

            if (ht.Location == TreeViewHitTestLocations.Label)
            {
                // テキスト部分をクリックした時

                // クリア
                this.dataGridView.Rows.Clear();

                // 設定
                SetDataInDataGridView(e.Node);
            }


        }
        /// <summary>
        /// 検索ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbSearch.Text == "")
                {
                    this.dataGridView.Rows.Clear();
                    SetDataInDataGridView(this.treeView.SelectedNode);
                }
                SearchWorkOrder(this.tbSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 未終了作業のみチェックボックス: チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbOnlyUnfinishedWork_CheckedChanged(object sender, EventArgs e)
        {
            // 設定
            ChangeDisplayCondition();
        }

        /// <summary>
        /// 期コンボボックス: コミットイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combPeriod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 設定
            ChangeDisplayCondition();
        }



        #endregion

        /// <summary>
        /// 各コントロールにデータを設定
        /// </summary>
        private void SetData()
        {
            // ツリービューにデータを設定 

            TreeNode RootNode = new TreeNode("全作業");

            TreeNode DirectNode = new TreeNode(DIRECT_NODE_NAME);
            TreeNode IndirectNode = new TreeNode(INDIRECT_NODE_NAME);

            // 作業情報取得
            Manage.WorkOrderViewManage woManage = new Manage.WorkOrderViewManage();
            List<Data.WorkOrderItem> woList = woManage.GetWorkOrderInfoMaster();

            //--------------------------------------------------
            // 直接作業 - 管理部署
            //--------------------------------------------------
            // 部署一覧取得
            Manage.DepartmentMasterManage dpManage = new Manage.DepartmentMasterManage();
            List<Data.DepartmentItem> DirectDpList = dpManage.GetDepartmentInfoOfConstructType(WorkType.Direct);

            foreach (Data.DepartmentItem item in DirectDpList)
            {
                var AddList = woList.FindAll(x => x.ConstructOrderType == (int)WorkType.Direct && x.AcceptDepartmentID == item.DepartmentID);
                if (AddList.Count > 0)
                {
                    Data.AcceptDepartmentInfo addItem = new Data.AcceptDepartmentInfo(item);
                    addItem.WorkOrderList = AddList;

                    TreeNode node = new TreeNode(item.DepartmentName);
                    node.Tag = addItem;
                    DirectNode.Nodes.Add(node);

                }

            }

            //--------------------------------------------------
            // 間接作業 - 管理部署
            //--------------------------------------------------
            List<Data.DepartmentItem> IndirectDpList = dpManage.GetDepartmentInfoOfConstructType(WorkType.Indirect);

            foreach (Data.DepartmentItem item in IndirectDpList)
            {
                var AddList = woList.FindAll(x => x.ConstructOrderType == (int)WorkType.Indirect && x.AcceptDepartmentID == item.DepartmentID);
                if (AddList.Count > 0)
                {
                    Data.AcceptDepartmentInfo addItem = new Data.AcceptDepartmentInfo(item);
                    addItem.WorkOrderList = AddList;

                    TreeNode node = new TreeNode(item.DepartmentName);
                    node.Tag = addItem;
                    IndirectNode.Nodes.Add(node);
                }

            }

            RootNode.Nodes.Add(DirectNode);
            RootNode.Nodes.Add(IndirectNode);

            this.treeView.Nodes.Add(RootNode);


            // 期ドロップダウンリストにデータを設定
            var bufList = woList.ConvertAll(x => Convert.ToString(x.Period));
            var sPeriodList = bufList.Distinct().ToArray();

            Array.Sort(sPeriodList);
            Array.Reverse(sPeriodList);
            this.combPeriod.Items.AddRange(sPeriodList);

            this.combPeriod.SelectedIndex = 0;
        }

        /// <summary>
        /// DataGridViewにデータを設定
        /// </summary>
        /// <param name="TargetNode">表示する作業オーダーを持つNode</param>
        private void SetDataInDataGridView(TreeNode TargetNode)
        {
            if (TargetNode.Nodes.Count == 0)
            {
                // DataGridViewに作業オーダーを表示
                Data.AcceptDepartmentInfo DepartmentItem = (Data.AcceptDepartmentInfo)TargetNode.Tag;
                ShowWorkOrderInDataGridView(DepartmentItem.WorkOrderList);
            }
            else
            {
                // 子ノードを持っている場合
                foreach (TreeNode node in TargetNode.Nodes)
                {
                    SetDataInDataGridView(node);
                }
            }

        }

        /// <summary>
        /// TempDataGridViewにデータを設定
        /// </summary>
        private void SetDataInTempDataGridView()
        {
            Manage.TempWorkOrderManage tempWorkOrderManage = new Manage.TempWorkOrderManage();
            List<Data.TempWorkOrderItem> tempWorkList = tempWorkOrderManage.GetTempWorkOrderInfo(this._UserEmpID);
            foreach(Data.TempWorkOrderItem tempWorkOrderItem in tempWorkList)
            {
                int index = this.tempDataGridView.Rows.Add();

                DataGridViewRow rAddItem = this.tempDataGridView.Rows[index];

                rAddItem.Cells[this.TempColWorkName.Index].Value = tempWorkOrderItem.WorkName;
                rAddItem.Cells[this.TempColWorkOrderNo.Index].Value = tempWorkOrderItem.WorkOrderNo;

                rAddItem.Tag = tempWorkOrderItem;
                this.tempDataGridView.ClearSelection();

            }
            this.dataGridView.ClearSelection();
        }

        /// <summary>
        /// DataGridViewにオーダーを表示
        /// </summary>
        /// <param name="list">表示するオーダーリスト</param>
        private void ShowWorkOrderInDataGridView(List<Data.WorkOrderItem> list)
        {
            List<Data.WorkOrderItem> Addlist;

            // 期
            int TargetPeriod = Convert.ToInt32(this.combPeriod.SelectedItem);

            if (this.ckbOnlyUnfinishedWork.Checked)
            {
                // 未終了作業のみ
                Addlist = list.FindAll(x => x.EndDate.HasValue == false && x.Period == TargetPeriod);
            }
            else
            {
                Addlist = list.FindAll(x => x.Period == TargetPeriod);
            }
            

            foreach (Data.WorkOrderItem WorkOrderItem in Addlist)
            {
                // 新しい行の追加
                int index = this.dataGridView.Rows.Add();

                // 行の取得
                DataGridViewRow rAddItem = this.dataGridView.Rows[index];

                rAddItem.Cells[this.ColChargeDepartment.Index].Value = WorkOrderItem.ChargeDepartmentName;
                rAddItem.Cells[this.ColAcceptDepartment.Index].Value = WorkOrderItem.AcceptDepartmentName;
                rAddItem.Cells[this.ColWorkOrderNo.Index].Value = WorkOrderItem.WorkOrderNo;
                rAddItem.Cells[this.ColWorkName.Index].Value = WorkOrderItem.WorkName;

                if (WorkOrderItem.StartDate.HasValue)
                {
                    rAddItem.Cells[this.ColStartDate.Index].Value = WorkOrderItem.StartDate.Value.ToString("yyyy/MM/dd");
                }
                else
                {
                    rAddItem.Cells[this.ColStartDate.Index].Value = WorkOrderItem.StartDate;
                }

                if (WorkOrderItem.ScheduleEndDate.HasValue)
                {
                    rAddItem.Cells[this.ColScheduleEndDate.Index].Value = WorkOrderItem.ScheduleEndDate.Value.ToString("yyyy/MM/dd");
                }
                else
                {
                    rAddItem.Cells[this.ColScheduleEndDate.Index].Value = WorkOrderItem.ScheduleEndDate;
                }
                
                if(WorkOrderItem.EndDate.HasValue)
                {
                    rAddItem.Cells[this.ColEndDate.Index].Value = WorkOrderItem.EndDate.Value.ToString("yyyy/MM/dd");
                }
                else
                {
                    rAddItem.Cells[this.ColEndDate.Index].Value = WorkOrderItem.EndDate;
                }              
                rAddItem.Tag = WorkOrderItem;
            }
        }

        /// <summary>
        /// 作業オーダーを検索
        /// </summary>
        /// <param name="SearchText">検索用語</param>
        private void SearchWorkOrder(string SearchText)
        {
            List<Data.WorkOrderItem> MatchItemlist = new List<Data.WorkOrderItem>();
            this.dataGridView.Rows.Clear();
            SetDataInDataGridView(this.treeView.SelectedNode);
            foreach (DataGridViewRow item in this.dataGridView.Rows)
            {
                Data.WorkOrderItem itemInfo = (Data.WorkOrderItem)item.Tag;
                if (itemInfo.WorkName.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // 大文字小文字関係なく、検索用語を含んでいる作業名を取得
                    MatchItemlist.Add(itemInfo);
                }
            }

            // 検索用語を含んでいる作業名のみ表示
            this.dataGridView.Rows.Clear();
            ShowWorkOrderInDataGridView(MatchItemlist);
        }


        /// <summary>
        /// 表示条件を変更
        /// </summary>
        private void ChangeDisplayCondition()
        {
            // クリア
            this.dataGridView.Rows.Clear();
            // 選択されている部署の作業一覧を表示
            SetDataInDataGridView(this.treeView.SelectedNode);

            if (this.tbSearch.Text != "")
            {
                // 検索文字列がある場合　検索処理
                SearchWorkOrder(this.tbSearch.Text);
            }

        }

        /// <summary>
        /// 一時オーダー作成ボタン: クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemp_Click(object sender, EventArgs e)
        {
            
            try
            {
                TempWorkOrderForm tf = new TempWorkOrderForm();
                if (tf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._tempWorkIsNew = true;
                    this.btnTempWork.Enabled = false;
                    ShowTempWorkOrderInDataGridView(tf.TempWorkOrderItem.WorkName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// 一時作業の情報を表示する
        /// </summary>
        /// <param name="list"></param>
        private void ShowTempWorkOrderInDataGridView(String workName)
        {

            // 新しい行の追加
            int index = this.tempDataGridView.Rows.Add();

            // 行の取得
            DataGridViewRow rAddItem = this.tempDataGridView.Rows[index];

            // 一時作業情報
            Data.TempWorkOrderItem tempWorkOrderItem = new Data.TempWorkOrderItem();
            tempWorkOrderItem.WorkName = workName;

            if (index == 0)
            {
                tempWorkOrderItem.WorkOrderNo = "T001";
            }
            else
            {
                DataGridViewRow latestRow = this.tempDataGridView.Rows[index - 1];
                Data.TempWorkOrderItem latestTempWorkItem = (Data.TempWorkOrderItem)latestRow.Tag;
                tempWorkOrderItem.WorkOrderNo = "T" + (Int32.Parse(latestTempWorkItem.WorkOrderNo.Substring(1)) + 1).ToString("000");
            }
            

            
            

            rAddItem.Cells[this.TempColWorkName.Index].Value = workName;
            rAddItem.Cells[this.TempColWorkOrderNo.Index].Value = tempWorkOrderItem.WorkOrderNo;

            rAddItem.Tag = tempWorkOrderItem;

            this._newTempWorkNo = tempWorkOrderItem.WorkOrderNo;
        }

    
    }
}
