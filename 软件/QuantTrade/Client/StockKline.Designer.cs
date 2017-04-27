namespace Client
{
    partial class StockKline
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LabName = new System.Windows.Forms.Label();
            this.LabCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabOpen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LabHigh = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LabLow = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LabClose = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LabIncrease = new System.Windows.Forms.Label();
            this.LabIncrePer = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LabAmount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabAmount);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.LabIncrePer);
            this.groupBox1.Controls.Add(this.LabIncrease);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.LabClose);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.LabLow);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LabHigh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LabOpen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LabDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 553);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细";
            // 
            // ChartMain
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.ChartMain.ChartAreas.Add(chartArea1);
            this.ChartMain.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.ChartMain.Legends.Add(legend1);
            this.ChartMain.Location = new System.Drawing.Point(106, 12);
            this.ChartMain.Name = "ChartMain";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "K线";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea2";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "交易量";
            this.ChartMain.Series.Add(series1);
            this.ChartMain.Series.Add(series2);
            this.ChartMain.Size = new System.Drawing.Size(1196, 652);
            this.ChartMain.TabIndex = 1;
            this.ChartMain.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "K线";
            this.ChartMain.Titles.Add(title1);
            this.ChartMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartMain_MouseMove);
            // 
            // LabName
            // 
            this.LabName.AutoSize = true;
            this.LabName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabName.Location = new System.Drawing.Point(8, 12);
            this.LabName.Name = "LabName";
            this.LabName.Size = new System.Drawing.Size(85, 19);
            this.LabName.TabIndex = 2;
            this.LabName.Text = "浦东银行";
            // 
            // LabCode
            // 
            this.LabCode.AutoSize = true;
            this.LabCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabCode.Location = new System.Drawing.Point(8, 45);
            this.LabCode.Name = "LabCode";
            this.LabCode.Size = new System.Drawing.Size(69, 20);
            this.LabCode.TabIndex = 3;
            this.LabCode.Text = "600000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "时间";
            // 
            // LabDate
            // 
            this.LabDate.AutoSize = true;
            this.LabDate.Location = new System.Drawing.Point(6, 59);
            this.LabDate.Name = "LabDate";
            this.LabDate.Size = new System.Drawing.Size(29, 12);
            this.LabDate.TabIndex = 1;
            this.LabDate.Text = "时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "开盘";
            // 
            // LabOpen
            // 
            this.LabOpen.AutoSize = true;
            this.LabOpen.Location = new System.Drawing.Point(6, 120);
            this.LabOpen.Name = "LabOpen";
            this.LabOpen.Size = new System.Drawing.Size(29, 12);
            this.LabOpen.TabIndex = 3;
            this.LabOpen.Text = "开盘";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "最高";
            // 
            // LabHigh
            // 
            this.LabHigh.AutoSize = true;
            this.LabHigh.Location = new System.Drawing.Point(6, 166);
            this.LabHigh.Name = "LabHigh";
            this.LabHigh.Size = new System.Drawing.Size(29, 12);
            this.LabHigh.TabIndex = 5;
            this.LabHigh.Text = "最高";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "最低 ";
            // 
            // LabLow
            // 
            this.LabLow.AutoSize = true;
            this.LabLow.Location = new System.Drawing.Point(6, 248);
            this.LabLow.Name = "LabLow";
            this.LabLow.Size = new System.Drawing.Size(35, 12);
            this.LabLow.TabIndex = 7;
            this.LabLow.Text = "最低 ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "收盘";
            // 
            // LabClose
            // 
            this.LabClose.AutoSize = true;
            this.LabClose.Location = new System.Drawing.Point(26, 316);
            this.LabClose.Name = "LabClose";
            this.LabClose.Size = new System.Drawing.Size(29, 12);
            this.LabClose.TabIndex = 9;
            this.LabClose.Text = "收盘";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "涨跌";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 419);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "涨幅";
            // 
            // LabIncrease
            // 
            this.LabIncrease.AutoSize = true;
            this.LabIncrease.Location = new System.Drawing.Point(26, 383);
            this.LabIncrease.Name = "LabIncrease";
            this.LabIncrease.Size = new System.Drawing.Size(29, 12);
            this.LabIncrease.TabIndex = 12;
            this.LabIncrease.Text = "涨跌";
            // 
            // LabIncrePer
            // 
            this.LabIncrePer.AutoSize = true;
            this.LabIncrePer.Location = new System.Drawing.Point(26, 447);
            this.LabIncrePer.Name = "LabIncrePer";
            this.LabIncrePer.Size = new System.Drawing.Size(29, 12);
            this.LabIncrePer.TabIndex = 13;
            this.LabIncrePer.Text = "涨幅";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 479);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "总手";
            // 
            // LabAmount
            // 
            this.LabAmount.AutoSize = true;
            this.LabAmount.Location = new System.Drawing.Point(31, 505);
            this.LabAmount.Name = "LabAmount";
            this.LabAmount.Size = new System.Drawing.Size(29, 12);
            this.LabAmount.TabIndex = 15;
            this.LabAmount.Text = "总手";
            // 
            // StockKline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 768);
            this.Controls.Add(this.LabCode);
            this.Controls.Add(this.LabName);
            this.Controls.Add(this.ChartMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "StockKline";
            this.Text = "StockKline";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label LabIncrePer;
        private System.Windows.Forms.Label LabIncrease;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LabClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LabLow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LabHigh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LabOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMain;
        private System.Windows.Forms.Label LabCode;
        private System.Windows.Forms.Label LabName;
    }
}