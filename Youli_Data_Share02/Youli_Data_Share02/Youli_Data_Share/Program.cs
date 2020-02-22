using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//窗口参数记录：窗口大小：930 550
namespace Youli_Data_Share
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
            Application.Run(new Form1());
        }
    }
}
