using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuantTradeDLL.DBUtility;
namespace Client
{
    public partial class PushAnn : Form
    {
        public PushAnn()
        {
            InitializeComponent();
            BaseLoad();
            listBox1.Visible = false;
            button1.Enabled = false;
        }
        void BaseLoad()
        {
            DataTable data = OleDb.GetData("SELECT Code 股票代码 , name 名称 from stock_list where code in (select code from push_list)").Tables[0];
            dataGridView1.DataSource = data;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            int index = dataGridView1.SelectedCells[0].RowIndex;
            OleDb.ExecuteSQL($"delete from push_list where code = '{dataGridView1.Rows[index].Cells[0].Value.ToString()}'");
            BaseLoad();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (OleDb.GetData($"Select count(*) from push_list where code = '{textBox1.Text.Substring(0, 6)}'").Tables[0].Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("已在推送列表中");
                return;
            }
            OleDb.ExecuteSQL($"insert into push_list values ('{textBox1.Text.Substring(0, 6)}')");
            BaseLoad();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            DataTable dt = OleDb.GetData($"select * from STOCKSUGGEST where code like '%{textBox1.Text}%' or name like '%{textBox1.Text}%' or py like '%{textBox1.Text}%'").Tables[0];
            listBox1.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                listBox1.Visible = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listBox1.Items.Add($"{dt.Rows[i][0].ToString()} {dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()}");
                }
            }
            if (textBox1.Text.Length == 0)
            {
                listBox1.Visible = false;
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            button1.Enabled = true;
            listBox1.Visible = false;
        }
    }
}
