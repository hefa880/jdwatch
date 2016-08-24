namespace jdWatch
{
    partial class uiHistory
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartUiHistory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxUiHistoryPColor = new System.Windows.Forms.ComboBox();
            this.comboBoxUiHistoryPSerial = new System.Windows.Forms.ComboBox();
            this.comboBoxUiHistoryPName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxUiHistoryPVersion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxUiHistoryPSeller = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxUiHistoryPSkuid = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUiHistoryOutPut = new System.Windows.Forms.Button();
            this.openFileDialogUiHistoryoutPut = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartUiHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartUiHistory
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUiHistory.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartUiHistory.Legends.Add(legend1);
            this.chartUiHistory.Location = new System.Drawing.Point(7, 20);
            this.chartUiHistory.Name = "chartUiHistory";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartUiHistory.Series.Add(series1);
            this.chartUiHistory.Size = new System.Drawing.Size(786, 248);
            this.chartUiHistory.TabIndex = 0;
            this.chartUiHistory.Text = "历史";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPSkuid);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPSeller);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPVersion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPColor);
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPSerial);
            this.groupBox2.Controls.Add(this.comboBoxUiHistoryPName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 55);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索条件";
            // 
            // comboBoxUiHistoryPColor
            // 
            this.comboBoxUiHistoryPColor.FormattingEnabled = true;
            this.comboBoxUiHistoryPColor.Location = new System.Drawing.Point(271, 21);
            this.comboBoxUiHistoryPColor.Name = "comboBoxUiHistoryPColor";
            this.comboBoxUiHistoryPColor.Size = new System.Drawing.Size(87, 20);
            this.comboBoxUiHistoryPColor.TabIndex = 5;
            // 
            // comboBoxUiHistoryPSerial
            // 
            this.comboBoxUiHistoryPSerial.FormattingEnabled = true;
            this.comboBoxUiHistoryPSerial.Location = new System.Drawing.Point(155, 21);
            this.comboBoxUiHistoryPSerial.Name = "comboBoxUiHistoryPSerial";
            this.comboBoxUiHistoryPSerial.Size = new System.Drawing.Size(83, 20);
            this.comboBoxUiHistoryPSerial.TabIndex = 4;
            // 
            // comboBoxUiHistoryPName
            // 
            this.comboBoxUiHistoryPName.FormattingEnabled = true;
            this.comboBoxUiHistoryPName.Location = new System.Drawing.Point(36, 21);
            this.comboBoxUiHistoryPName.Name = "comboBoxUiHistoryPName";
            this.comboBoxUiHistoryPName.Size = new System.Drawing.Size(82, 20);
            this.comboBoxUiHistoryPName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "颜色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "系列";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "品牌";
            // 
            // comboBoxUiHistoryPVersion
            // 
            this.comboBoxUiHistoryPVersion.FormattingEnabled = true;
            this.comboBoxUiHistoryPVersion.Location = new System.Drawing.Point(395, 21);
            this.comboBoxUiHistoryPVersion.Name = "comboBoxUiHistoryPVersion";
            this.comboBoxUiHistoryPVersion.Size = new System.Drawing.Size(118, 20);
            this.comboBoxUiHistoryPVersion.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "版本";
            // 
            // comboBoxUiHistoryPSeller
            // 
            this.comboBoxUiHistoryPSeller.FormattingEnabled = true;
            this.comboBoxUiHistoryPSeller.Location = new System.Drawing.Point(551, 21);
            this.comboBoxUiHistoryPSeller.Name = "comboBoxUiHistoryPSeller";
            this.comboBoxUiHistoryPSeller.Size = new System.Drawing.Size(97, 20);
            this.comboBoxUiHistoryPSeller.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "商家";
            // 
            // comboBoxUiHistoryPSkuid
            // 
            this.comboBoxUiHistoryPSkuid.FormattingEnabled = true;
            this.comboBoxUiHistoryPSkuid.Location = new System.Drawing.Point(703, 21);
            this.comboBoxUiHistoryPSkuid.Name = "comboBoxUiHistoryPSkuid";
            this.comboBoxUiHistoryPSkuid.Size = new System.Drawing.Size(96, 20);
            this.comboBoxUiHistoryPSkuid.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "商品编号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonUiHistoryOutPut);
            this.groupBox1.Controls.Add(this.chartUiHistory);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 308);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "趋势图";
            // 
            // buttonUiHistoryOutPut
            // 
            this.buttonUiHistoryOutPut.Location = new System.Drawing.Point(336, 277);
            this.buttonUiHistoryOutPut.Name = "buttonUiHistoryOutPut";
            this.buttonUiHistoryOutPut.Size = new System.Drawing.Size(75, 23);
            this.buttonUiHistoryOutPut.TabIndex = 1;
            this.buttonUiHistoryOutPut.Text = "导出报表";
            this.buttonUiHistoryOutPut.UseVisualStyleBackColor = true;
            // 
            // openFileDialogUiHistoryoutPut
            // 
            this.openFileDialogUiHistoryoutPut.FileName = "Skudi";
            // 
            // history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 384);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "history";
            this.Text = "历史";
            ((System.ComponentModel.ISupportInitialize)(this.chartUiHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartUiHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPColor;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPSerial;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPSeller;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxUiHistoryPSkuid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUiHistoryOutPut;
        private System.Windows.Forms.OpenFileDialog openFileDialogUiHistoryoutPut;
    }
}