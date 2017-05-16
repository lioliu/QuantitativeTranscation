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
    public partial class StockKline : Form
    {
        private StockHisData Data { set; get; }
        private string Code { set; get; }
        private int Days { set; get; }
        public StockKline(string code)
        {
            InitializeComponent();
            Code = code;
            Days = 25;
            LoadKLine();
            ComDays.SelectedIndex = 0;
            Com1.SelectedIndex = 0;
            //ChartMain.MouseWheel += new MouseEventHandler(ChartMain_MouseWheel);
        }
        private void LoadKLine()
        {
            ChartMain.Series[0] = new Series()
            {
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Candlestick,
                Name = "日线"
            };
            ChartMain.Series[1] = new Series()
            {
                ChartArea = "ChartArea2",
                ChartType = SeriesChartType.Column,
                IsXValueIndexed = true,
                Name = "成交量"
            };
            Data = StockHisData.GetHisData(Code, (-Days).ToString(), "-1");
            LabCode.Text = Code;
            LabName.Text = QuantTradeDLL.DBUtility.OracleClient.GetData($"select name from stock_list where code = '{Code}'").Tables[0].Rows[0][0].ToString().Replace(" ", "");
            //foreach (var Data.Kline[i] in data.Kline)
            //{
            //    Console.WriteLine(Data.Kline[i].Date);
            //}
            ;
            // Set the style of the open-close marks
            ChartMain.Series[0]["OpenCloseStyle"] = "Triangle";
            // Show both open and close marks
            ChartMain.Series[0]["ShowOpenClose"] = "Both";
            // Set point width
            ChartMain.Series[0]["PointWidth"] = "1.0";
            // Set colors bars
            ChartMain.Series[0]["PriceUpColor"] = "Red"; // <<== use text indexer for series
            ChartMain.Series[0]["PriceDownColor"] = "Green"; // <<== use text indexer for series
            double maxNum = double.MinValue;
            double minNum = double.MaxValue;
            for (int i = 1; i < Data.Kline.Length; i++)
            {
                ChartMain.Series[0].Points.AddXY(new DateTime(Convert.ToInt32(Data.Kline[i].Date.Substring(0, 4)), Convert.ToInt32(Data.Kline[i].Date.Substring(4, 2)), Convert.ToInt32(Data.Kline[i].Date.Substring(6, 2))), Data.Kline[i].High);
                ChartMain.Series[0].Points[i - 1].YValues[1] = Data.Kline[i].Low;
                //adding open
                ChartMain.Series[0].Points[i - 1].YValues[2] = Data.Kline[i].Open;
                // adding close
                ChartMain.Series[0].Points[i - 1].YValues[3] = Data.Kline[i].Close;
                ChartMain.Series[1].Points.AddXY(new DateTime(Convert.ToInt32(Data.Kline[i].Date.Substring(0, 4)), Convert.ToInt32(Data.Kline[i].Date.Substring(4, 2)), Convert.ToInt32(Data.Kline[i].Date.Substring(6, 2))), Data.Kline[i].Amount / 1000);
                maxNum = Data.Kline[i].High > maxNum ? Data.Kline[i].High : maxNum;
                minNum = Data.Kline[i].Low < minNum ? Data.Kline[i].Low : minNum;
            }
            ChartMain.Series[0].XValueType = ChartValueType.DateTime;
            //Convert.ToDouble(new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2))))
            ChartMain.ChartAreas[0].AxisY.Minimum = minNum - (maxNum - minNum) * 0.1;
            ChartMain.ChartAreas[0].AxisY.Maximum = maxNum + (maxNum - minNum) * 0.1;
            ChartMain.Invalidate();
        }
        private void ChartMain_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(e.X);
            int index = 0;
            try
            {
                index = Convert.ToInt16((ChartMain.ChartAreas[0].AxisX.Maximum - ChartMain.ChartAreas[0].AxisX.Minimum) / (1140 - 130) * (e.X - 130));
            }
            catch (Exception)
            {
                return;
            }
            if (index > 0 && index <= ChartMain.Series[0].Points.Count)
            {
                // Find selected data point  
                DataPoint point = ChartMain.Series[0].Points[index - 1];
                #region load Detail
                LabDate.Text = Data.Kline[index].Date;
                LabHigh.Text = point.YValues[0].ToString();
                LabLow.Text = point.YValues[1].ToString();
                LabOpen.Text = point.YValues[2].ToString();
                LabClose.Text = point.YValues[3].ToString();
                LabIncrease.Text = (Convert.ToDouble(point.YValues[3]) - Convert.ToDouble(point.YValues[2])).ToString("F2");
                LabIncrePer.Text = ((Convert.ToDouble(point.YValues[3]) - Convert.ToDouble(point.YValues[2])) / Convert.ToDouble(point.YValues[3]) * 100).ToString("F2") + "%";
                LabAmount.Text = ChartMain.Series[1].Points[index - 1].YValues[0].ToString();
                #endregion
                #region Set Color
                LabHigh.ForeColor = Convert.ToDouble(LabHigh.Text) > Convert.ToDouble(Data.Kline[index - 1].Close) ? Color.Red : Color.Green;
                LabLow.ForeColor = Convert.ToDouble(LabLow.Text) > Convert.ToDouble(Data.Kline[index - 1].Close) ? Color.Red : Color.Green;
                LabOpen.ForeColor = Convert.ToDouble(LabOpen.Text) > Convert.ToDouble(Data.Kline[index - 1].Close) ? Color.Red : Color.Green;
                LabClose.ForeColor = Convert.ToDouble(LabClose.Text) > Convert.ToDouble(Data.Kline[index - 1].Close) ? Color.Red : Color.Green;
                LabIncrease.ForeColor = LabClose.ForeColor;
                LabIncrePer.ForeColor = LabClose.ForeColor;
                #endregion
            }
        }

        private void ChartMain_MouseWheel(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("滚动事件已被捕捉");
            //Console.WriteLine(e.Delta);
            ////write code here
            //Days = Days + e.Delta < 0 ? -1 : 1;
            //LoadKLine();
        }
        #region Butrn Event
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void BtnReWrite_Click(object sender, EventArgs e)
        {
            if (Com1.SelectedText == "增加")
            {
                Days += Convert.ToInt32(ComDays);
            }
            else
            {
                Days -= Convert.ToInt32(ComDays.Text);
                if (Days < 10)
                {
                    MessageBox.Show("时间跨度不能少于10天", "错误");
                    return;
                }
            }
            LoadKLine();
        }
        private void BtnReSet_Click(object sender, EventArgs e)
        {
            Days = 25;
            LoadKLine();
        }
        private void BtnAddFiveDays_Click(object sender, EventArgs e)
        {
            Days += 5;
            LoadKLine();
        }
        private void BtnMinusFiveDays_Click(object sender, EventArgs e)
        {
            Days -= 5;
            if (Days < 10)
            {
                MessageBox.Show("时间跨度不能少于10天", "错误");
                return;
            }
            LoadKLine();
        }
        #endregion
    }
}
