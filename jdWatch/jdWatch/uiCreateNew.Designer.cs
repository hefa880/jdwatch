namespace jdWatch
{
    partial class uiCreateNew
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
            this.dataGridViewUiCreateNew = new System.Windows.Forms.DataGridView();
            this.buttonUiCreateNewSave = new System.Windows.Forms.Button();
            this.buttonUiCreateNewSelect = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiCreateNew)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUiCreateNew
            // 
            this.dataGridViewUiCreateNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUiCreateNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dataGridViewUiCreateNew.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewUiCreateNew.Name = "dataGridViewUiCreateNew";
            this.dataGridViewUiCreateNew.RowTemplate.Height = 23;
            this.dataGridViewUiCreateNew.Size = new System.Drawing.Size(634, 322);
            this.dataGridViewUiCreateNew.TabIndex = 0;
            // 
            // buttonUiCreateNewSave
            // 
            this.buttonUiCreateNewSave.Location = new System.Drawing.Point(321, 365);
            this.buttonUiCreateNewSave.Name = "buttonUiCreateNewSave";
            this.buttonUiCreateNewSave.Size = new System.Drawing.Size(105, 23);
            this.buttonUiCreateNewSave.TabIndex = 1;
            this.buttonUiCreateNewSave.Text = "保存";
            this.buttonUiCreateNewSave.UseVisualStyleBackColor = true;
            this.buttonUiCreateNewSave.Click += new System.EventHandler(this.buttonUiCreateNewSave_Click);
            // 
            // buttonUiCreateNewSelect
            // 
            this.buttonUiCreateNewSelect.Location = new System.Drawing.Point(90, 366);
            this.buttonUiCreateNewSelect.Name = "buttonUiCreateNewSelect";
            this.buttonUiCreateNewSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonUiCreateNewSelect.TabIndex = 2;
            this.buttonUiCreateNewSelect.Text = "全选";
            this.buttonUiCreateNewSelect.UseVisualStyleBackColor = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "选择";
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "牌品";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "系列";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "颜色";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "版本";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // uiCreateNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 394);
            this.Controls.Add(this.buttonUiCreateNewSelect);
            this.Controls.Add(this.buttonUiCreateNewSave);
            this.Controls.Add(this.dataGridViewUiCreateNew);
            this.Name = "uiCreateNew";
            this.Text = "uiCreateNew";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUiCreateNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUiCreateNew;
        private System.Windows.Forms.Button buttonUiCreateNewSave;
        private System.Windows.Forms.Button buttonUiCreateNewSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}