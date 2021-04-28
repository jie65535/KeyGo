using System;
using System.Windows.Forms;

namespace KeyGo
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var p = AppControl.GetCurrentRunningInstance();
            if (p != null)
            {
                AppControl.ShowWindow(p);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}