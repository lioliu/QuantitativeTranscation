using QuantTradeDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL
{

    public class StockHisData
    {
        public string Code { set; get; }
        public string Total { set; get; }
        public string Begin { set; get; }
        public string End { set; get; }
        public Kline[] Kline { set; get; }
    }

    /*
    private static string GetHisData(string code)
    {
        Random rnd = new Random();
        BaseCrawler crawl = new BaseCrawler();
        string json = crawl.Run($"http://yunhq.sse.com.cn:32041/v1/sh1/dayk/{code}?callback=&select=date%2Copen%2Chigh%2Clow%2Cclose%2Cvolume&begin=0&end=-1");
        json = Json_formater.FormatHisData(json);
        His_data his_data = JsonConvert.DeserializeObject<His_data>(json);
        return his_data.Total;
    }
    */

}
