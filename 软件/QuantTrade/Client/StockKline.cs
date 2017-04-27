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
        private string Code { set; get; }
        public StockKline(string code)
        {

            InitializeComponent();
            Code = code;

            StockHisData data = StockHisData.GetHisData(Code, "-25", "-1");
            LabCode.Text = code;
            LabName.Text = QuantTradeDLL.DBUtility.OracleClient.GetData($"select name from stock_list where code = '{Code}'").Tables[0].Rows[0][0].ToString().Replace(" ", "");

            //foreach (var item in data.Kline)
            //{
            //    Console.WriteLine(item.Date);
            //}

            ChartMain.Series[0].ChartType = SeriesChartType.Candlestick;

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
            int i = 0;
            foreach (var item in data.Kline)
            {
                ChartMain.Series[0].Points.AddXY(new DateTime(Convert.ToInt32(item.Date.Substring(0, 4)), Convert.ToInt32(item.Date.Substring(4, 2)), Convert.ToInt32(item.Date.Substring(6, 2))), item.High);

                ChartMain.Series[0].Points[i].YValues[1] = item.Low;
                //adding open
                ChartMain.Series[0].Points[i].YValues[2] = item.Open;
                // adding close
                ChartMain.Series[0].Points[i].YValues[3] = item.Close;

                ChartMain.Series[1].Points.AddXY(new DateTime(Convert.ToInt32(item.Date.Substring(0, 4)), Convert.ToInt32(item.Date.Substring(4, 2)), Convert.ToInt32(item.Date.Substring(6, 2))), item.Amount/1000);

                maxNum = item.High > maxNum ? item.High : maxNum;
                minNum = item.Low < minNum ? item.Low : minNum;

                i++;

            }
            ChartMain.Series[0].XValueType = ChartValueType.DateTime;
            //Convert.ToDouble(new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2))))

            ChartMain.ChartAreas[0].AxisY.Minimum = minNum - (maxNum -minNum)*0.1;
            ChartMain.ChartAreas[0].AxisY.Maximum = maxNum + (maxNum - minNum) * 0.1;

         
        }

        private void ChartMain_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X);
            int index = 0;
            try
            {
                index = Convert.ToInt16((ChartMain.ChartAreas[0].AxisX.Maximum - ChartMain.ChartAreas[0].AxisX.Minimum) / (1100 - 100) * (e.X - 100));
            }
            catch (Exception)
            {

                return;
            }
            if (index > 0 && index < ChartMain.Series[0].Points.Count)
            {
                // Find selected data point  
                DataPoint point = ChartMain.Series[0].Points[index];

                
                LabDate.Text = new DateTime(1, 1, 1).AddDays(ChartMain.Series[1].Points[index].XValue).ToString();
                LabHigh.Text = point.YValues[0].ToString();
                LabLow.Text = point.YValues[1].ToString();
                LabOpen.Text = point.YValues[2].ToString();
                LabClose.Text = point.YValues[3].ToString();
                LabIncrease.Text = (Convert.ToDouble(point.YValues[3]) - Convert.ToDouble(point.YValues[2])).ToString("F2");
                LabIncrePer.Text = ((Convert.ToDouble(point.YValues[3]) - Convert.ToDouble(point.YValues[2])) / Convert.ToDouble(point.YValues[3]) * 100).ToString("F2") + "%";
                LabAmount.Text = ChartMain.Series[1].Points[index].YValues[0].ToString();
            }
        }
    }
}
