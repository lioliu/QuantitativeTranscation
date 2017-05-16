using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace QuantTradeDLL.Crawler
{
    public class ECNOData
    {
        public string Code { get; set; }
        public double Income { get; set; }
        public double PE { get; set; }
        public double BVPS { get; set; }
        public double PB { get; set; }
        public double Revenue { get; set; }
        public double RevenueYOY { get; set; }
        public double NetProfit { get; set; }
        public double NetProfitYOY { get; set; }
        public double GrossMargin { get; set; }
        public double NetMargin { get; set; }
        public double ROE { get; set; }
        public double DebtRatio { get; set; }
        public double Equity { get; set; }
        public double Value { get; set; }
        public double UDPPS { get; set; }
        /// <summary>
        /// Main funcation Update ECNO infor
        /// </summary>
        /// <returns>it success or not</returns>
        public static bool Insert()
        {
            // string[] stockList = StockList.GetCode();
            // Task.Factory.StartNew(() => TaskDO(stockList[0]));
            string[] stockList = StockList.GetCode();
            foreach (var item in stockList)
            {
                Task.Factory.StartNew(() => TaskDO(item));
            }
            return true;
        }
        public static ECNOData LoadData(string stock)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load($"http://quote.eastmoney.com/sh{stock}.html");
            HtmlNodeCollection Income = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[1]/td[1]/text()[2]");
            HtmlNodeCollection PE = doc.DocumentNode.SelectNodes("//*[@id=\"gt6_2\"]");
            HtmlNodeCollection BVPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[2]/td[1]/text()");
            HtmlNodeCollection PB = doc.DocumentNode.SelectNodes("//*[@id=\"gt13_2\"]");
            HtmlNodeCollection Revenue = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[1]");
            HtmlNodeCollection RevenueYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[2]/text()");
            HtmlNodeCollection NetProfit = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[1]");
            HtmlNodeCollection NetProfitYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[2]");
            HtmlNodeCollection GrossMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[1]/text()");
            HtmlNodeCollection NetMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[2]");
            HtmlNodeCollection ROE = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[1]/text()");
            HtmlNodeCollection DebtRatio = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[2]");
            HtmlNodeCollection Equity = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[7]/td[1]");
            HtmlNodeCollection Value = doc.DocumentNode.SelectNodes("//*[@id=\"gt7_2\"]");
            HtmlNodeCollection UDPPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[9]/td");
            Regex reg = new Regex(@"[+-]?\d+(\.\d+)?");
            return  new ECNOData()
            {
                Code = stock,
                Income = Convert.ToDouble(reg.Match(Income.Single().InnerText).Value),
                PE = Convert.ToDouble(reg.Match(PE.Single().InnerText == "-" ? "0" : PE.Single().InnerText).Value),
                BVPS = Convert.ToDouble(reg.Match(BVPS.Single().InnerText).Value),
                PB = Convert.ToDouble(reg.Match(PB.Single().InnerText).Value),
                Revenue = Convert.ToDouble(reg.Match(Revenue.Single().InnerText).Value),
                RevenueYOY = Convert.ToDouble(reg.Match(RevenueYOY.Single().InnerText).Value),
                NetProfit = Convert.ToDouble(reg.Match(NetProfit.Single().InnerText).Value),
                NetProfitYOY = Convert.ToDouble(reg.Match(NetProfitYOY.Single().InnerText).Value),
                GrossMargin = Convert.ToDouble(reg.Match(GrossMargin.Single().InnerText).Value),
                NetMargin = Convert.ToDouble(reg.Match(NetMargin.Single().InnerText).Value),
                ROE = Convert.ToDouble(reg.Match(ROE.Single().InnerText).Value),
                DebtRatio = Convert.ToDouble(reg.Match(DebtRatio.Single().InnerText).Value),
                Equity = Convert.ToDouble(reg.Match(Equity.Single().InnerText).Value),
                Value = Convert.ToDouble(reg.Match(Value.Single().InnerText).Value),
                UDPPS = Convert.ToDouble(reg.Match(UDPPS.Single().InnerText).Value)
            };
        }
        private static void TaskDO(string stock)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load($"http://quote.eastmoney.com/sh{stock}.html");
            HtmlNodeCollection Income = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[1]/td[1]/text()[2]");
            HtmlNodeCollection PE = doc.DocumentNode.SelectNodes("//*[@id=\"gt6_2\"]");
            HtmlNodeCollection BVPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[2]/td[1]/text()");
            HtmlNodeCollection PB = doc.DocumentNode.SelectNodes("//*[@id=\"gt13_2\"]");
            HtmlNodeCollection Revenue = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[1]");
            HtmlNodeCollection RevenueYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[2]/text()");
            HtmlNodeCollection NetProfit = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[1]");
            HtmlNodeCollection NetProfitYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[2]");
            HtmlNodeCollection GrossMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[1]/text()");
            HtmlNodeCollection NetMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[2]");
            HtmlNodeCollection ROE = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[1]/text()");
            HtmlNodeCollection DebtRatio = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[2]");
            HtmlNodeCollection Equity = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[7]/td[1]");
            HtmlNodeCollection Value = doc.DocumentNode.SelectNodes("//*[@id=\"gt7_2\"]");
            HtmlNodeCollection UDPPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[9]/td");
            Regex reg = new Regex(@"[+-]?\d+(\.\d+)?");
            ECNOData data = new ECNOData()
            {
                Code = stock,
                Income = Convert.ToDouble(reg.Match(Income.Single().InnerText).Value),
                PE = Convert.ToDouble(reg.Match(PE.Single().InnerText == "-" ? "0" : PE.Single().InnerText).Value),
                BVPS = Convert.ToDouble(reg.Match(BVPS.Single().InnerText).Value),
                PB = Convert.ToDouble(reg.Match(PB.Single().InnerText).Value),
                Revenue = Convert.ToDouble(reg.Match(Revenue.Single().InnerText).Value),
                RevenueYOY = Convert.ToDouble(reg.Match(RevenueYOY.Single().InnerText).Value),
                NetProfit = Convert.ToDouble(reg.Match(NetProfit.Single().InnerText).Value),
                NetProfitYOY = Convert.ToDouble(reg.Match(NetProfitYOY.Single().InnerText).Value),
                GrossMargin = Convert.ToDouble(reg.Match(GrossMargin.Single().InnerText).Value),
                NetMargin = Convert.ToDouble(reg.Match(NetMargin.Single().InnerText).Value),
                ROE = Convert.ToDouble(reg.Match(ROE.Single().InnerText).Value),
                DebtRatio = Convert.ToDouble(reg.Match(DebtRatio.Single().InnerText).Value),
                Equity = Convert.ToDouble(reg.Match(Equity.Single().InnerText).Value),
                Value = Convert.ToDouble(reg.Match(Value.Single().InnerText).Value),
                UDPPS = Convert.ToDouble(reg.Match(UDPPS.Single().InnerText).Value)
            };
            string insert = $"INSERT INTO STOCK_ECNO_DATA VALUES{$"('{data.Code}',sysdate,'{data.Income}','{data.PE}','{data.BVPS}','{data.PB}','{data.Revenue}','{data.RevenueYOY}','{data.NetProfit}','{data.NetProfitYOY}','{data.GrossMargin}','{data.NetMargin}','{data.ROE}','{data.DebtRatio}','{data.Equity}','{data.Value}','{data.UDPPS}')"}";
            Console.WriteLine(DBUtility.OleDb.ExecuteSQL(insert) + data.Code);
        }
    }
}
