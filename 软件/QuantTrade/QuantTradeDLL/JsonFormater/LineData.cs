using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL.JsonFormater
{
    public class LineData
    {
        public static string JsonFormater(string str)
        {
            str = str.Remove(0, str.IndexOf("(") + 1).Replace(")", "");
            //change '[' / ']' to '{'/'}' except the first and the last one
            str = str.Insert(str.IndexOf("["), "(");
            str = str.Insert(str.LastIndexOf("]") + 1, ")").Replace("[", "{").Replace("]", "}").Replace("({", "[").Replace("})", "]").Replace("\"", "").Replace(",", "\",\"").Replace(":", "\":\"").Insert(1, "\"").Replace("\"[", "[").Replace("}", "\"}").Replace("}\",\"{", "},{").Replace("]\"}", "]}");
            int state = -1;
            for (int i = 5; i < str.Length; i++)
            {

                if (str[i] == '{')
                {
                    str = str.Insert(i + 1, "\"time\":\"");
                    state = 0;
                }
                else if (str[i] == ',')
                {
                    switch (state)
                    {
                        case 0:
                            str = str.Insert(i + 1, "\"price\":");
                            state++;
                            break;
                        case 1:
                            str = str.Insert(i + 1, "\"volume\":");
                            state = 0;
                            break;
                        default:
                            break;
                    }
                }
                else if (str[i] == '}') state = -1;
            }
            return str;
        }
    }
}
