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
            SnapData data;
            if (tabControl1.SelectedIndex == 0)
            {

                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        data = SnapData.GetSnap(AllList[PageNnumAll * 25 + i]);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    AllTable.Rows[i]["Code"] = AllList[PageNnumAll * 25 + i];
                    AllTable.Rows[i]["Name"] = data.Result[0].Data.Name;
                    AllTable.Rows[i]["IncrePer"] = data.Result[0].Data.IncrePer;
                    AllTable.Rows[i]["NowPri"] = data.Result[0].Data.NowPri;
                    AllTable.Rows[i]["Increase"] = data.Result[0].Data.Increase;
                    AllTable.Rows[i]["TraNumber"] = data.Result[0].Data.TraNumber;
                    AllTable.Rows[i]["TodayStartPri"] = data.Result[0].Data.TodayStartPri;
                    AllTable.Rows[i]["YestodEndPri"] = data.Result[0].Data.YestodEndPri;
                    AllTable.Rows[i]["TodayMax"] = data.Result[0].Data.TodayMax;
                    AllTable.Rows[i]["TodayMin"] = data.Result[0].Data.TodayMin;
                }
            }
            else
            {
                FocusList = StockList.GetFocusCode();
                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        data = SnapData.GetSnap(FocusList[PageNnumFocus * 25 + i]);

                    }
                    catch (Exception)
                    {
                        return;
                    }
                    FocusTable.Rows[i]["Code"] = FocusList[PageNnumFocus * 25 + i];
                    FocusTable.Rows[i]["Name"] = data.Result[0].Data.Name;
                    FocusTable.Rows[i]["IncrePer"] = data.Result[0].Data.IncrePer;
                    FocusTable.Rows[i]["NowPri"] = data.Result[0].Data.NowPri;
                    FocusTable.Rows[i]["Increase"] = data.Result[0].Data.Increase;
                    FocusTable.Rows[i]["TraNumber"] = data.Result[0].Data.TraNumber;
                    FocusTable.Rows[i]["TodayStartPri"] = data.Result[0].Data.TodayStartPri;
                    FocusTable.Rows[i]["YestodEndPri"] = data.Result[0].Data.YestodEndPri;
                    FocusTable.Rows[i]["TodayMax"] = data.Result[0].Data.TodayMax;
                    FocusTable.Rows[i]["TodayMin"] = data.Result[0].Data.TodayMin;
                }

            }
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex ==0)
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
                targetPage = Convert.ToInt32(TbxPageNum.Text)-1;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字");
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
    }
}
