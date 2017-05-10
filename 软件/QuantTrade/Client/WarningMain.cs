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
    public partial class WarningMain : Form
    {
        public WarningMain()
        {
            InitializeComponent();
            BaseLoad();
        }


        private void BaseLoad()
        {
            DataTable data = OleDb.GetData("SELECT Code 股票代码,name 预警名称,ways 方式,state 状态 fROM STOCK_WARNING ").Tables[0];
            dataGridView1.DataSource = data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new WarningAdd().ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OleDb.ExecuteSQL($"UPDATE STOCK_WARNING  set state = 'open' where code ='{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'  and name ='{dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}' ");
            BaseLoad();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OleDb.ExecuteSQL($"UPDATE STOCK_WARNING set state = 'close' where code ='{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'  and name ='{dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}'  ");
            BaseLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDb.ExecuteSQL($"delete from  STOCK_WARNING where code ='{dataGridView1.SelectedRows[0].Cells[0].ToString()}'  and name ='{dataGridView1.SelectedRows[0].Cells[1].ToString()}'");
            BaseLoad();
        }
    }
}
