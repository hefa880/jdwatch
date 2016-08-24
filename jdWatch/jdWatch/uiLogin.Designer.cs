namespace jdWatch
{
    partial class uiLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUiLoginUserName = new System.Windows.Forms.TextBox();
            this.textBoxUiLoginUserPwd = new System.Windows.Forms.TextBox();
            this.textBoxUiLoginSqlAddr = new System.Windows.Forms.TextBox();
            this.labelUiLoginUserName = new System.Windows.Forms.Label();
            this.labelUiLoginPwd = new System.Windows.Forms.Label();
            this.labelUiLoginSqlAddr = new System.Windows.Forms.Label();
            this.buttonUiLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUiLoginUserName
            // 
            this.textBoxUiLoginUserName.Location = new System.Drawing.Point(101, 57);
            this.textBoxUiLoginUserName.Name = "textBoxUiLoginUserName";
            this.textBoxUiLoginUserName.Size = new System.Drawing.Size(100, 21);
            this.textBoxUiLoginUserName.TabIndex = 0;
            // 
            // textBoxUiLoginUserPwd
            // 
            this.textBoxUiLoginUserPwd.Location = new System.Drawing.Point(101, 95);
            this.textBoxUiLoginUserPwd.Name = "textBoxUiLoginUserPwd";
            this.textBoxUiLoginUserPwd.Size = new System.Drawing.Size(100, 21);
            this.textBoxUiLoginUserPwd.TabIndex = 1;
            this.textBoxUiLoginUserPwd.UseSystemPasswordChar = true;
            // 
            // textBoxUiLoginSqlAddr
            // 
            this.textBoxUiLoginSqlAddr.Location = new System.Drawing.Point(101, 138);
            this.textBoxUiLoginSqlAddr.Name = "textBoxUiLoginSqlAddr";
            this.textBoxUiLoginSqlAddr.Size = new System.Drawing.Size(168, 21);
            this.textBoxUiLoginSqlAddr.TabIndex = 2;
            // 
            // labelUiLoginUserName
            // 
            this.labelUiLoginUserName.AutoSize = true;
            this.labelUiLoginUserName.Location = new System.Drawing.Point(48, 62);
            this.labelUiLoginUserName.Name = "labelUiLoginUserName";
            this.labelUiLoginUserName.Size = new System.Drawing.Size(47, 12);
            this.labelUiLoginUserName.TabIndex = 3;
            this.labelUiLoginUserName.Text = "用户名:";
            // 
            // labelUiLoginPwd
            // 
            this.labelUiLoginPwd.AutoSize = true;
            this.labelUiLoginPwd.Location = new System.Drawing.Point(48, 101);
            this.labelUiLoginPwd.Name = "labelUiLoginPwd";
            this.labelUiLoginPwd.Size = new System.Drawing.Size(47, 12);
            this.labelUiLoginPwd.TabIndex = 4;
            this.labelUiLoginPwd.Text = "密 码：";
            // 
            // labelUiLoginSqlAddr
            // 
            this.labelUiLoginSqlAddr.AutoSize = true;
            this.labelUiLoginSqlAddr.Location = new System.Drawing.Point(48, 144);
            this.labelUiLoginSqlAddr.Name = "labelUiLoginSqlAddr";
            this.labelUiLoginSqlAddr.Size = new System.Drawing.Size(53, 12);
            this.labelUiLoginSqlAddr.TabIndex = 5;
            this.labelUiLoginSqlAddr.Text = "服务器：";
            // 
            // buttonUiLogin
            // 
            this.buttonUiLogin.Location = new System.Drawing.Point(109, 188);
            this.buttonUiLogin.Name = "buttonUiLogin";
            this.buttonUiLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonUiLogin.TabIndex = 6;
            this.buttonUiLogin.Text = "登录";
            this.buttonUiLogin.UseVisualStyleBackColor = true;
            this.buttonUiLogin.Click += new System.EventHandler(this.buttonUiLogin_Click);
            // 
            // uiLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 257);
            this.Controls.Add(this.buttonUiLogin);
            this.Controls.Add(this.labelUiLoginSqlAddr);
            this.Controls.Add(this.labelUiLoginPwd);
            this.Controls.Add(this.labelUiLoginUserName);
            this.Controls.Add(this.textBoxUiLoginSqlAddr);
            this.Controls.Add(this.textBoxUiLoginUserPwd);
            this.Controls.Add(this.textBoxUiLoginUserName);
            this.MaximizeBox = false;
            this.Name = "uiLogin";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUiLoginUserName;
        private System.Windows.Forms.TextBox textBoxUiLoginUserPwd;
        private System.Windows.Forms.TextBox textBoxUiLoginSqlAddr;
        private System.Windows.Forms.Label labelUiLoginUserName;
        private System.Windows.Forms.Label labelUiLoginPwd;
        private System.Windows.Forms.Label labelUiLoginSqlAddr;
        private System.Windows.Forms.Button buttonUiLogin;
    }
}

