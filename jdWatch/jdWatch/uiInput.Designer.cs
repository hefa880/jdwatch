namespace jdWatch
{
    partial class uiInput
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
            this.dataGridViewUiIpnut = new System.Windows.Forms.DataGridView();
            this.buttonUiInputSelect = new System.Windows.Forms.Button();
            this.buttonUiInputGetWareInfor = new System.Windows.Forms.Button();
            this.buttonUiInputSaveToSql = new System.Windows.Forms.Button();
            this.buttonUiInputdel = new System.Windows.Forms.Button();
            this.column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiIpnut)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUiIpnut
            // 
            this.dataGridViewUiIpnut.AllowUserToOrderColumns = true;
            this.dataGridViewUiIpnut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUiIpnut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridViewUiIpnut.Location = new System.Drawing.Point(9, 12);
            this.dataGridViewUiIpnut.Name = "dataGridViewUiIpnut";
            this.dataGridViewUiIpnut.RowTemplate.Height = 23;
            this.dataGridViewUiIpnut.Size = new System.Drawing.Size(1438, 449);
            this.dataGridViewUiIpnut.TabIndex = 0;
            // 
            // buttonUiInputSelect
            // 
            this.buttonUiInputSelect.Location = new System.Drawing.Point(37, 467);
            this.buttonUiInputSelect.Name = "buttonUiInputSelect";
            this.buttonUiInputSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputSelect.TabIndex = 1;
            this.buttonUiInputSelect.Text = "全选";
            this.buttonUiInputSelect.UseVisualStyleBackColor = true;
            // 
            // buttonUiInputGetWareInfor
            // 
            this.buttonUiInputGetWareInfor.Location = new System.Drawing.Point(182, 468);
            this.buttonUiInputGetWareInfor.Name = "buttonUiInputGetWareInfor";
            this.buttonUiInputGetWareInfor.Size = new System.Drawing.Size(95, 23);
            this.buttonUiInputGetWareInfor.TabIndex = 2;
            this.buttonUiInputGetWareInfor.Text = "获取商品信息";
            this.buttonUiInputGetWareInfor.UseVisualStyleBackColor = true;
            // 
            // buttonUiInputSaveToSql
            // 
            this.buttonUiInputSaveToSql.Location = new System.Drawing.Point(334, 467);
            this.buttonUiInputSaveToSql.Name = "buttonUiInputSaveToSql";
            this.buttonUiInputSaveToSql.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputSaveToSql.TabIndex = 3;
            this.buttonUiInputSaveToSql.Text = "保存";
            this.buttonUiInputSaveToSql.UseVisualStyleBackColor = true;
            // 
            // buttonUiInputdel
            // 
            this.buttonUiInputdel.Location = new System.Drawing.Point(465, 468);
            this.buttonUiInputdel.Name = "buttonUiInputdel";
            this.buttonUiInputdel.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputdel.TabIndex = 4;
            this.buttonUiInputdel.Text = "删除";
            this.buttonUiInputdel.UseVisualStyleBackColor = true;
            // 
            // column1
            // 
            this.column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.column1.HeaderText = "选择";
            this.column1.Name = "column1";
            this.column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "品牌";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "系列";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "颜色";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "版本";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 180;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "商品描述";
            this.Column6.Name = "Column6";
            this.Column6.Width = 300;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "商品编号";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "商家";
            this.Column8.Name = "Column8";
            this.Column8.Width = 180;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "控价";
            this.Column9.Name = "Column9";
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "控价方向";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "状态";
            this.Column11.Name = "Column11";
            // 
            // uiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 494);
            this.Controls.Add(this.buttonUiInputdel);
            this.Controls.Add(this.buttonUiInputSaveToSql);
            this.Controls.Add(this.buttonUiInputGetWareInfor);
            this.Controls.Add(this.buttonUiInputSelect);
            this.Controls.Add(this.dataGridViewUiIpnut);
            this.Name = "uiInput";
            this.Text = "录入";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiIpnut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUiIpnut;
        private System.Windows.Forms.Button buttonUiInputSelect;
        private System.Windows.Forms.Button buttonUiInputGetWareInfor;
        private System.Windows.Forms.Button buttonUiInputSaveToSql;
        private System.Windows.Forms.Button buttonUiInputdel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}