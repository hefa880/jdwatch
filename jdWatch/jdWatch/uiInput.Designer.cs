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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewUiIpnut = new System.Windows.Forms.DataGridView();
            this.buttonUiInputSelect = new System.Windows.Forms.Button();
            this.buttonUiInputGetWareInfor = new System.Windows.Forms.Button();
            this.buttonUiInputSaveToSql = new System.Windows.Forms.Button();
            this.buttonUiInputdel = new System.Windows.Forms.Button();
            this.buttonUiInputEditSql = new System.Windows.Forms.Button();
            this.textBoxUiInputCount = new System.Windows.Forms.TextBox();
            this.columnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSeller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSkuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSerial = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnVersion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPBaseInfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWarnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWarnPriceDirect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaveState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiIpnut)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUiIpnut
            // 
            this.dataGridViewUiIpnut.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUiIpnut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUiIpnut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUiIpnut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSelect,
            this.ColumnSeller,
            this.ColumnSkuid,
            this.ColumnPName,
            this.ColumnSerial,
            this.ColumnColor,
            this.ColumnVersion,
            this.ColumnPBaseInfor,
            this.ColumnWarnPrice,
            this.ColumnWarnPriceDirect,
            this.ColumnSaveState});
            this.dataGridViewUiIpnut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewUiIpnut.Location = new System.Drawing.Point(9, 12);
            this.dataGridViewUiIpnut.MultiSelect = false;
            this.dataGridViewUiIpnut.Name = "dataGridViewUiIpnut";
            this.dataGridViewUiIpnut.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridViewUiIpnut.RowTemplate.Height = 23;
            this.dataGridViewUiIpnut.Size = new System.Drawing.Size(1438, 449);
            this.dataGridViewUiIpnut.TabIndex = 0;
            this.dataGridViewUiIpnut.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewUiIpnut_RowsAdded);
            this.dataGridViewUiIpnut.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewUiIpnut_RowStateChanged);
            // 
            // buttonUiInputSelect
            // 
            this.buttonUiInputSelect.Location = new System.Drawing.Point(37, 467);
            this.buttonUiInputSelect.Name = "buttonUiInputSelect";
            this.buttonUiInputSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputSelect.TabIndex = 1;
            this.buttonUiInputSelect.Text = "全选";
            this.buttonUiInputSelect.UseVisualStyleBackColor = true;
            this.buttonUiInputSelect.Click += new System.EventHandler(this.buttonUiInputSelect_Click);
            // 
            // buttonUiInputGetWareInfor
            // 
            this.buttonUiInputGetWareInfor.Location = new System.Drawing.Point(174, 467);
            this.buttonUiInputGetWareInfor.Name = "buttonUiInputGetWareInfor";
            this.buttonUiInputGetWareInfor.Size = new System.Drawing.Size(95, 23);
            this.buttonUiInputGetWareInfor.TabIndex = 2;
            this.buttonUiInputGetWareInfor.Text = "获取商品信息";
            this.buttonUiInputGetWareInfor.UseVisualStyleBackColor = true;
            this.buttonUiInputGetWareInfor.Click += new System.EventHandler(this.buttonUiInputGetWareInfor_Click);
            // 
            // buttonUiInputSaveToSql
            // 
            this.buttonUiInputSaveToSql.Location = new System.Drawing.Point(346, 467);
            this.buttonUiInputSaveToSql.Name = "buttonUiInputSaveToSql";
            this.buttonUiInputSaveToSql.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputSaveToSql.TabIndex = 3;
            this.buttonUiInputSaveToSql.Text = "保存";
            this.buttonUiInputSaveToSql.UseVisualStyleBackColor = true;
            this.buttonUiInputSaveToSql.Click += new System.EventHandler(this.buttonUiInputSaveToSql_Click);
            // 
            // buttonUiInputdel
            // 
            this.buttonUiInputdel.Location = new System.Drawing.Point(480, 467);
            this.buttonUiInputdel.Name = "buttonUiInputdel";
            this.buttonUiInputdel.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputdel.TabIndex = 4;
            this.buttonUiInputdel.Text = "删除";
            this.buttonUiInputdel.UseVisualStyleBackColor = true;
            this.buttonUiInputdel.Click += new System.EventHandler(this.buttonUiInputdel_Click);
            // 
            // buttonUiInputEditSql
            // 
            this.buttonUiInputEditSql.Location = new System.Drawing.Point(627, 467);
            this.buttonUiInputEditSql.Name = "buttonUiInputEditSql";
            this.buttonUiInputEditSql.Size = new System.Drawing.Size(75, 23);
            this.buttonUiInputEditSql.TabIndex = 5;
            this.buttonUiInputEditSql.Text = "编辑数据库";
            this.buttonUiInputEditSql.UseVisualStyleBackColor = true;
            this.buttonUiInputEditSql.Click += new System.EventHandler(this.buttonUiInputEditSql_Click);
            // 
            // textBoxUiInputCount
            // 
            this.textBoxUiInputCount.Location = new System.Drawing.Point(901, 467);
            this.textBoxUiInputCount.Name = "textBoxUiInputCount";
            this.textBoxUiInputCount.ReadOnly = true;
            this.textBoxUiInputCount.Size = new System.Drawing.Size(142, 21);
            this.textBoxUiInputCount.TabIndex = 6;
            // 
            // columnSelect
            // 
            this.columnSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnSelect.HeaderText = "选择";
            this.columnSelect.Name = "columnSelect";
            this.columnSelect.Width = 35;
            // 
            // ColumnSeller
            // 
            this.ColumnSeller.HeaderText = "商家";
            this.ColumnSeller.Name = "ColumnSeller";
            this.ColumnSeller.Width = 180;
            // 
            // ColumnSkuid
            // 
            this.ColumnSkuid.HeaderText = "商品编号";
            this.ColumnSkuid.Name = "ColumnSkuid";
            // 
            // ColumnPName
            // 
            this.ColumnPName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnPName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnPName.HeaderText = "品牌";
            this.ColumnPName.Name = "ColumnPName";
            this.ColumnPName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPName.Width = 120;
            // 
            // ColumnSerial
            // 
            this.ColumnSerial.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnSerial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnSerial.HeaderText = "系列";
            this.ColumnSerial.Name = "ColumnSerial";
            this.ColumnSerial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSerial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSerial.Width = 120;
            // 
            // ColumnColor
            // 
            this.ColumnColor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnColor.HeaderText = "颜色";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnColor.Width = 120;
            // 
            // ColumnVersion
            // 
            this.ColumnVersion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnVersion.HeaderText = "版本";
            this.ColumnVersion.Name = "ColumnVersion";
            this.ColumnVersion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnVersion.Width = 180;
            // 
            // ColumnPBaseInfor
            // 
            this.ColumnPBaseInfor.HeaderText = "商品描述";
            this.ColumnPBaseInfor.Name = "ColumnPBaseInfor";
            this.ColumnPBaseInfor.Width = 300;
            // 
            // ColumnWarnPrice
            // 
            this.ColumnWarnPrice.HeaderText = "控价";
            this.ColumnWarnPrice.Name = "ColumnWarnPrice";
            this.ColumnWarnPrice.Width = 70;
            // 
            // ColumnWarnPriceDirect
            // 
            this.ColumnWarnPriceDirect.HeaderText = "控价方向";
            this.ColumnWarnPriceDirect.Name = "ColumnWarnPriceDirect";
            this.ColumnWarnPriceDirect.ReadOnly = true;
            this.ColumnWarnPriceDirect.Width = 80;
            // 
            // ColumnSaveState
            // 
            this.ColumnSaveState.HeaderText = "状态";
            this.ColumnSaveState.Name = "ColumnSaveState";
            // 
            // uiInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 494);
            this.Controls.Add(this.textBoxUiInputCount);
            this.Controls.Add(this.buttonUiInputEditSql);
            this.Controls.Add(this.buttonUiInputdel);
            this.Controls.Add(this.buttonUiInputSaveToSql);
            this.Controls.Add(this.buttonUiInputGetWareInfor);
            this.Controls.Add(this.buttonUiInputSelect);
            this.Controls.Add(this.dataGridViewUiIpnut);
            this.Name = "uiInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiIpnut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUiIpnut;
        private System.Windows.Forms.Button buttonUiInputSelect;
        private System.Windows.Forms.Button buttonUiInputGetWareInfor;
        private System.Windows.Forms.Button buttonUiInputSaveToSql;
        private System.Windows.Forms.Button buttonUiInputdel;
        private System.Windows.Forms.Button buttonUiInputEditSql;
        private System.Windows.Forms.TextBox textBoxUiInputCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSkuid;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSerial;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnColor;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPBaseInfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWarnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWarnPriceDirect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaveState;
    }
}