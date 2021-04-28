using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace KeyGo
{
    public class AppControl
    {
        /// <summary>
        /// 获取本应用程序当前正在运行的进程，若不存在则返回null
        /// </summary>
        /// <returns>当前正在运行的进程</returns>
        private static Process GetCurrentRunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace('/', '\\') == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 显示指定实例窗体
        /// </summary>
        /// <param name="instance">The instance.</param>
        private static void ShowWindow(Process instance)
        {
            if (instance != null && instance.MainWindowHandle != IntPtr.Zero)
                ShowWindowAsync(instance.MainWindowHandle, (int)CmdShow.Show);
            //SetForegroundWindow(instance.MainWindowHandle);
        }

        /// <summary>
        /// 隐藏指定实例窗体
        /// </summary>
        /// <param name="instance">The instance.</param>
        public static void HideWindow(Process instance)
        {
            if (instance != null && instance.MainWindowHandle != IntPtr.Zero)
                ShowWindowAsync(instance.MainWindowHandle, (int)CmdShow.Hide);
        }

        private enum CmdShow : int
        {
            /// <summary>
            /// Minimizes a window, even if the thread that owns the window is not responding.
            /// This flag should only be used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimize = 11,

            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            Hide = 0,

            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            Maximize = 3,

            /// <summary>
            /// Minimizes the specified window and activates the next top-level window in the Z order.
            /// </summary>
            Minimize = 6,

            /// <summary>
            /// Activates and displays the window.
            /// If the window is minimized or maximized,
            /// the system restores it to its original size and position.
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,

            /// <summary>
            /// Activates the window and displays it in its current size and position.
            /// </summary>
            Show = 5,

            /// <summary>
            /// Sets the show state based on the SW_ value specified in the STARTUPINFO
            /// structure passed to the CreateProcess function by the program that started
            /// the application.
            /// </summary>
            ShowDefault = 10,

            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>
            ShowMaximized = 3,

            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,

            /// <summary>
            /// Displays the window as a minimized window.
            /// This value is similar to SW_SHOWMINIMIZED,
            /// except the window is not activated.
            /// </summary>
            ShowMinnoActive = 7,

            /// <summary>
            /// Displays the window in its current size and position.
            /// This value is similar to SW_SHOW, except that the window is not activated.
            /// </summary>
            ShowNA = 8,

            /// <summary>
            /// Displays a window in its most recent size and position.
            /// This value is similar to SW_SHOWNORMAL, except that the window is not activated.
            /// </summary>
            ShowNoactivate = 4,

            /// <summary>
            /// Activates and displays a window.
            /// If the window is minimized or maximized,
            /// the system restores it to its original size and position.
            /// An application should specify this flag when displaying the window for the first time.
            /// </summary>
            ShowNormal= 1,
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
    }
}