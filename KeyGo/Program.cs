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
                if (p.MainWindowHandle == IntPtr.Zero)
                    MessageBox.Show("应用已启动，无需重复运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
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