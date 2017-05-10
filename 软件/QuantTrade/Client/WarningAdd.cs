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
using QuantTradeDLL.Crawler;


namespace Client
{

    public partial class WarningAdd : Form
    {
        private DataTable logistcal { set; get; }
        public WarningAdd()
        {
            InitializeComponent();
            BaseLoad();
        }


        private void BaseLoad()
        {
            logistcal = new DataTable();
            listBox1.Visible = false;
            BtnOK.Enabled = false;
            DataTable dt = OleDb.GetData("Select * from Warning_QULAFICATION where id <=32").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["QUALIFICATION_CODE"].ToString().Contains("snap"))
                {
                    CLBSNAP.Items.Add(dt.Rows[i]["SHOW_NAME"].ToString());
                }
                else
                {
                    CLBECNO.Items.Add(dt.Rows[i]["SHOW_NAME"].ToString());
                }
            }
            //snapTable.Columns.Add("指标");
            //snapTable.Columns.Add("数值");
            logistcal.Columns.Add("条件");
            logistcal.Columns.Add("目标值");
            dataGridViewLgst.DataSource = logistcal;
            radioButton1.Checked = true;


            DataTable dt2 = OleDb.GetData("select distinct Set_Name From custom_qualification_set").Tables[0];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                listBox4.Items.Add(dt2.Rows[i][0].ToString());
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BtnOK.Enabled = false;
            DataTable dt = OleDb.GetData($"select * from STOCKSUGGEST where code like '%{tbxCode.Text}%' or name like '%{tbxCode.Text}%' or py like '%{tbxCode.Text}%'").Tables[0];
            listBox1.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                listBox1.Visible = true;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listBox1.Items.Add($"{dt.Rows[i][0].ToString()} {dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()}");
                }
            }
            if (tbxCode.Text.Length == 0)
            {
                listBox1.Visible = false;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //  listBox1.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tbxCode.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
                BtnOK.Enabled = true;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // to load pic 
            SnapData snapData = SnapData.GetSnap(tbxCode.Text.Substring(0, 6));
            ECNOData ecnoData = ECNOData.LoadData(tbxCode.Text.Substring(0, 6));

            System.Net.WebRequest webreq = System.Net.WebRequest.Create(snapData.Result[0].Gopicture.Minurl);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                pictureBoxDayline.Image = Image.FromStream(stream);
            }
            webreq = System.Net.WebRequest.Create(snapData.Result[0].Gopicture.Dayurl);
            webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                pictureBoxKline.Image = Image.FromStream(stream);
            }


            //load ecno and snap datagridview
            DataTable snapTable = new DataTable();
            DataTable ecnoTable = new DataTable();

            snapTable.Columns.Add("指标");
            snapTable.Columns.Add("数值");
            #region add rows of snap
            for (int i = 0; i < 6; i++)
            {
                snapTable.Rows.Add();
            }
            snapTable.Rows[0][0] = "当前价格";
            snapTable.Rows[0][1] = snapData.Result[0].Data.NowPri;

            snapTable.Rows[1][0] = "今日最高";
            snapTable.Rows[1][1] = snapData.Result[0].Data.TodayMax;

            snapTable.Rows[2][0] = "今日最低";
            snapTable.Rows[2][1] = snapData.Result[0].Data.TodayMin;

            snapTable.Rows[3][0] = "开盘价";
            snapTable.Rows[3][1] = snapData.Result[0].Data.TodayStartPri;

            snapTable.Rows[4][0] = "涨幅";
            snapTable.Rows[4][1] = snapData.Result[0].Data.IncrePer;

            snapTable.Rows[5][0] = "涨跌";
            snapTable.Rows[5][1] = snapData.Result[0].Data.Increase;

            dataGridViewSnap.DataSource = snapTable;
            #endregion

            ecnoTable.Columns.Add("指标");
            ecnoTable.Columns.Add("数值");

            for (int i = 0; i < 6; i++)
            {
                ecnoTable.Rows.Add();
            }
            ecnoTable.Rows[0][0] = "收益";
            ecnoTable.Rows[0][1] = ecnoData.Income;

            ecnoTable.Rows[1][0] = "市盈率";
            ecnoTable.Rows[1][1] = ecnoData.PE;
            ecnoTable.Rows[2][0] = "净资产";
            ecnoTable.Rows[2][1] = ecnoData.BVPS;
            ecnoTable.Rows[3][0] = "市净率";
            ecnoTable.Rows[3][1] = ecnoData.PB;
            ecnoTable.Rows[4][0] = "净利率";
            ecnoTable.Rows[4][1] = ecnoData.NetMargin;
            ecnoTable.Rows[5][0] = "负债率";
            ecnoTable.Rows[5][1] = ecnoData.DebtRatio;

            dataGridViewEcno.DataSource = ecnoTable;


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CLBECNO_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //{
            //    //add 
            //    for (int CheckedIndex = 0; CheckedIndex < CLBECNO.CheckedItems.Count; CheckedIndex++)
            //    {
            //        if (!checkin(logistcal, CLBECNO.CheckedItems[CheckedIndex].ToString()) )
            //        {

            //            logistcal.Rows.Add();
            //            logistcal.Rows[logistcal.Rows.Count - 1][0] = CLBECNO.CheckedItems[CheckedIndex].ToString();
            //            logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
            //        }
            //    }
            //    //remove
            //    for (int i = 0; i < logistcal.Rows.Count; i++)
            //    {

            //    }
        }

        private void CLBSNAP_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }




        private bool checkin(DataTable dt, string name)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        private void CLBECNO_DoubleClick(object sender, EventArgs e)
        {
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logistcal = new DataTable();
            logistcal.Columns.Add("条件");
            logistcal.Columns.Add("目标值");
            //add  ecno
            foreach (var item in CLBECNO.CheckedItems)
            {
                if (!checkin(logistcal, item.ToString()))
                {

                    logistcal.Rows.Add();
                    logistcal.Rows[logistcal.Rows.Count - 1][0] = item.ToString();
                    logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
                }
            }

            foreach (var item in CLBSNAP.CheckedItems)
            {
                if (!checkin(logistcal, item.ToString()))
                {

                    logistcal.Rows.Add();
                    logistcal.Rows[logistcal.Rows.Count - 1][0] = item.ToString();
                    logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
                }
            }

            //for (int CheckedIndex = 0; CheckedIndex < CLBECNO.CheckedItems.Count; CheckedIndex++)
            //{
            //    if (!checkin(logistcal, CLBECNO.CheckedItems[CheckedIndex].ToString()))
            //    {

            //        logistcal.Rows.Add();
            //        logistcal.Rows[logistcal.Rows.Count - 1][0] = CLBECNO.CheckedItems[CheckedIndex].ToString();
            //        logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
            //    }
            //}
            //remove

            //add  snap
            //for (int CheckedIndex = 0; CheckedIndex < CLBSNAP.CheckedItems.Count; CheckedIndex++)
            //{
            //    if (!checkin(logistcal, CLBSNAP.CheckedItems[CheckedIndex].ToString()))
            //    {

            //        logistcal.Rows.Add();
            //        logistcal.Rows[logistcal.Rows.Count - 1][0] = CLBSNAP.CheckedItems[CheckedIndex].ToString();
            //        logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
            //    }
            //}
            dataGridViewLgst.DataSource = logistcal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region 判读是否所有 必填项都已填
            if (tbxCode.Text.Equals(string.Empty))
            {
                MessageBox.Show("未输入股票代码");
                return;
            }
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("未输入预警名称");
                return;

            }
            if (tbxComm.Text.Equals(string.Empty))
            {
                MessageBox.Show("请输入预警内容");
                return;

            }
            if (logistcal.Rows.Count == 0)
            {
                MessageBox.Show("请选择逻辑");
                return;

            }
            #endregion



            #region 组织 SQL语句 存储 预警;
            string ways = radioButton1.Checked ?"message":"email";
            string id = OleDb.GetData("select Max(ID)+1 from stock_warning").Tables[0].Rows[0][0].ToString();
            string explain = tbxComm.Text;
            string name = tbxName.Text;
            string code = tbxCode.Text.Substring(0, 6);
            string state = "open";

            string logistics = $"select count(*) from (select * from (select * from STOCK_ECNO_DATA where code = ''{code}'' order by days desc ) where rownum=1) ecno,(select * from (select * from STOCK_snap_DATA where code = ''{code}'' order by datetime desc ) where rownum=1) snap where 1=1";

            //设置逻辑
            for (int i = 0; i < logistcal.Rows.Count; i++)
            {
                DataTable dt = OleDb.GetData($"select * from warning_qulafication where show_name = '{logistcal.Rows[i][0].ToString()}'").Tables[0];
                string temp = $" and {dt.Rows[0][2].ToString()} {dt.Rows[0][4].ToString()} {logistcal.Rows[i][1].ToString()}";
                logistics += temp;

            }
            //插入数据库
            OleDb.ExecuteSQL($"INSERT INTO STOCK_WARNING VALUES ('{code}','{name}','{state}','{explain}','{ways}','{logistics}','{id}') ");

            MessageBox.Show("添加成功");

            #endregion
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDeleteSet_Click(object sender, EventArgs e)
        {
            OleDb.ExecuteSQL($"delete from custom_qualification_set where set_name = '{listBox4.SelectedItem.ToString()}'");
            listBox4.Items.Clear();
            DataTable dt2 = OleDb.GetData("select distinct Set_Name From custom_qualification_set").Tables[0];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                listBox4.Items.Add(dt2.Rows[i][0].ToString());
            }
        }

        private void btnLoadSet_Click(object sender, EventArgs e)
        {
            DataTable dt = OleDb.GetData($"select  Show_name From WARNING_QULAFICATION where id in (select ID from custom_qualification_set where Set_name = '{listBox4.SelectedItem.ToString()}')").Tables[0];

            for (int i = 0; i < CLBECNO.Items.Count; i++)
            {
                CLBECNO.SetItemChecked(i, false);
            }
            for (int i = 0; i < CLBSNAP.Items.Count; i++)
            {
                CLBSNAP.SetItemChecked(i, false);
            }

            logistcal = new DataTable();
            logistcal.Columns.Add("条件");
            logistcal.Columns.Add("目标值");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //修改checkedlist box 状态
                for (int j = 0; j < CLBECNO.Items.Count; j++)
                {
                    if(CLBECNO.Items[j].ToString() == dt.Rows[i][0].ToString())
                    {
                        CLBECNO.SetItemChecked(j, true);
                        break;
                    }
                }

                for (int j = 0; j < CLBSNAP.Items.Count; j++)
                {
                    if (CLBSNAP.Items[j].ToString() == dt.Rows[i][0].ToString())
                    {
                        CLBSNAP.SetItemChecked(j, true);
                        break;
                    }
                }


                //添加到 datagridview
                logistcal.Rows.Add();
                logistcal.Rows[logistcal.Rows.Count - 1][0] = dt.Rows[i][0].ToString();
                logistcal.Rows[logistcal.Rows.Count - 1][1] = 0;
            }

         
            dataGridViewLgst.DataSource = logistcal;
        }
    }
}
