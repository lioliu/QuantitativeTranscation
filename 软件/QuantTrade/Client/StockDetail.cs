using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuantTradeDLL.Crawler;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client
{
    public partial class StockDetail : Form
    {
        private string Yesterday { set; get; }
        private string Code { set; get; }

        //private bool flag = false;

        public StockDetail(string code)
        {
            Code = code;
            InitializeComponent();
            LoadSnap();
            LoadAnn();
            LoadChart();
            //flag = true;
            TimerLine.Enabled = true;
            TimerSnap.Enabled = true;
        }

        private void LoadChart()
        {
            ChartMain.Invalidate();
            #region Chart
            DataTable line = StockLineData.ForCharts(StockLineData.GetLineDataObject(Code));
            ChartMain.DataSource = line;
            ChartMain.DataBind();
            ChartMain.Series[0].YValueMembers = "PRICE";
            ChartMain.Series[0].YValueType = ChartValueType.Double;
            ChartMain.ChartAreas[0].AxisY.Minimum = (Convert.ToDouble(LabTodayMin.Text) - Convert.ToDouble(LabTodayMax.Text))*0.1 + Convert.ToDouble(LabTodayMin.Text);
            ChartMain.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(LabTodayMax.Text) + (Convert.ToDouble(LabTodayMax.Text) - Convert.ToDouble(LabTodayMin.Text))*0.1;



            ChartMain.Series[0].XValueMember = "TIME";

            ChartMain.Series[0].XValueType = ChartValueType.String;




            ChartMain.Series[1].YValueMembers = "VOLUME";
            ChartMain.Series[1].YValueType = ChartValueType.Double;
            ChartMain.Series[1].XValueMember = "TIME";
            ChartMain.Series[1].XValueType = ChartValueType.String;
            ChartMain.Invalidate();

            #endregion
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", e.Link.LinkData.ToString());
        }

        private void ChartMain_MouseMove(object sender, MouseEventArgs e)
        {

            // Reset Data Point Attributes  

            // Call HitTest  
            //(X轴最大值-X轴最小值）/（X最大值出的e.X-X最小值处的e.X）=（鼠标所在位置X坐标-X最小坐标)/（鼠标所在位置e.X-X最小值处的e.X）  

            //Console.WriteLine((ChartMain.ChartAreas[0].AxisX.Maximum - ChartMain.ChartAreas[0].AxisX.Minimum)
            //    /(930-70)*(e.X-70));

            //Console.WriteLine(ChartMain.ChartAreas[0].AxisX.Maximum - ChartMain.ChartAreas[0].AxisX.Minimum);
            //Console.WriteLine(e.X);
            //  result = ChartMain.HitTest(e.X, e);
            int index = 0; ;
            // If the mouse if over a data point  
            try
            {
                index = Convert.ToInt16((ChartMain.ChartAreas[0].AxisX.Maximum - ChartMain.ChartAreas[0].AxisX.Minimum) / (930 - 70) * (e.X - 70));
            }
            catch (Exception)
            {

                return;
            }

            if (index > 0 && index < ChartMain.Series[0].Points.Count)
            {
                // Find selected data point  
                DataPoint point = ChartMain.Series[0].Points[index];


                LabTime.Text = point.AxisLabel;
                LabPri.Text = point.YValues[0].ToString();
                LabIncrease2.Text = (Convert.ToDouble(LabPri.Text) - Convert.ToDouble(Yesterday)).ToString("F2");
                LabIncrePer2.Text = ((Convert.ToDouble(LabPri.Text) - Convert.ToDouble(Yesterday)) / Convert.ToDouble(Yesterday) * 100).ToString("F2") + "%";
                LabValue2.Text = ChartMain.Series[1].Points[index].YValues[0].ToString();
            }

            #region mark color  
            LabPri.ForeColor = Convert.ToDouble(LabPri.Text) > Convert.ToDouble(Yesterday) ? Color.Red :
                Convert.ToDouble(LabPri.Text) == Convert.ToDouble(Yesterday) ? Color.Black : Color.Green;

            LabIncrease2.ForeColor = LabPri.ForeColor;
            LabIncrePer2.ForeColor = LabPri.ForeColor;
            #endregion



        }

        private void TimerSnap_Tick(object sender, EventArgs e)
        {
            LoadSnap();
        }

        private void TimerLine_Tick(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadSnap()
        {
            SnapData data = SnapData.GetSnap(Code);
            Yesterday = data.Result[0].Data.YestodEndPri;
            #region fill data
            //base information
            LabCode.Text = data.Result[0].Data.Gid;
            LabName.Text = data.Result[0].Data.Name;
            LabNowPri.Text = data.Result[0].Data.NowPri;
            LabTodayMax.Text = data.Result[0].Data.TodayMax;
            LabTodayMin.Text = data.Result[0].Data.TodayMin;
            LabTraAmount.Text = data.Result[0].Data.TraAmount;
            LabTraNum.Text = data.Result[0].Data.TraNumber;
            LabTodayStartPri.Text = data.Result[0].Data.TodayStartPri;
            LabIncrease.Text = data.Result[0].Data.Increase;
            LabIncrePer.Text = data.Result[0].Data.IncrePer;
            LabLimitUp.Text = (Convert.ToDouble(data.Result[0].Data.TodayStartPri) * 1.1).ToString("F3");
            LabLimitDown.Text = (Convert.ToDouble(data.Result[0].Data.TodayStartPri) * 0.9).ToString("F3");

            //buy five

            LabBuyFive.Text = data.Result[0].Data.BuyFive;
            LabBuyFivePri.Text = data.Result[0].Data.BuyFivePri;
            LabBuyFour.Text = data.Result[0].Data.BuyFour;
            LabBuyFourPri.Text = data.Result[0].Data.BuyFourPri;
            LabBuyThree.Text = data.Result[0].Data.BuyThree;
            LabBuyThreePri.Text = data.Result[0].Data.BuyThreePri;
            LabBuyTwo.Text = data.Result[0].Data.BuyTwo;
            LabBuyTwoPri.Text = data.Result[0].Data.BuyTwoPri;
            LabBuyOne.Text = data.Result[0].Data.BuyOne;
            LabBuyOnePri.Text = data.Result[0].Data.BuyOnePri;

            //sell five
            LabSellFive.Text = data.Result[0].Data.SellFive;
            LabSellFivePri.Text = data.Result[0].Data.SellFivePri;
            LabSellFour.Text = data.Result[0].Data.SellFour;
            LabSellFourPri.Text = data.Result[0].Data.SellFourPri;
            LabSellThree.Text = data.Result[0].Data.SellThree;
            LabSellThreePri.Text = data.Result[0].Data.SellThreePri;
            LabSellTwo.Text = data.Result[0].Data.SellTwo;
            LabSellTwoPri.Text = data.Result[0].Data.SellTwoPri;
            LabSellOne.Text = data.Result[0].Data.SellOne;
            LabSellOnePri.Text = data.Result[0].Data.SellOnePri;



            #endregion

            #region mark color
            //base information
            LabNowPri.ForeColor = Convert.ToDouble(LabNowPri.Text) >= Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red : Color.Green;
            LabTodayMax.ForeColor = Convert.ToDouble(LabTodayMax.Text) >= Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red : Color.Green;
            LabIncrease.ForeColor = LabNowPri.ForeColor;
            LabIncrePer.ForeColor = LabNowPri.ForeColor;
            LabLimitDown.ForeColor = Color.Green;
            LabLimitUp.ForeColor = Color.Red;
            LabTodayMin.ForeColor = Convert.ToDouble(LabTodayMin.Text) >= Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red : Color.Green;
            LabTraAmount.ForeColor = Color.Blue;
            LabTraNum.ForeColor = Color.Blue;
            LabTodayStartPri.ForeColor = Convert.ToDouble(LabTodayStartPri.Text) >= Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red : Color.Green;

            //Buy Five
            LabBuyFive.ForeColor = Convert.ToDouble(LabBuyFivePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabBuyFivePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabBuyFivePri.ForeColor = LabBuyFive.ForeColor;

            LabBuyFour.ForeColor = Convert.ToDouble(LabBuyFourPri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabBuyFourPri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabBuyFourPri.ForeColor = LabBuyFour.ForeColor;

            LabBuyThree.ForeColor = Convert.ToDouble(LabBuyThreePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabBuyThreePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabBuyThreePri.ForeColor = LabBuyThree.ForeColor;

            LabBuyTwo.ForeColor = Convert.ToDouble(LabBuyTwoPri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabBuyTwoPri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabBuyTwoPri.ForeColor = LabBuyTwo.ForeColor;

            LabBuyOne.ForeColor = Convert.ToDouble(LabBuyOnePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabBuyOnePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabBuyOnePri.ForeColor = LabBuyOne.ForeColor;
            //Sell Five
            LabSellFive.ForeColor = Convert.ToDouble(LabSellFivePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
               Convert.ToDouble(LabSellFivePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabSellFivePri.ForeColor = LabSellFive.ForeColor;

            LabSellFour.ForeColor = Convert.ToDouble(LabSellFourPri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabSellFourPri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabSellFourPri.ForeColor = LabSellFour.ForeColor;

            LabSellThree.ForeColor = Convert.ToDouble(LabSellThreePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabSellThreePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabSellThreePri.ForeColor = LabSellThree.ForeColor;

            LabSellTwo.ForeColor = Convert.ToDouble(LabSellTwoPri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabSellTwoPri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabSellTwoPri.ForeColor = LabSellTwo.ForeColor;

            LabSellOne.ForeColor = Convert.ToDouble(LabSellOnePri.Text) > Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Red :
                Convert.ToDouble(LabSellOnePri.Text) == Convert.ToDouble(data.Result[0].Data.YestodEndPri) ? Color.Black : Color.Green;
            LabSellOnePri.ForeColor = LabSellOne.ForeColor;


            //detail  
            LabValue2.ForeColor = Color.Blue;

            #endregion


            #region Calculate Committee

            LabCommittee.Text = ((((Convert.ToDouble(LabBuyOne.Text) + Convert.ToDouble(LabBuyTwo.Text) + Convert.ToDouble(LabBuyThree.Text) + Convert.ToDouble(LabBuyFour.Text) + Convert.ToDouble(LabBuyFive.Text)) - (Convert.ToDouble(LabSellOne.Text) + Convert.ToDouble(LabSellTwo.Text) + Convert.ToDouble(LabSellThree.Text) + Convert.ToDouble(LabSellFour.Text) + Convert.ToDouble(LabSellFive.Text))) /
                 ((Convert.ToDouble(LabBuyOne.Text) + Convert.ToDouble(LabBuyTwo.Text) + Convert.ToDouble(LabBuyThree.Text) + Convert.ToDouble(LabBuyFour.Text) + Convert.ToDouble(LabBuyFive.Text)) + (Convert.ToDouble(LabSellOne.Text) + Convert.ToDouble(LabSellTwo.Text) + Convert.ToDouble(LabSellThree.Text) + Convert.ToDouble(LabSellFour.Text) + Convert.ToDouble(LabSellFive.Text)))) * 100).ToString("F2");
            LabCommitteeNum.Text = (((Convert.ToDouble(LabBuyOne.Text) + Convert.ToDouble(LabBuyTwo.Text) + Convert.ToDouble(LabBuyThree.Text) + Convert.ToDouble(LabBuyFour.Text) + Convert.ToDouble(LabBuyFive.Text)) - (Convert.ToDouble(LabSellOne.Text) + Convert.ToDouble(LabSellTwo.Text) + Convert.ToDouble(LabSellThree.Text) + Convert.ToDouble(LabSellFour.Text) + Convert.ToDouble(LabSellFive.Text)))).ToString();

            LabCommittee.ForeColor = Convert.ToDouble(LabCommittee.Text) > 0 ? Color.Red : Color.Green;
            LabCommitteeNum.ForeColor = Convert.ToDouble(LabCommitteeNum.Text) > 0 ? Color.Red : Color.Green;

            #endregion

        }

        private void LoadAnn()
        {
            #region load announcement
            DataTable dt = Announcement.Get(Code);
            
            LinkAnn1.Text = dt.Rows[0]["TITLE"].ToString().Substring(7);

            LinkAnn1.Links.Add(0, LinkAnn1.Text.Length, dt.Rows[0]["URL"].ToString());
            LabAnnDate1.Text = Convert.ToDateTime(dt.Rows[0]["days"].ToString()).ToString("M");
            if (LinkAnn1.Text.Length > 35)
            {
                LinkAnn1.Text = $"{LinkAnn1.Text.Substring(0, 35)}...";
            }

            LinkAnn2.Text = dt.Rows[1]["TITLE"].ToString().Substring(7);

            LinkAnn2.Links.Add(0, LinkAnn2.Text.Length, dt.Rows[1]["URL"].ToString());
            LabAnnDate2.Text = Convert.ToDateTime(dt.Rows[1]["days"].ToString()).ToString("M");
            if (LinkAnn2.Text.Length > 35)
            {
                LinkAnn2.Text = $"{LinkAnn2.Text.Substring(0, 35)}...";
            }
            
            LinkAnn3.Text = dt.Rows[2]["TITLE"].ToString().Substring(7);

            LinkAnn3.Links.Add(0, LinkAnn3.Text.Length, dt.Rows[2]["URL"].ToString());
            LabAnnDate3.Text = Convert.ToDateTime(dt.Rows[2]["days"].ToString()).ToString("M");
            if (LinkAnn3.Text.Length > 35)
            {
                LinkAnn3.Text = $"{LinkAnn3.Text.Substring(0, 35)}...";
            }

            LinkAnn1.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);
            LinkAnn2.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);
            LinkAnn3.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);
            #endregion
        }
    }
}
