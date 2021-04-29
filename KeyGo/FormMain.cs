using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Microsoft.Win32;

namespace KeyGo
{
    public partial class FormMain : Form
    {
        #region 成员

        private static readonly string _DataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyGo");
        private static readonly string _DataFilePath = Path.Combine(_DataFolderPath, "HotKey.xml");
        private static readonly string _AppConfigFilePath = Path.Combine(_DataFolderPath, "AppConfig.xml");
        private readonly KeyGo _KeyGo;
        private readonly AppConfig _AppConfig;
        private readonly string _CurrentProcessName;
        private bool _Initializing;

        #endregion 成员

        #region 构造

        public FormMain()
        {
            InitializeComponent();
            _Initializing = true;

            // 读取程序集版本，显示到标题栏
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName thisAssemName = assembly.GetName();
            Text += $" - {thisAssemName.Version} - github.com/jie65535/KeyGo";

            // 载入并初始化配置
            _AppConfig = LoadAppConfig(_AppConfigFilePath);
            TSMICloseToHide.Checked = _AppConfig.CloseToHide;
            TSMIPowerBoot.Checked = _AppConfig.PowerBoot;
            SetPowerBoot(_AppConfig.PowerBoot);

            // 载入热键数据
            _KeyGo = LoadHotKeyItems(_DataFilePath);
            _KeyGo.HotKeyTriggerEvent += KeyGo_HotKeyTriggerEvent;
            _KeyGo.FormHandle = Handle;
            var p = Process.GetCurrentProcess();
            _CurrentProcessName = p.ProcessName;
            if (_KeyGo.Items.Count == 0)
            {
                _KeyGo.Items.Add(new HotKeyItem
                {
                    ProcessName = _CurrentProcessName,
                    StartupPath = p.MainModule.FileName,
                    HotKey = "Ctrl+G",
                });
            }
            _KeyGo.RegAllKey();

            // 初始化UI
            FLPHotKeys.SuspendLayout();
            foreach (var item in _KeyGo.Items)
                FLP_AddItem(item);
            FLPHotKeys.ResumeLayout();

            _Initializing = false;
        }

        #endregion 构造

        #region 窗体事件

        private void KeyGo_HotKeyTriggerEvent(object sender, HotKeyTriggerEventArgs e)
        {
            if (e.HotKeyItem.ProcessName == _CurrentProcessName)
            {
                ChangeVisible();
                e.Handle = true;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine(_DataFilePath);
        }

        private bool isExit;

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExit && _AppConfig.CloseToHide)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            // 如果最小化，则隐藏窗体
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _KeyGo.UnRegAllKey();
            SaveHotKeyItems(_KeyGo);
        }

        #endregion 窗体事件

        #region 数据文件IO

        private KeyGo LoadHotKeyItems(string xmlFilePath)
        {
            KeyGo instance = null;
            try
            {
                instance = KeyGo.LoadXml(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入数据文件异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return instance ?? new KeyGo();
        }

        private void SaveHotKeyItems(KeyGo data)
        {
            try
            {
                data.SaveXml(_DataFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据文件异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 数据文件IO

        #region 配置文件IO

        private AppConfig LoadAppConfig(string xmlFilePath)
        {
            AppConfig instance = null;
            try
            {
                instance = AppConfig.LoadXml(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入配置文件异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return instance ?? new AppConfig();
        }

        private void SaveAppConfig(AppConfig config)
        {
            try
            {
                config.SaveXml(_AppConfigFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存配置文件异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 配置文件IO

        #region 窗体消息 热键回调

        private const int WM_HOTKEY = 0x312;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
            case WM_HOTKEY:
                _KeyGo.ProcessHotkey(m.WParam.ToInt32());
                break;
            }
        }

        #endregion 窗体消息 热键回调

        #region 热键管理

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FormHotKey();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var item = frm.HotKeyItem;
                    _KeyGo.AddHotKey(item);
                    FLP_AddItem(item);
                    SaveHotKeyItems(_KeyGo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("在添加新的热键时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FLP_AddItem(HotKeyItem item)
        {
            var ucitem = new UCHotKeyItem
            {
                KeyGo = _KeyGo,
                HotKeyItem = item,
            };
            // 值改变则保存
            ucitem.ValueChangedEvent += (s, e) => SaveHotKeyItems(_KeyGo);

            // 添加到最后
            FLPHotKeys.Controls.Add(ucitem);

            // 与添加按钮交换位置
            var i1 = FLPHotKeys.Controls.GetChildIndex(ucitem);
            var i2 = FLPHotKeys.Controls.GetChildIndex(BtnAdd);
            FLPHotKeys.Controls.SetChildIndex(ucitem, i2);
            FLPHotKeys.Controls.SetChildIndex(BtnAdd, i1);
        }

        #endregion 热键管理

        #region 托盘图标管理

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // 鼠标左键点击托盘图标才触发
            if (e.Button != MouseButtons.Left)
                return;

            ChangeVisible();
        }

        private void ChangeVisible()
        {
            // 当前在前台则隐藏
            if (Visible)
            {
                Hide();
            }
            else
            {
                // 否则，显示窗体
                Show();

                // 如果最小化状态，则切出窗体
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    // 否则，激活窗体到最前端
                    TopMost = true;
                    TopMost = false;
                }
            }
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            isExit = true;
            Close();
        }

        private void TSMIPowerBoot_CheckedChanged(object sender, EventArgs e)
        {
            if (_Initializing)
                return;
            _AppConfig.PowerBoot = TSMIPowerBoot.Checked;
            SetPowerBoot(_AppConfig.PowerBoot);
            SaveAppConfig(_AppConfig);
        }

        private void TSMICloseToHide_CheckedChanged(object sender, EventArgs e)
        {
            if (_Initializing)
                return;
            _AppConfig.CloseToHide = TSMICloseToHide.Checked;
            SaveAppConfig(_AppConfig);
        }

        #endregion 托盘图标管理

        #region 开机自启动

        /// <summary>
        /// 设置开机自启动
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void SetPowerBoot(bool enable)
        {
            try
            {
                if (enable)
                {
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("KeyGo", Application.ExecutablePath);
                    R_run.Close();
                    R_local.Close();
                }
                else
                {
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("KeyGo", false);
                    R_run.Close();
                    R_local.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册表编辑失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}