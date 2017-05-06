namespace Client
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageAll = new System.Windows.Forms.TabPage();
            this.DataViewAll = new System.Windows.Forms.DataGridView();
            this.TabPageFocus = new System.Windows.Forms.TabPage();
            this.DataViewFocus = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnLastPage = new System.Windows.Forms.Button();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnJump = new System.Windows.Forms.Button();
            this.TbxPageNum = new System.Windows.Forms.TextBox();
            this.LabNowPage = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewAll)).BeginInit();
            this.TabPageFocus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewFocus)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.预警ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1166, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 预警ToolStripMenuItem
            // 
            this.预警ToolStripMenuItem.Name = "预警ToolStripMenuItem";
            this.预警ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.预警ToolStripMenuItem.Text = "预警";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.TabPageAll);
            this.tabControl1.Controls.Add(this.TabPageFocus);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 660);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPageAll
            // 
            this.TabPageAll.Controls.Add(this.DataViewAll);
            this.TabPageAll.Location = new System.Drawing.Point(4, 4);
            this.TabPageAll.Name = "TabPageAll";
            this.TabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAll.Size = new System.Drawing.Size(1152, 634);
            this.TabPageAll.TabIndex = 0;
            this.TabPageAll.Text = "上证A股";
            this.TabPageAll.UseVisualStyleBackColor = true;
            // 
            // DataViewAll
            // 
            this.DataViewAll.AllowUserToAddRows = false;
            this.DataViewAll.AllowUserToDeleteRows = false;
            this.DataViewAll.AllowUserToResizeColumns = false;
            this.DataViewAll.AllowUserToResizeRows = false;
            this.DataViewAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataViewAll.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DataViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewAll.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataViewAll.Location = new System.Drawing.Point(3, 6);
            this.DataViewAll.MultiSelect = false;
            this.DataViewAll.Name = "DataViewAll";
            this.DataViewAll.ReadOnly = true;
            this.DataViewAll.RowTemplate.Height = 23;
            this.DataViewAll.Size = new System.Drawing.Size(1137, 622);
            this.DataViewAll.TabIndex = 0;
            this.DataViewAll.DoubleClick += new System.EventHandler(this.DataViewAll_DoubleClick);
            // 
            // TabPageFocus
            // 
            this.TabPageFocus.Controls.Add(this.DataViewFocus);
            this.TabPageFocus.Location = new System.Drawing.Point(4, 4);
            this.TabPageFocus.Name = "TabPageFocus";
            this.TabPageFocus.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFocus.Size = new System.Drawing.Size(1152, 634);
            this.TabPageFocus.TabIndex = 1;
            this.TabPageFocus.Text = "关注列表";
            this.TabPageFocus.UseVisualStyleBackColor = true;
            // 
            // DataViewFocus
            // 
            this.DataViewFocus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataViewFocus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataViewFocus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewFocus.Location = new System.Drawing.Point(6, 6);
            this.DataViewFocus.Name = "DataViewFocus";
            this.DataViewFocus.RowTemplate.Height = 23;
            this.DataViewFocus.Size = new System.Drawing.Size(1139, 622);
            this.DataViewFocus.TabIndex = 0;
            this.DataViewFocus.DoubleClick += new System.EventHandler(this.DataViewFocus_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // BtnLastPage
            // 
            this.BtnLastPage.Location = new System.Drawing.Point(709, 694);
            this.BtnLastPage.Name = "BtnLastPage";
            this.BtnLastPage.Size = new System.Drawing.Size(75, 23);
            this.BtnLastPage.TabIndex = 1;
            this.BtnLastPage.Text = "上一页";
            this.BtnLastPage.UseVisualStyleBackColor = true;
            this.BtnLastPage.Click += new System.EventHandler(this.BtnLastPage_Click);
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.Location = new System.Drawing.Point(844, 694);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(75, 23);
            this.BtnNextPage.TabIndex = 2;
            this.BtnNextPage.Text = "下一页";
            this.BtnNextPage.UseVisualStyleBackColor = true;
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(942, 699);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "跳到";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1033, 697);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "页";
            // 
            // BtnJump
            // 
            this.BtnJump.Location = new System.Drawing.Point(1074, 694);
            this.BtnJump.Name = "BtnJump";
            this.BtnJump.Size = new System.Drawing.Size(75, 23);
            this.BtnJump.TabIndex = 6;
            this.BtnJump.Text = "确定";
            this.BtnJump.UseVisualStyleBackColor = true;
            this.BtnJump.Click += new System.EventHandler(this.BtnJump_Click);
            // 
            // TbxPageNum
            // 
            this.TbxPageNum.Location = new System.Drawing.Point(977, 694);
            this.TbxPageNum.Name = "TbxPageNum";
            this.TbxPageNum.Size = new System.Drawing.Size(50, 21);
            this.TbxPageNum.TabIndex = 7;
            // 
            // LabNowPage
            // 
            this.LabNowPage.AutoSize = true;
            this.LabNowPage.Location = new System.Drawing.Point(790, 697);
            this.LabNowPage.Name = "LabNowPage";
            this.LabNowPage.Size = new System.Drawing.Size(35, 12);
            this.LabNowPage.TabIndex = 8;
            this.LabNowPage.Text = "第X页";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 694);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 697);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "直接查看:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 694);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 739);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LabNowPage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TbxPageNum);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnJump);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnLastPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNextPage);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MainList";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewAll)).EndInit();
            this.TabPageFocus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewFocus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预警ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageAll;
        private System.Windows.Forms.TabPage TabPageFocus;
        private System.Windows.Forms.DataGridView DataViewAll;
        private System.Windows.Forms.DataGridView DataViewFocus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnJump;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNextPage;
        private System.Windows.Forms.Button BtnLastPage;
        private System.Windows.Forms.Label LabNowPage;
        private System.Windows.Forms.TextBox TbxPageNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}