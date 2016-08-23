namespace webbrower
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAddrInput = new System.Windows.Forms.TextBox();
            this.textBoxPriseInput = new System.Windows.Forms.TextBox();
            this.buttonWebGo = new System.Windows.Forms.Button();
            this.webBrowserTest = new System.Windows.Forms.WebBrowser();
            this.buttonModifyP = new System.Windows.Forms.Button();
            this.textBoxWareId = new System.Windows.Forms.TextBox();
            this.buttonModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddrInput
            // 
            this.textBoxAddrInput.Location = new System.Drawing.Point(12, 8);
            this.textBoxAddrInput.Name = "textBoxAddrInput";
            this.textBoxAddrInput.Size = new System.Drawing.Size(728, 21);
            this.textBoxAddrInput.TabIndex = 0;
            // 
            // textBoxPriseInput
            // 
            this.textBoxPriseInput.Location = new System.Drawing.Point(948, 8);
            this.textBoxPriseInput.Name = "textBoxPriseInput";
            this.textBoxPriseInput.Size = new System.Drawing.Size(68, 21);
            this.textBoxPriseInput.TabIndex = 1;
            // 
            // buttonWebGo
            // 
            this.buttonWebGo.Location = new System.Drawing.Point(741, 8);
            this.buttonWebGo.Name = "buttonWebGo";
            this.buttonWebGo.Size = new System.Drawing.Size(75, 23);
            this.buttonWebGo.TabIndex = 2;
            this.buttonWebGo.Text = "转到";
            this.buttonWebGo.UseVisualStyleBackColor = true;
            this.buttonWebGo.Click += new System.EventHandler(this.buttonWebGo_Click);
            // 
            // webBrowserTest
            // 
            this.webBrowserTest.Location = new System.Drawing.Point(12, 39);
            this.webBrowserTest.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserTest.Name = "webBrowserTest";
            this.webBrowserTest.Size = new System.Drawing.Size(1154, 428);
            this.webBrowserTest.TabIndex = 3;
            // 
            // buttonModifyP
            // 
            this.buttonModifyP.Location = new System.Drawing.Point(1021, 6);
            this.buttonModifyP.Name = "buttonModifyP";
            this.buttonModifyP.Size = new System.Drawing.Size(60, 23);
            this.buttonModifyP.TabIndex = 4;
            this.buttonModifyP.Text = "组装";
            this.buttonModifyP.UseVisualStyleBackColor = true;
            this.buttonModifyP.Click += new System.EventHandler(this.buttonModifyP_Click);
            // 
            // textBoxWareId
            // 
            this.textBoxWareId.Location = new System.Drawing.Point(828, 9);
            this.textBoxWareId.Name = "textBoxWareId";
            this.textBoxWareId.Size = new System.Drawing.Size(114, 21);
            this.textBoxWareId.TabIndex = 5;
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(1087, 6);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(48, 23);
            this.buttonModify.TabIndex = 6;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 479);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.textBoxWareId);
            this.Controls.Add(this.buttonModifyP);
            this.Controls.Add(this.webBrowserTest);
            this.Controls.Add(this.buttonWebGo);
            this.Controls.Add(this.textBoxPriseInput);
            this.Controls.Add(this.textBoxAddrInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddrInput;
        private System.Windows.Forms.TextBox textBoxPriseInput;
        private System.Windows.Forms.Button buttonWebGo;
        private System.Windows.Forms.WebBrowser webBrowserTest;
        private System.Windows.Forms.Button buttonModifyP;
        private System.Windows.Forms.TextBox textBoxWareId;
        private System.Windows.Forms.Button buttonModify;
    }
}

