using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTradeDLL.Crawler;
using System.Data;
using System.Threading;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
namespace ConsoleDemo
{
    class Program
    {
        public static int i = 0;
        static void Main(string[] args)
        {

            Announcement.Load();

            //string[] stockList = StockList.GetCode();

            //foreach (var item in stockList)
            //{
            //    Task.Factory.StartNew(() => NewMethod(item));
            //}
            //string[] stockList = StockList.GetCode();
            //HtmlWeb web = new HtmlWeb()
            //{
            //    OverrideEncoding = Encoding.Default
            //};
            //HtmlDocument doc = web.Load($"http://quote.eastmoney.com/sh{stockList}.html");
            //HtmlNode Document,Time;
            //Announcement data;
            //int tag = 1;
            //for ( tag = 1; tag <= 5; tag++)
            //{
            //    Document = doc.DocumentNode.SelectSingleNode($"/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[{tag}]/a");
            //    Time = doc.DocumentNode.SelectSingleNode($"/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[{tag}]/span");

            //    data = new Announcement()
            //    {
            //        Code = stockList,
            //        Title = Document.Attributes["title"].Value,
            //        Url = Document.Attributes["href"].Value,
            //        Days = Time.InnerHtml
            //    };

            //    if (QuantTradeDLL.DBUtility.OracleClient.GetData($"SELECT COUNT(*) FROM Announcement where Code = '{data.Code}' and Url = '{data.Url}' ").Tables[0].Rows[0][0].ToString() == "0")
            //    {
            //        //formate the date;
            //        string date = DateTime.Now.Year.ToString() + "-" + data.Days;
            //        QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL($"Insert INTO Announcement VALUES ('{data.Code}','{data.Title}','{data.Url}',TO_DATE('{date}','YYYY-MM-DD'))");
            //    }
            //}

          
              


            //  HtmlNode Document1 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[1]/a");
            //  HtmlNode Time1 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[1]/span");
            //  HtmlNode Document2 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[2]/a");
            //  HtmlNode Time2 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[2]/span");
            //  HtmlNode Document3 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[3]/a");
            //  HtmlNode Time3 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[3]/span");
            //  HtmlNode Document4 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[4]/a");
            //  HtmlNode Time4 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[4]/span");
            //  HtmlNode Document5 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[5]/a");
            //  HtmlNode Time5 = doc.DocumentNode.SelectSingleNode("/html/body/div[13]/div[2]/div[3]/div[2]/div[2]/div/ul/li[5]/span");

            //  Announcement data = new Announcement();
            //  data.Code = stockList;
            //  data.Title = Document1.Attributes["title"].Value;
            //  data.Url = Document1.Attributes["href"].Value;
            //  data.Days = Time1.InnerHtml;

            //  Console.WriteLine(data.Code);
            //  Console.WriteLine(data.Title);
            //  Console.WriteLine(data.Url);
            //  Console.WriteLine(data.Days);
            //  //this Announcement has not been load into database; 
            //  if (QuantTradeDLL.DBUtility.OracleClient.GetData($"SELECT COUNT(*) FROM Announcement where Code = '{data.Code}' and Url = '{data.Url}' ").Tables[0].Rows[0][0].ToString() =="0")
            //  {
            //      //formate the date;
            //      string date = DateTime.Now.Year.ToString() + "-" + data.Days;
            //      QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL($"Insert INTO Announcement VALUES ('{data.Code}','{data.Title}','{data.Url}',TO_DATE('{date}','YYYY-MM-DD'))");
            //  }
              
            ////QuantTradeDLL.Crawler.ECNOData.Update();


            // Regex reg = new Regex(@"[+-]?\d+(\.\d+)?");

            // ECNOData data = new ECNOData();
            // data.Code = stockList;
            // data.Income = Convert.ToDouble(reg.Match(Income.Single().InnerText).Value);
            // data.PE = Convert.ToDouble(reg.Match(PE.Single().InnerText).Value);
            // data.BVPS = Convert.ToDouble(reg.Match(BVPS.Single().InnerText).Value);
            // data.PB = Convert.ToDouble(reg.Match(PB.Single().InnerText).Value);
            // data.Revenue = Convert.ToDouble(reg.Match(Revenue.Single().InnerText).Value);
            // data.RevenueYOY = Convert.ToDouble(reg.Match(RevenueYOY.Single().InnerText).Value);
            // data.NetProfit = Convert.ToDouble(reg.Match(NetProfit.Single().InnerText).Value);
            // data.NetProfitYOY = Convert.ToDouble(reg.Match(NetProfitYOY.Single().InnerText).Value);
            // data.GrossMargin = Convert.ToDouble(reg.Match(GrossMargin.Single().InnerText).Value);
            // data.NetMargin = Convert.ToDouble(reg.Match(NetMargin.Single().InnerText).Value);
            // data.ROE = Convert.ToDouble(reg.Match(ROE.Single().InnerText).Value);
            // data.DebtRatio = Convert.ToDouble(reg.Match(DebtRatio.Single().InnerText).Value);
            // data.Equity = Convert.ToDouble(reg.Match(Equity.Single().InnerText).Value);
            // data.Value = Convert.ToDouble(reg.Match(Value.Single().InnerText).Value);
            // data.UDPPS = Convert.ToDouble(reg.Match(UDPPS.Single().InnerText).Value);

            //string insert = $"INSERT INTO STOCK_ECNO_DATA VALUES{$"('{data.Code}','{data.Income}','{data.PE}','{data.BVPS}','{data.PB}','{data.Revenue}','{data.RevenueYOY}','{data.NetProfit}','{data.NetProfitYOY}','{data.GrossMargin}','{data.NetMargin}','{data.ROE}','{data.DebtRatio}','{data.Equity}','{data.Value}','{data.UDPPS}')"}";
            //     int result = QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL(insert);

            // Console.WriteLine(result);



            /*  foreach (var item in hn)
              {
                  Console.WriteLine(item.InnerText);
                  Console.WriteLine("123");
              }*/

            //Console.OutputEncoding = Encoding.GetEncoding(936);
            //Console.OutputEncoding = Encoding.UTF8;
            //foreach (HtmlNode child in node.ChildNodes)
            //{

            //    HtmlNode hn = HtmlNode.CreateNode(child.OuterHtml);
            //    Console.WriteLine(hn.SelectSingleNode("//*[@id=\"rtp2\"]/tbody/tr[4]/td[1]").InnerText);
            //    ///如果用child.SelectSingleNode("//*[@class=\"titlelnk\"]").InnerText这样的方式查询，是永远以整个document为基准来查询，
            //    ///这点就不好，理应以当前child节点的html为基准才对。
            //    //Write(sw, String.Format("推荐：{0}", hn.SelectSingleNode("//*[@class=\"diggnum\"]").InnerText));
            //    //Write(sw, String.Format("标题：{0}", hn.SelectSingleNode("//*[@class=\"titlelnk\"]").InnerText));
            //    //Write(sw, String.Format("介绍：{0}", hn.SelectSingleNode("//*[@class=\"post_item_summary\"]").InnerText));
            //    //Write(sw, String.Format("信息：{0}", hn.SelectSingleNode("//*[@class=\"post_item_foot\"]").InnerText));

            //    //Write(sw, "----------------------------------------");

            //}


            //string[] list = StockList.GetCode();
            //foreach (var item in list)
            //{
            //    Task.Factory.StartNew(() => SnapData.GetSnap(item));

            //}
            //   QuantTradeDLL.Crawler.BaseCrawler crawler = new QuantTradeDLL.Crawler.BaseCrawler();
            //  Console.WriteLine(crawler.Run("http://hq.sinajs.cn/list=sh601006"));



            //load all line data
            //string[] stockList = QuantTradeDLL.Crawler.StockList.GetCode();
            //for (int i = 0; i < stockList.Length; i++)
            //{

            //    QuantTradeDLL.Crawler.StockLineData data =  QuantTradeDLL.Crawler.StockLineData.GetLineDataObject(stockList[i]);
            //    Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockLineData.SaveToDB(data));
            //    Console.WriteLine($"{stockList[i]}");
            //    Thread.Sleep(200);
            //}
            //Task.WaitAll();
            //Console.WriteLine("finished");



            //load all his data


            /*      //clearn the data in database 
                  QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL("DELETE FROM STOCK_HIS_DATA");

                  //get the stock list
                  string[] stockList = QuantTradeDLL.Crawler.StockList.GetCode();
              string temp;
                  for (int i = 0; i < stockList.Length; i++)
                  {
                  temp = stockList[i];
                  DataTable dt = 
                  QuantTradeDLL.Crawler.StockHisData.ToDataTable(
                  QuantTradeDLL.Crawler.StockHisData.GetHisData(temp));
                      Task.Factory.StartNew(() => QuantTradeDLL.Crawler.StockHisData.SaveToDB(dt));
                  // Task.Factory.StartNew(() => funcation(temp));
                  //Thread.Sleep(2000);
                  Console.WriteLine($"{temp}");
                  }
                  Task.WaitAll();

            */
            Console.ReadLine();
        }

        //private static void NewMethod(string stock)
        //{
        //    HtmlWeb web = new HtmlWeb();
        //    HtmlDocument doc = web.Load($"http://quote.eastmoney.com/sh{stock}.html");
        //    HtmlNodeCollection Income = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[1]/td[1]/text()[2]");
        //    HtmlNodeCollection PE = doc.DocumentNode.SelectNodes("//*[@id=\"gt6_2\"]");
        //    HtmlNodeCollection BVPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[2]/td[1]/text()");
        //    HtmlNodeCollection PB = doc.DocumentNode.SelectNodes("//*[@id=\"gt13_2\"]");
        //    HtmlNodeCollection Revenue = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[1]");
        //    HtmlNodeCollection RevenueYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[3]/td[2]/text()");
        //    HtmlNodeCollection NetProfit = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[1]");
        //    HtmlNodeCollection NetProfitYOY = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[4]/td[2]");
        //    HtmlNodeCollection GrossMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[1]/text()");
        //    HtmlNodeCollection NetMargin = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[5]/td[2]");
        //    HtmlNodeCollection ROE = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[1]/text()");
        //    HtmlNodeCollection DebtRatio = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[6]/td[2]");
        //    HtmlNodeCollection Equity = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[7]/td[1]");
        //    HtmlNodeCollection Value = doc.DocumentNode.SelectNodes("//*[@id=\"gt7_2\"]");
        //    HtmlNodeCollection UDPPS = doc.DocumentNode.SelectNodes("//*[@id=\"rtp2\"]/tbody/tr[9]/td");




        //    Regex reg = new Regex(@"[+-]?\d+(\.\d+)?");

        //    ECNOData data = new ECNOData()
        //    {
        //        Code = stock,
        //        Income = Convert.ToDouble(reg.Match(Income.Single().InnerText).Value),
        //        PE = Convert.ToDouble(reg.Match(PE.Single().InnerText == "-" ? "0" : PE.Single().InnerText).Value),
        //        BVPS = Convert.ToDouble(reg.Match(BVPS.Single().InnerText).Value),
        //        PB = Convert.ToDouble(reg.Match(PB.Single().InnerText).Value),
        //        Revenue = Convert.ToDouble(reg.Match(Revenue.Single().InnerText).Value),
        //        RevenueYOY = Convert.ToDouble(reg.Match(RevenueYOY.Single().InnerText).Value),
        //        NetProfit = Convert.ToDouble(reg.Match(NetProfit.Single().InnerText).Value),
        //        NetProfitYOY = Convert.ToDouble(reg.Match(NetProfitYOY.Single().InnerText).Value),
        //        GrossMargin = Convert.ToDouble(reg.Match(GrossMargin.Single().InnerText).Value),
        //        NetMargin = Convert.ToDouble(reg.Match(NetMargin.Single().InnerText).Value),
        //        ROE = Convert.ToDouble(reg.Match(ROE.Single().InnerText).Value),
        //        DebtRatio = Convert.ToDouble(reg.Match(DebtRatio.Single().InnerText).Value),
        //        Equity = Convert.ToDouble(reg.Match(Equity.Single().InnerText).Value),
        //        Value = Convert.ToDouble(reg.Match(Value.Single().InnerText).Value),
        //        UDPPS = Convert.ToDouble(reg.Match(UDPPS.Single().InnerText).Value)
        //    };
        //    string insert = $"INSERT INTO STOCK_ECNO_DATA VALUES{$"('{data.Code}','{data.Income}','{data.PE}','{data.BVPS}','{data.PB}','{data.Revenue}','{data.RevenueYOY}','{data.NetProfit}','{data.NetProfitYOY}','{data.GrossMargin}','{data.NetMargin}','{data.ROE}','{data.DebtRatio}','{data.Equity}','{data.Value}','{data.UDPPS}')"}";
        //    string update = $"UPDATE STOCK_ECNO_DATA SET INCOME = '{data.Income}', PE = '{data.PE}' , BVPS ='{data.BVPS}' , PB ='{data.PB}' , REVENUE ='{data.Revenue}', REVENUEYOY = '{data.RevenueYOY}' , NETPROFIT ='{data.NetProfit}', NETPROFITYOY = '{data.NetProfitYOY}' , GROSSMARGIN = '{data.GrossMargin}' , NETMARGIN = '{data.NetMargin}' , ROE = '{data.ROE}' , DEBTRATION ='{data.DebtRatio}' , EQUITY = '{data.Equity}', Value = '{data.Equity}', UDPPS = '{data.UDPPS}'  WHERE CODE = '{data.Code}'";

        //    int result = QuantTradeDLL.DBUtility.OracleClient.ExecuteSQL(update);

            


        //    Console.WriteLine(result + stock );
        //}

    }
}
