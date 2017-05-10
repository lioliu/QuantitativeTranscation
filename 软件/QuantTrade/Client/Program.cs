using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new StockDetail("600000",new string[2] { "600000","600004"} ));



            Application.Run(new Main());
            //Application.Run(new WarningAdd());
            //Application.Run(new  Setting());
        }
    }
}
