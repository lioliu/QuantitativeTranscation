using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.JsonFormater
{
    public class SuggestList
    {
        public static string Formater(string str)
        {
            string result;
            //result = "{\"StockSuggest\":[" + 
            result = str.Replace(";return _t;}", "").Replace("_t.push(","").Replace("function get_data(){\nvar _t = new Array(); ","").Replace(");",",").Replace("val:", "\"code\":").Replace("val2:","\"name\":").Replace("val3:","\"py\":").Replace(")","]}");

            result = "{\"suggest\":[" + result.Substring(result.IndexOf(',') + 2).Replace(",\nreturn _t;", "]");   //puls 2 to skip ',' and '\n'

            return result;
        }
    }
}
