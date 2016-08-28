namespace jdWatch
{
    partial class uiWatch
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
            this.comboBoxUiWatchColor = new System.Windows.Forms.ComboBox();
            this.comboBoxUiWatchSerial = new System.Windows.Forms.ComboBox();
            this.comboBoxUiWatchPName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUiWatchSeleSkuid = new System.Windows.Forms.TextBox();
            this.buttonUiWatchSeachSkuid = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUiWatch = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUiWatchFrq = new System.Windows.Forms.TextBox();
            this.buttonUiWatchAddToWatch = new System.Windows.Forms.Button();
            this.buttonUiWatchSele = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiWatch)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUiWatchColor
            // 
            this.comboBoxUiWatchColor.FormattingEnabled = true;
            this.comboBoxUiWatchColor.Location = new System.Drawing.Point(348, 21);
            this.comboBoxUiWatchColor.Name = "comboBoxUiWatchColor";
            this.comboBoxUiWatchColor.Size = new System.Drawing.Size(112, 20);
            this.comboBoxUiWatchColor.TabIndex = 5;
            this.comboBoxUiWatchColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxUiWatchColor_SelectedIndexChanged);
            // 
            // comboBoxUiWatchSerial
            // 
            this.comboBoxUiWatchSerial.FormattingEnabled = true;
            this.comboBoxUiWatchSerial.Location = new System.Drawing.Point(195, 21);
            this.comboBoxUiWatchSerial.Name = "comboBoxUiWatchSerial";
            this.comboBoxUiWatchSerial.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUiWatchSerial.TabIndex = 4;
            this.comboBoxUiWatchSerial.SelectedIndexChanged += new System.EventHandler(this.comboBoxUiWatchSerial_SelectedIndexChanged);
            // 
            // comboBoxUiWatchPName
            // 
            this.comboBoxUiWatchPName.FormattingEnabled = true;
            this.comboBoxUiWatchPName.Location = new System.Drawing.Point(40, 21);
            this.comboBoxUiWatchPName.Name = "comboBoxUiWatchPName";
            this.comboBoxUiWatchPName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUiWatchPName.TabIndex = 3;
            this.comboBoxUiWatchPName.DropDown += new System.EventHandler(this.comboBoxUiWatchPName_DropDown);
            this.comboBoxUiWatchPName.SelectedIndexChanged += new System.EventHandler(this.comboBoxUiWatchPName_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxUiWatchColor);
            this.groupBox2.Controls.Add(this.comboBoxUiWatchSerial);
            this.groupBox2.Controls.Add(this.comboBoxUiWatchPName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 55);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "颜色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "系列";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "品牌";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxUiWatchSeleSkuid);
            this.groupBox1.Controls.Add(this.buttonUiWatchSeachSkuid);
            this.groupBox1.Location = new System.Drawing.Point(486, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 55);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索方式2";
            this.groupBox1.Visible = false;
            // 
            // textBoxUiWatchSeleSkuid
            // 
            this.textBoxUiWatchSeleSkuid.Location = new System.Drawing.Point(14, 21);
            this.textBoxUiWatchSeleSkuid.Name = "textBoxUiWatchSeleSkuid";
            this.textBoxUiWatchSeleSkuid.Size = new System.Drawing.Size(91, 21);
            this.textBoxUiWatchSeleSkuid.TabIndex = 1;
            this.textBoxUiWatchSeleSkuid.Visible = false;
            // 
            // buttonUiWatchSeachSkuid
            // 
            this.buttonUiWatchSeachSkuid.Location = new System.Drawing.Point(111, 18);
            this.buttonUiWatchSeachSkuid.Name = "buttonUiWatchSeachSkuid";
            this.buttonUiWatchSeachSkuid.Size = new System.Drawing.Size(91, 23);
            this.buttonUiWatchSeachSkuid.TabIndex = 0;
            this.buttonUiWatchSeachSkuid.Text = "搜索商品编号";
            this.buttonUiWatchSeachSkuid.UseVisualStyleBackColor = true;
            this.buttonUiWatchSeachSkuid.Visible = false;
            this.buttonUiWatchSeachSkuid.Click += new System.EventHandler(this.buttonUiWatchSeachSkuid_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewUiWatch);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxUiWatchFrq);
            this.groupBox3.Controls.Add(this.buttonUiWatchAddToWatch);
            this.groupBox3.Controls.Add(this.buttonUiWatchSele);
            this.groupBox3.Location = new System.Drawing.Point(12, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(822, 317);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基本信息表";
            // 
            // dataGridViewUiWatch
            // 
            this.dataGridViewUiWatch.AllowUserToOrderColumns = true;
            this.dataGridViewUiWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUiWatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column12,
            this.Column11,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewUiWatch.Location = new System.Drawing.Point(6, 15);
            this.dataGridViewUiWatch.Name = "dataGridViewUiWatch";
            this.dataGridViewUiWatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridViewUiWatch.RowTemplate.Height = 23;
            this.dataGridViewUiWatch.Size = new System.Drawing.Size(802, 270);
            this.dataGridViewUiWatch.TabIndex = 12;
            this.dataGridViewUiWatch.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewUiWatch_RowsAdded);
            this.dataGridViewUiWatch.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewUiWatch_RowStateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "监控频率（分钟）";
            // 
            // textBoxUiWatchFrq
            // 
            this.textBoxUiWatchFrq.Location = new System.Drawing.Point(341, 289);
            this.textBoxUiWatchFrq.Name = "textBoxUiWatchFrq";
            this.textBoxUiWatchFrq.Size = new System.Drawing.Size(68, 21);
            this.textBoxUiWatchFrq.TabIndex = 3;
            this.textBoxUiWatchFrq.Text = "30";
            // 
            // buttonUiWatchAddToWatch
            // 
            this.buttonUiWatchAddToWatch.Location = new System.Drawing.Point(142, 288);
            this.buttonUiWatchAddToWatch.Name = "buttonUiWatchAddToWatch";
            this.buttonUiWatchAddToWatch.Size = new System.Drawing.Size(75, 23);
            this.buttonUiWatchAddToWatch.TabIndex = 2;
            this.buttonUiWatchAddToWatch.Text = "加入监控";
            this.buttonUiWatchAddToWatch.UseVisualStyleBackColor = true;
            this.buttonUiWatchAddToWatch.Click += new System.EventHandler(this.buttonUiWatchAddToWatch_Click);
            // 
            // buttonUiWatchSele
            // 
            this.buttonUiWatchSele.Location = new System.Drawing.Point(40, 288);
            this.buttonUiWatchSele.Name = "buttonUiWatchSele";
            this.buttonUiWatchSele.Size = new System.Drawing.Size(75, 23);
            this.buttonUiWatchSele.TabIndex = 1;
            this.buttonUiWatchSele.Text = "全选";
            this.buttonUiWatchSele.UseVisualStyleBackColor = true;
            this.buttonUiWatchSele.Click += new System.EventHandler(this.buttonUiWatchSele_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "品牌";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "系列";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "颜色";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "版本";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "商品编号";
            this.Column12.Name = "Column12";
            this.Column12.Width = 80;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "商家";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "控价";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // uiWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 403);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "uiWatch";
            this.Text = "uiWatch";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiWatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUiWatchColor;
        private System.Windows.Forms.ComboBox comboBoxUiWatchSerial;
        private System.Windows.Forms.ComboBox comboBoxUiWatchPName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxUiWatchSeleSkuid;
        private System.Windows.Forms.Button buttonUiWatchSeachSkuid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonUiWatchAddToWatch;
        private System.Windows.Forms.Button buttonUiWatchSele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUiWatchFrq;
        private System.Windows.Forms.DataGridView dataGridViewUiWatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}