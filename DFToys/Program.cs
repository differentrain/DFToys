using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DFToys
{

    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try { Process.EnterDebugMode(); }
            catch { }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            try { Process.LeaveDebugMode(); }
            catch { }
        }


    }
}
