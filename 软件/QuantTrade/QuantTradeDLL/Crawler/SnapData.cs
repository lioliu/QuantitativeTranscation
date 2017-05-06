
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace QuantTradeDLL.Crawler
{

    public class SnapData
    {
        private const string appkey = "4fc4a73a69648b1adc711638c813bfe6";//given by the websites
        private const string url = "http://web.juhe.cn:8080/finance/stock/hs"; //the  request url

        public static string Url => url;
        public static string Appkey => appkey;
        public string Resultcode { set; get; }
        public string Reason { set; get; }
        public string Error_code { set; get; }

        public Result[] Result { set; get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static SnapData GetSnap(string code)
        {
            var parameters1 = new Dictionary<string, string>();
            string query_code = "sh" + code;
            
            parameters1.Add("gid", query_code);
            parameters1.Add("key", appkey);//

            string result1 = SnapData.SendPost(Url, parameters1, "get");
            
            SnapData snap_data = JsonConvert.DeserializeObject<SnapData>(result1);
            Console.WriteLine($"{code}");
            return snap_data;
            
        }

        public static bool SaveToDB(SnapData data)
        {
            //remove first
            DBUtility.OleDb.ExecuteSQL($"delete from STOCK_SNAP_DATA where code = '{data.Result[0].Data.Gid.Substring(2)}'");

            // make the date
            string date = data.Result[0].Data.Date + " " + data.Result[0].Data.Time;



            //insert to Data Base
            DBUtility.OleDb.ExecuteSQL($"insert into STOCK_SNAP_DATA VALUES ('{data.Result[0].Data.Gid.Substring(2)}','{Convert.ToDouble(data.Result[0].Data.BuyFive)}','{Convert.ToDouble(data.Result[0].Data.BuyFivePri)}','{Convert.ToDouble(data.Result[0].Data.BuyFour)}','{Convert.ToDouble(data.Result[0].Data.BuyFourPri)}','{Convert.ToDouble(data.Result[0].Data.BuyThree)}','{Convert.ToDouble(data.Result[0].Data.BuyThreePri)}','{Convert.ToDouble(data.Result[0].Data.BuyTwo)}','{Convert.ToDouble(data.Result[0].Data.BuyTwoPri)}','{Convert.ToDouble(data.Result[0].Data.BuyOne)}','{Convert.ToDouble(data.Result[0].Data.BuyOnePri)}','{Convert.ToDouble(data.Result[0].Data.CompetitivePri)}',to_date('{date}','YYYY-MM-DD HH24:MI:SS'),'{Convert.ToDouble(data.Result[0].Data.IncrePer)}','{Convert.ToDouble(data.Result[0].Data.Increase)}','{data.Result[0].Data.Name}','{Convert.ToDouble(data.Result[0].Data.NowPri)}','{Convert.ToDouble(data.Result[0].Data.ReservePri)}','{Convert.ToDouble(data.Result[0].Data.SellFive)}','{Convert.ToDouble(data.Result[0].Data.SellFour)}','{Convert.ToDouble(data.Result[0].Data.SellThree)}','{Convert.ToDouble(data.Result[0].Data.SellTwo)}','{Convert.ToDouble(data.Result[0].Data.SellOne)}','{Convert.ToDouble(data.Result[0].Data.SellFivePri)}','{Convert.ToDouble(data.Result[0].Data.SellFourPri)}','{Convert.ToDouble(data.Result[0].Data.SellThreePri)}','{Convert.ToDouble(data.Result[0].Data.SellTwoPri)}','{Convert.ToDouble(data.Result[0].Data.SellOnePri)}','{Convert.ToDouble(data.Result[0].Data.TodayMax)}','{Convert.ToDouble(data.Result[0].Data.TodayMin)}','{Convert.ToDouble(data.Result[0].Data.TodayStartPri)}','{Convert.ToDouble(data.Result[0].Data.TraAmount)}','{Convert.ToDouble(data.Result[0].Data.TraNumber)}','{Convert.ToDouble(data.Result[0].Data.YestodEndPri)}')");
            return true;
        }




        private static string SendPost(string url, IDictionary<string, string> parameters, string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 1000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            else
            {
                //创建请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

                //GET请求
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

                //返回内容
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }



        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }





        static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                //Skip empty value
                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");

                    postData.Append(value);

                    hasParam = true;
                }
            }
            return postData.ToString();
        }
    }
}