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
            LabName.Text = QuantTradeDLL.DBUtility.OracleClient.GetData($"select name from stock_list where code = '{Code}'").Tables[0].Rows[0][0].ToString().Replace(" ","");

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
            ChartMain.Series[0]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            ChartMain.Series[0]["PriceDownColor"] = "Red"; // <<== use text indexer for series

            int i = 0;
            foreach (var item in data.Kline)
            {
                ChartMain.Series[0].Points.AddXY(new DateTime(Convert.ToInt32(item.Date.Substring(0, 4)), Convert.ToInt32(item.Date.Substring(4, 2)), Convert.ToInt32(item.Date.Substring(6, 2))), item.High);

                ChartMain.Series[0].Points[i].YValues[1] =item.Low;
                //adding open
                ChartMain.Series[0].Points[i].YValues[2] = item.Open;
                // adding close
                ChartMain.Series[0].Points[i].YValues[3] = item.Close;
        
                i++;

            }
            ChartMain.Series[0].XValueType = ChartValueType.DateTime;
            //Convert.ToDouble(new DateTime(Convert.ToInt32(str.Substring(0, 4)), Convert.ToInt32(str.Substring(4, 2)), Convert.ToInt32(str.Substring(6, 2))))


        }


        
    }
}
