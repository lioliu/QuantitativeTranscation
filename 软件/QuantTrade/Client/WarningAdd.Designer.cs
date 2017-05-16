namespace Client
{
    partial class WarningAdd
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
            this.CLBSNAP = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CLBECNO = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSnap = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBoxDayline = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBoxKline = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewEcno = new System.Windows.Forms.DataGridView();
            this.dataGridViewLgst = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnUpdateSet = new System.Windows.Forms.Button();
            this.btnLoadSet = new System.Windows.Forms.Button();
            this.btnDeleteSet = new System.Windows.Forms.Button();
            this.btnAddSet = new System.Windows.Forms.Button();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxComm = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.CLBCACU = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnap)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDayline)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKline)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLgst)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CLBSNAP);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "交易指数";
            // 
            // CLBSNAP
            // 
            this.CLBSNAP.FormattingEnabled = true;
            this.CLBSNAP.Location = new System.Drawing.Point(10, 20);
            this.CLBSNAP.Name = "CLBSNAP";
            this.CLBSNAP.Size = new System.Drawing.Size(245, 68);
            this.CLBSNAP.TabIndex = 2;
            this.CLBSNAP.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBSNAP_ItemCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CLBECNO);
            this.groupBox2.Location = new System.Drawing.Point(12, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "财务指数";
            // 
            // CLBECNO
            // 
            this.CLBECNO.FormattingEnabled = true;
            this.CLBECNO.Location = new System.Drawing.Point(10, 21);
            this.CLBECNO.Name = "CLBECNO";
            this.CLBECNO.Size = new System.Drawing.Size(245, 68);
            this.CLBECNO.TabIndex = 0;
            this.CLBECNO.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBECNO_ItemCheck);
            this.CLBECNO.DoubleClick += new System.EventHandler(this.CLBECNO_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "目标股票";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(342, 370);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(168, 21);
            this.tbxCode.TabIndex = 3;
            this.tbxCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbxCode.Enter += new System.EventHandler(this.textBox1_Enter);
            this.tbxCode.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(342, 391);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 88);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(564, 373);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 28);
            this.BtnOK.TabIndex = 5;
            this.BtnOK.Text = "确认";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewSnap);
            this.groupBox3.Location = new System.Drawing.Point(279, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 200);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "该股当前快照";
            // 
            // dataGridViewSnap
            // 
            this.dataGridViewSnap.AllowUserToAddRows = false;
            this.dataGridViewSnap.AllowUserToDeleteRows = false;
            this.dataGridViewSnap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSnap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSnap.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewSnap.Name = "dataGridViewSnap";
            this.dataGridViewSnap.ReadOnly = true;
            this.dataGridViewSnap.RowTemplate.Height = 23;
            this.dataGridViewSnap.Size = new System.Drawing.Size(167, 167);
            this.dataGridViewSnap.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBoxDayline);
            this.groupBox4.Location = new System.Drawing.Point(651, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(561, 327);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "该股日数据";
            // 
            // pictureBoxDayline
            // 
            this.pictureBoxDayline.Location = new System.Drawing.Point(6, 18);
            this.pictureBoxDayline.Name = "pictureBoxDayline";
            this.pictureBoxDayline.Size = new System.Drawing.Size(545, 300);
            this.pictureBoxDayline.TabIndex = 0;
            this.pictureBoxDayline.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBoxKline);
            this.groupBox5.Location = new System.Drawing.Point(651, 346);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(561, 327);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "该股K线数据";
            // 
            // pictureBoxKline
            // 
            this.pictureBoxKline.Location = new System.Drawing.Point(6, 18);
            this.pictureBoxKline.Name = "pictureBoxKline";
            this.pictureBoxKline.Size = new System.Drawing.Size(545, 300);
            this.pictureBoxKline.TabIndex = 0;
            this.pictureBoxKline.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewEcno);
            this.groupBox6.Location = new System.Drawing.Point(465, 49);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(180, 200);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "当前财务数据";
            // 
            // dataGridViewEcno
            // 
            this.dataGridViewEcno.AllowUserToAddRows = false;
            this.dataGridViewEcno.AllowUserToDeleteRows = false;
            this.dataGridViewEcno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEcno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEcno.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewEcno.Name = "dataGridViewEcno";
            this.dataGridViewEcno.ReadOnly = true;
            this.dataGridViewEcno.RowTemplate.Height = 23;
            this.dataGridViewEcno.Size = new System.Drawing.Size(167, 167);
            this.dataGridViewEcno.TabIndex = 1;
            // 
            // dataGridViewLgst
            // 
            this.dataGridViewLgst.AllowUserToAddRows = false;
            this.dataGridViewLgst.AllowUserToDeleteRows = false;
            this.dataGridViewLgst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLgst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLgst.Location = new System.Drawing.Point(12, 364);
            this.dataGridViewLgst.Name = "dataGridViewLgst";
            this.dataGridViewLgst.RowTemplate.Height = 23;
            this.dataGridViewLgst.Size = new System.Drawing.Size(261, 300);
            this.dataGridViewLgst.TabIndex = 10;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.btnUpdateSet);
            this.groupBox7.Controls.Add(this.btnLoadSet);
            this.groupBox7.Controls.Add(this.btnDeleteSet);
            this.groupBox7.Controls.Add(this.btnAddSet);
            this.groupBox7.Controls.Add(this.listBox4);
            this.groupBox7.Location = new System.Drawing.Point(279, 256);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(366, 100);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "个人策略组";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 21);
            this.textBox1.TabIndex = 5;
            // 
            // btnUpdateSet
            // 
            this.btnUpdateSet.Location = new System.Drawing.Point(282, 55);
            this.btnUpdateSet.Name = "btnUpdateSet";
            this.btnUpdateSet.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSet.TabIndex = 4;
            this.btnUpdateSet.Text = "更新";
            this.btnUpdateSet.UseVisualStyleBackColor = true;
            this.btnUpdateSet.Click += new System.EventHandler(this.btnUpdateSet_Click);
            // 
            // btnLoadSet
            // 
            this.btnLoadSet.Location = new System.Drawing.Point(120, 55);
            this.btnLoadSet.Name = "btnLoadSet";
            this.btnLoadSet.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSet.TabIndex = 3;
            this.btnLoadSet.Text = "加载";
            this.btnLoadSet.UseVisualStyleBackColor = true;
            this.btnLoadSet.Click += new System.EventHandler(this.btnLoadSet_Click);
            // 
            // btnDeleteSet
            // 
            this.btnDeleteSet.Location = new System.Drawing.Point(201, 55);
            this.btnDeleteSet.Name = "btnDeleteSet";
            this.btnDeleteSet.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSet.TabIndex = 2;
            this.btnDeleteSet.Text = "删除";
            this.btnDeleteSet.UseVisualStyleBackColor = true;
            this.btnDeleteSet.Click += new System.EventHandler(this.btnDeleteSet_Click);
            // 
            // btnAddSet
            // 
            this.btnAddSet.Location = new System.Drawing.Point(282, 21);
            this.btnAddSet.Name = "btnAddSet";
            this.btnAddSet.Size = new System.Drawing.Size(75, 23);
            this.btnAddSet.TabIndex = 1;
            this.btnAddSet.Text = "添加";
            this.btnAddSet.UseVisualStyleBackColor = true;
            this.btnAddSet.Click += new System.EventHandler(this.btnAddSet_Click);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 12;
            this.listBox4.Location = new System.Drawing.Point(10, 23);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(104, 64);
            this.listBox4.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(469, 632);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "添加预警";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(342, 635);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "短信";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(399, 635);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "邮件";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "预警名称";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(342, 486);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(294, 21);
            this.tbxName.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "预警内容";
            // 
            // tbxComm
            // 
            this.tbxComm.Location = new System.Drawing.Point(342, 522);
            this.tbxComm.Name = "tbxComm";
            this.tbxComm.Size = new System.Drawing.Size(295, 96);
            this.tbxComm.TabIndex = 18;
            this.tbxComm.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 637);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "预警方式";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "股票预警设置";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "使用所选择逻辑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.CLBCACU);
            this.groupBox8.Location = new System.Drawing.Point(12, 256);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(261, 100);
            this.groupBox8.TabIndex = 22;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "计算指数";
            // 
            // CLBCACU
            // 
            this.CLBCACU.FormattingEnabled = true;
            this.CLBCACU.Location = new System.Drawing.Point(10, 20);
            this.CLBCACU.Name = "CLBCACU";
            this.CLBCACU.Size = new System.Drawing.Size(245, 68);
            this.CLBCACU.TabIndex = 2;
            //this.CLBCACU.SelectedIndexChanged += new System.EventHandler(this.CLBCACU_SelectedIndexChanged);
            // 
            // WarningAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 682);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxComm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.dataGridViewLgst);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "WarningAdd";
            this.Text = "爬虫股票预警系统";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSnap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDayline)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKline)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLgst)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBoxDayline;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBoxKline;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewLgst;
        private System.Windows.Forms.CheckedListBox CLBSNAP;
        private System.Windows.Forms.CheckedListBox CLBECNO;
        private System.Windows.Forms.DataGridView dataGridViewSnap;
        private System.Windows.Forms.DataGridView dataGridViewEcno;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDeleteSet;
        private System.Windows.Forms.Button btnAddSet;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox tbxComm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdateSet;
        private System.Windows.Forms.Button btnLoadSet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckedListBox CLBCACU;
    }
}