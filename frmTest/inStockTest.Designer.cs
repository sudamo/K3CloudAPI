namespace Dev.frmTest
{
    partial class inStockTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inStockTest));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblStock = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxInStock = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblStocker = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxInStocker = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnInStock = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 25);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(664, 487);
            this.dgv1.TabIndex = 3;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblStock,
            this.bnTop_cbxInStock,
            this.bnTop_lblStocker,
            this.bnTop_cbxInStocker,
            this.toolStripSeparator1,
            this.bnTop_btnSearch,
            this.toolStripSeparator2,
            this.bnTop_btnInStock});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(664, 25);
            this.bnTop.TabIndex = 2;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_lblStock
            // 
            this.bnTop_lblStock.Name = "bnTop_lblStock";
            this.bnTop_lblStock.Size = new System.Drawing.Size(56, 22);
            this.bnTop_lblStock.Text = "入库仓库";
            // 
            // bnTop_cbxInStock
            // 
            this.bnTop_cbxInStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxInStock.Name = "bnTop_cbxInStock";
            this.bnTop_cbxInStock.Size = new System.Drawing.Size(121, 25);
            // 
            // bnTop_lblStocker
            // 
            this.bnTop_lblStocker.Name = "bnTop_lblStocker";
            this.bnTop_lblStocker.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblStocker.Text = "仓管员";
            // 
            // bnTop_cbxInStocker
            // 
            this.bnTop_cbxInStocker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxInStocker.Name = "bnTop_cbxInStocker";
            this.bnTop_cbxInStocker.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnTop_btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("bnTop_btnSearch.Image")));
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(36, 22);
            this.bnTop_btnSearch.Text = "刷新";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnInStock
            // 
            this.bnTop_btnInStock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bnTop_btnInStock.Image = ((System.Drawing.Image)(resources.GetObject("bnTop_btnInStock.Image")));
            this.bnTop_btnInStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnInStock.Name = "bnTop_btnInStock";
            this.bnTop_btnInStock.Size = new System.Drawing.Size(60, 22);
            this.bnTop_btnInStock.Text = "采购入库";
            // 
            // inStockTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 512);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.bnTop);
            this.Name = "inStockTest";
            this.Text = "测试Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripLabel bnTop_lblStock;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxInStock;
        private System.Windows.Forms.ToolStripLabel bnTop_lblStocker;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxInStocker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bnTop_btnInStock;
    }
}