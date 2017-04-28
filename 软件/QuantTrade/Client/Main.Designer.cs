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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选股ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预警ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageAll = new System.Windows.Forms.TabPage();
            this.TabPageFocus = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.选股ToolStripMenuItem,
            this.预警ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1205, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 选股ToolStripMenuItem
            // 
            this.选股ToolStripMenuItem.Name = "选股ToolStripMenuItem";
            this.选股ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选股ToolStripMenuItem.Text = "选股";
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
            this.tabControl1.Size = new System.Drawing.Size(1193, 699);
            this.tabControl1.TabIndex = 1;
            // 
            // TabPageAll
            // 
            this.TabPageAll.Location = new System.Drawing.Point(4, 4);
            this.TabPageAll.Name = "TabPageAll";
            this.TabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAll.Size = new System.Drawing.Size(1185, 673);
            this.TabPageAll.TabIndex = 0;
            this.TabPageAll.Text = "上证A股";
            this.TabPageAll.UseVisualStyleBackColor = true;
            // 
            // TabPageFocus
            // 
            this.TabPageFocus.Location = new System.Drawing.Point(4, 4);
            this.TabPageFocus.Name = "TabPageFocus";
            this.TabPageFocus.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFocus.Size = new System.Drawing.Size(1185, 673);
            this.TabPageFocus.TabIndex = 1;
            this.TabPageFocus.Text = "关注列表";
            this.TabPageFocus.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 739);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MainList";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选股ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预警ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageAll;
        private System.Windows.Forms.TabPage TabPageFocus;
    }
}