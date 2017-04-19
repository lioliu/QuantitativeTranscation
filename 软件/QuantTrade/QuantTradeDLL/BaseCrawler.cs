using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL
{
    public class BaseCrawler
    {
        HttpHelper http;
        HttpItem item;
        public BaseCrawler()
        {
            http = new HttpHelper();
            item = new HttpItem()
            {
                URL = "http://yunhq.sse.com.cn:32041/v1/sh1/list/self/000001?select=code%2Cname%2Clast%2Cchg_rate%2Camount%2Copen%2Cprev_close",

                Encoding = null,

                Method = "get",//Get
                Timeout = 100000,
                ReadWriteTimeout = 30000,
                IsToLower = false,
                Cookie = "",
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//
                Accept = "text/html, application/xhtml+xml, */*",//    
                ContentType = "text/html",//
                Allowautoredirect = true,//
                Connectionlimit = 2048,//
                PostDataType = PostDataType.FilePath,//
                ResultType = ResultType.String,//
                CookieCollection = new System.Net.CookieCollection(),//
            };
        }
        /// <summary>
        /// run the default url  just using for test
        /// </summary>
        public string Run()
        {
            HttpResult result = http.GetHtml(item);

            string cookie = result.Cookie;

            string html = result.Html;
            Console.WriteLine(html);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {

            }

            string statusCodeDescription = result.StatusDescription;

            return html;

        }
        /// <summary>
        ///  run the crawler to get the html text from the URL givened
        /// </summary>
        /// <param name="URL">the URL wanted to crawl</param>
        /// <returns>the URL's html text</returns>
        public string Run(string URL)
        {
            item.URL = URL;
            HttpResult result = http.GetHtml(item);

            string cookie = result.Cookie;

            string html = result.Html;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {

            }

            string statusCodeDescription = result.StatusDescription;

            return html;
        }
    }

}
