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
using System.Threading;
namespace Crawler
{
    public partial class Main : Form
    {
        string[] list = StockList.GetCode();
        public Main()
        {
            InitializeComponent();
            BtnStop.Enabled = false;
            list = StockList.GetCode();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false;
            BtnStop.Enabled = true;
            MainControl.Enabled = true;
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 服务启用\n";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            MainControl.Enabled = false;
            LoadAnn.Enabled = false;
            LoadSnap.Enabled = false;
            LoadLine.Enabled = false;
            BtnStart.Enabled = true;
            BtnStop.Enabled = false;
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 服务停止\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            try
            {
                OleDb.GetData("SELECT SYSDATE FROM DUAL");
                result = "成功";
            }
            catch
            {
                result = "失败";
            }
            finally
            {
                MessageBox.Show(result);
            }
        }

        /// <summary>
        /// Main timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainControl_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            //Stock open
            if (now.Hour == 09 && now.Minute == 20 && IsTradeDay())
            {
                LoadAnn.Enabled = true;
                LoadLine.Enabled = true;
                LoadSnap.Enabled = true;
            }

            //Stock Close
            if (now.Hour == 15 && now.Minute == 00 && IsTradeDay())
            {
                LoadAnn.Enabled = false;
                LoadLine.Enabled = false;
                LoadSnap.Enabled = false;
            }


            //Script
            if (now.Hour == 15 && now.Minute == 10 && IsTradeDay())
            {
                richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 更新历史数据\n";
                //make line to his

                StockHisData.ConvertLine();
                //set ann all as alarmed 
                richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 修改公告状态\n";
                OleDb.ExecuteSQL("UPDATE ANNOUNCEMENT SET ALARMED  = 1 WHERE ALARMED =0 AND DAYS = SYSDATE");
                //load ecno data
                richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 抓取财务数据\n";
                ECNOData.Insert();
            }
        }
        /// <summary>
        /// load announcement document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadAnn_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 开始抓取公告\n";
            Announcement.Load();
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 开始抓取公告\n";
        }


        /// <summary>
        /// load line data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadLine_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 开始抓取日间数据\n";
            

            foreach (var item in list)
            {
                StockLineData data = StockLineData.GetLineDataObject(item);
                OleDb.ExecuteSQL($"DELETE FROM STOCK_LINE_DATA WHERE CODE = '{item}' and DAYS = TO_CHAR(SYSDATE,'YYYYMMDD') ");
                Task.Factory.StartNew(() => StockLineData.SaveToDB(data));
            }
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 结束抓取日间数据\n";
        }
        /// <summary>
        /// load snap data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSnap_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 开始抓取快照数据\n";

            foreach (var item in list)
            {
                SnapData data = SnapData.GetSnap(item);
                Task.Factory.StartNew(() => SnapData.SaveToDB(data));
            }
            richTextBox1.Text += $"{DateTime.Today.ToShortDateString()} {DateTime.Now.ToLongTimeString()} 结束抓取快照数据\n";
        }

        /// <summary>
        /// check today is or not a trade day
        /// </summary>
        /// <returns></returns>
        private bool IsTradeDay()
        {

            return StockLineData.GetLineDataObject("000001").Date.ToString().Equals(DateTime.Now.ToString("yyyyMMdd")) ? true : false;

        }
    }
}
