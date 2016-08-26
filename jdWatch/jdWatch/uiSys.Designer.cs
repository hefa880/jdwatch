namespace jdWatch
{
    partial class uiSys
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUiSysLoginType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUiSysCurrentUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUiSysCurrenPwd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUiSysModifyPwd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUiSysNewPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonUiSysSelect = new System.Windows.Forms.Button();
            this.buttonUiSysDel = new System.Windows.Forms.Button();
            this.buttonUiSysSaveToSql = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxUiSysLoginType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxUiSysCurrentUser);
            this.groupBox1.Location = new System.Drawing.Point(11, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前用户信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "权鉴";
            // 
            // textBoxUiSysLoginType
            // 
            this.textBoxUiSysLoginType.Location = new System.Drawing.Point(48, 65);
            this.textBoxUiSysLoginType.Name = "textBoxUiSysLoginType";
            this.textBoxUiSysLoginType.ReadOnly = true;
            this.textBoxUiSysLoginType.Size = new System.Drawing.Size(84, 21);
            this.textBoxUiSysLoginType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户";
            // 
            // textBoxUiSysCurrentUser
            // 
            this.textBoxUiSysCurrentUser.Location = new System.Drawing.Point(48, 20);
            this.textBoxUiSysCurrentUser.Name = "textBoxUiSysCurrentUser";
            this.textBoxUiSysCurrentUser.ReadOnly = true;
            this.textBoxUiSysCurrentUser.Size = new System.Drawing.Size(84, 21);
            this.textBoxUiSysCurrentUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码";
            // 
            // textBoxUiSysCurrenPwd
            // 
            this.textBoxUiSysCurrenPwd.Location = new System.Drawing.Point(80, 16);
            this.textBoxUiSysCurrenPwd.Name = "textBoxUiSysCurrenPwd";
            this.textBoxUiSysCurrenPwd.Size = new System.Drawing.Size(100, 21);
            this.textBoxUiSysCurrenPwd.TabIndex = 2;
            this.textBoxUiSysCurrenPwd.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonUiSysModifyPwd);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxUiSysNewPwd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxUiSysCurrenPwd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(196, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 97);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "密码修改";
            // 
            // buttonUiSysModifyPwd
            // 
            this.buttonUiSysModifyPwd.Location = new System.Drawing.Point(188, 40);
            this.buttonUiSysModifyPwd.Name = "buttonUiSysModifyPwd";
            this.buttonUiSysModifyPwd.Size = new System.Drawing.Size(80, 23);
            this.buttonUiSysModifyPwd.TabIndex = 9;
            this.buttonUiSysModifyPwd.Text = "修改";
            this.buttonUiSysModifyPwd.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 7;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "确认新密码";
            // 
            // textBoxUiSysNewPwd
            // 
            this.textBoxUiSysNewPwd.Location = new System.Drawing.Point(80, 42);
            this.textBoxUiSysNewPwd.Name = "textBoxUiSysNewPwd";
            this.textBoxUiSysNewPwd.Size = new System.Drawing.Size(100, 21);
            this.textBoxUiSysNewPwd.TabIndex = 5;
            this.textBoxUiSysNewPwd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "新密码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonUiSysSelect);
            this.groupBox3.Controls.Add(this.buttonUiSysDel);
            this.groupBox3.Controls.Add(this.buttonUiSysSaveToSql);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(7, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 219);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "员工用户管理";
            // 
            // buttonUiSysSelect
            // 
            this.buttonUiSysSelect.Location = new System.Drawing.Point(43, 190);
            this.buttonUiSysSelect.Name = "buttonUiSysSelect";
            this.buttonUiSysSelect.Size = new System.Drawing.Size(67, 23);
            this.buttonUiSysSelect.TabIndex = 3;
            this.buttonUiSysSelect.Text = "全选";
            this.buttonUiSysSelect.UseVisualStyleBackColor = true;
            // 
            // buttonUiSysDel
            // 
            this.buttonUiSysDel.Location = new System.Drawing.Point(284, 190);
            this.buttonUiSysDel.Name = "buttonUiSysDel";
            this.buttonUiSysDel.Size = new System.Drawing.Size(67, 23);
            this.buttonUiSysDel.TabIndex = 2;
            this.buttonUiSysDel.Text = "删除";
            this.buttonUiSysDel.UseVisualStyleBackColor = true;
            // 
            // buttonUiSysSaveToSql
            // 
            this.buttonUiSysSaveToSql.Location = new System.Drawing.Point(163, 190);
            this.buttonUiSysSaveToSql.Name = "buttonUiSysSaveToSql";
            this.buttonUiSysSaveToSql.Size = new System.Drawing.Size(67, 23);
            this.buttonUiSysSaveToSql.TabIndex = 1;
            this.buttonUiSysSaveToSql.Text = "保存";
            this.buttonUiSysSaveToSql.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(5, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(458, 167);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "选择";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "用户名";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "权鉴";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "密码";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "状态";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 80;
            // 
            // uiSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 344);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "uiSys";
            this.Text = "uiSys";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUiSysCurrentUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUiSysCurrenPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUiSysLoginType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUiSysNewPwd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUiSysModifyPwd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.Button buttonUiSysSaveToSql;
        private System.Windows.Forms.Button buttonUiSysDel;
        private System.Windows.Forms.Button buttonUiSysSelect;
    }
}