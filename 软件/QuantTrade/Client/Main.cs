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
    public partial class Main : Form
    {
        private string[] AllList { set; get; }
        private string[] FocusList { set; get; }
        private int PageNnumAll { set; get; }
        private int PageNnumFocus { set; get; }
        private DataTable AllTable = new DataTable() { };
        private DataTable FocusTable = new DataTable() { };
        public Main()
        {
            PageNnumAll = 0;
            PageNnumFocus = 0;
            AllList = StockList.GetCode();
            FocusList = StockList.GetFocusCode();
            AllTable.Columns.Add("Code");
            AllTable.Columns.Add("Name");
            AllTable.Columns.Add("IncrePer");
            AllTable.Columns.Add("NowPri");
            AllTable.Columns.Add("Increase");
            AllTable.Columns.Add("TraNumber");
            AllTable.Columns.Add("TodayStartPri");
            AllTable.Columns.Add("YestodEndPri");
            AllTable.Columns.Add("TodayMax");
            AllTable.Columns.Add("TodayMin");
            FocusTable.Columns.Add("Code");
            FocusTable.Columns.Add("Name");
            FocusTable.Columns.Add("IncrePer");
            FocusTable.Columns.Add("NowPri");
            FocusTable.Columns.Add("Increase");
            FocusTable.Columns.Add("TraNumber");
            FocusTable.Columns.Add("TodayStartPri");
            FocusTable.Columns.Add("YestodEndPri");
            FocusTable.Columns.Add("TodayMax");
            FocusTable.Columns.Add("TodayMin");
            for (int i = 0; i < 25; i++)
            {
                AllTable.Rows.Add();
                FocusTable.Rows.Add();
            }
            //SnapData data = new SnapData();
            //data = 
            InitializeComponent();
            LoadList();
            SetButon();
            DataViewAll.DataSource = AllTable;
            DataViewFocus.DataSource = FocusTable;
            //DataViewAll.Columns.Add(new DataGridViewButtonColumn() { Text = "Detail", Name = "Detail" });
            //DataViewAll.Rows[0].
            //dt.Rows[0][0] = "123123123";
            LstBoxSuggestList.Visible = false;
            BtnLookUp.Enabled = false;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
            SetButon();
        }
        private void SetButon()
        {
            LabNowPage.Text = "第" + (tabControl1.SelectedIndex == 0 ? PageNnumAll + 1 : PageNnumFocus + 1).ToString() + "页";
            if (tabControl1.SelectedIndex == 0)
            {
                //Set btnlastpage
                if (PageNnumAll == 0) BtnLastPage.Enabled = false;
                else BtnLastPage.Enabled = true;
                //Set NextPage btn
                if (PageNnumAll == AllList.Length / 25 + (AllList.Length % 25 == 0 ? 0 : 1)) BtnNextPage.Enabled = false;
                else BtnNextPage.Enabled = true;
            }
            else
            {
                //Set btnlastpage
                if (PageNnumFocus == 0) BtnLastPage.Enabled = false;
                else BtnLastPage.Enabled = true;
                //Set NextPage btn
                if (PageNnumFocus == FocusList.Length / 25 + (FocusList.Length % 25 == 0 ? 0 : 1)) BtnNextPage.Enabled = false;
                else BtnNextPage.Enabled = true;
            }
        }
        /// <summary>
        /// update data in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            DataTable dt = new DataTable();
            string stockList = string.Empty;
            if (tabControl1.SelectedIndex == 0)
            {
                //manage the  code list 
                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        stockList += $",'{AllList[PageNnumAll * 25 + i]}'";
                    }
                    catch (Exception)
                    {
                        break;
                    };
                }
                stockList = stockList.Substring(1);
                stockList = "(" + stockList + ")";
                Console.WriteLine(stockList);
                dt = OleDb.GetData($"Select * from STOCK_SNAP_DATA WHERE CODE IN {stockList}").Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AllTable.Rows[i]["Code"] = AllList[PageNnumAll * 25 + i];
                    AllTable.Rows[i]["Name"] = dt.Rows[i]["Name"];
                    AllTable.Rows[i]["IncrePer"] = dt.Rows[i]["IncrePer"];
                    AllTable.Rows[i]["NowPri"] = dt.Rows[i]["NowPri"];
                    AllTable.Rows[i]["Increase"] = dt.Rows[i]["Increase"];
                    AllTable.Rows[i]["TraNumber"] = dt.Rows[i]["TraNumber"];
                    AllTable.Rows[i]["TodayStartPri"] = dt.Rows[i]["TodayStartPri"];
                    AllTable.Rows[i]["YestodEndPri"] = dt.Rows[i]["YestodEndPri"];
                    AllTable.Rows[i]["TodayMax"] = dt.Rows[i]["TodayMax"];
                    AllTable.Rows[i]["TodayMin"] = dt.Rows[i]["TodayMin"];
                }
            }
            else
            {
                FocusList = StockList.GetFocusCode();
                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        stockList += $",'{FocusList[PageNnumFocus * 25 + i]}'";
                    }
                    catch (Exception)
                    {
                        break;
                    };
                }
                if (stockList.Length > 1)
                    stockList = stockList.Substring(1);
                stockList = "(" + stockList + ")";
                Console.WriteLine(stockList);
                try
                {
                    dt = OleDb.GetData($"Select * from STOCK_SNAP_DATA WHERE CODE IN {stockList}").Tables[0];
                }
                catch (Exception)
                {
                    ;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FocusTable.Rows[i]["Code"] = AllList[PageNnumAll * 25 + i];
                    FocusTable.Rows[i]["Name"] = dt.Rows[i]["Name"];
                    FocusTable.Rows[i]["IncrePer"] = dt.Rows[i]["IncrePer"];
                    FocusTable.Rows[i]["NowPri"] = dt.Rows[i]["NowPri"];
                    FocusTable.Rows[i]["Increase"] = dt.Rows[i]["Increase"];
                    FocusTable.Rows[i]["TraNumber"] = dt.Rows[i]["TraNumber"];
                    FocusTable.Rows[i]["TodayStartPri"] = dt.Rows[i]["TodayStartPri"];
                    FocusTable.Rows[i]["YestodEndPri"] = dt.Rows[i]["YestodEndPri"];
                    FocusTable.Rows[i]["TodayMax"] = dt.Rows[i]["TodayMax"];
                    FocusTable.Rows[i]["TodayMin"] = dt.Rows[i]["TodayMin"];
                }
            }
        }
        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                PageNnumAll--;
            }
            else
            {
                PageNnumFocus--;
            }
            LoadList();
            SetButon();
        }
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                PageNnumAll++;
            }
            else
            {
                PageNnumFocus++;
            }
            LoadList();
            SetButon();
        }
        private void BtnJump_Click(object sender, EventArgs e)
        {
            int targetPage;
            try
            {
                targetPage = Convert.ToInt32(TbxPageNum.Text) - 1;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字");
                return;
            }
            if (tabControl1.SelectedIndex < 0)
            {
                MessageBox.Show("请输入正整数");
                return;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                if (targetPage >= AllList.Length / 25 + (AllList.Length % 25 == 0 ? 0 : 1))
                {
                    targetPage = AllList.Length / 25 + (AllList.Length % 25 == 0 ? 0 : 1) - 1;
                }
                PageNnumAll = targetPage;
            }
            else
            {
                if (targetPage >= FocusList.Length / 25 + (FocusList.Length % 25 == 0 ? 0 : 1))
                {
                    targetPage = FocusList.Length / 25 + (FocusList.Length % 25 == 0 ? 0 : 1) - 1;
                }
                PageNnumFocus = targetPage;
            }
            LoadList();
            SetButon();
        }
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Setting().ShowDialog();
        }
        private void DataViewAll_DoubleClick(object sender, EventArgs e)
        {
            //Console.WriteLine(DataViewAll.SelectedCells[0].RowIndex); for debug
            int index = DataViewAll.SelectedCells[0].RowIndex;
            new StockDetail(AllTable.Rows[index]["Code"].ToString(), AllList).ShowDialog();
        }
        private void DataViewFocus_DoubleClick(object sender, EventArgs e)
        {
            int index = DataViewFocus.SelectedCells[0].RowIndex;
            new StockDetail(FocusTable.Rows[index]["Code"].ToString(), FocusList).ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BtnLookUp.Enabled = false;
            DataTable dt = OleDb.GetData($"select * from STOCKSUGGEST where code like '%{textBox1.Text}%' or name like '%{textBox1.Text}%' or py like '%{textBox1.Text}%'").Tables[0];
            LstBoxSuggestList.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                LstBoxSuggestList.Visible = true;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LstBoxSuggestList.Items.Add($"{dt.Rows[i][0].ToString()} {dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()}");
                }
            }
            if (textBox1.Text.Length == 0)
            {
                LstBoxSuggestList.Visible = false;
            }

        }

        private void LstBoxSuggestList_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = LstBoxSuggestList.SelectedItem.ToString();
            BtnLookUp.Enabled = true;
        }

        private void BtnLookUp_Click(object sender, EventArgs e)
        {
            new StockDetail(textBox1.Text.Substring(0, 6), AllList).ShowDialog();
        }

        private void 设置预警ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看预警ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 推送公告ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
