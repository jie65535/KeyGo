using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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
            // 关闭后不用保存，修改时保存即可
            //SaveHotKeyItems(_KeyGo);
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
                AddHotKeyItem(frm.HotKeyItem);
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

        private void AddHotKeyItem(HotKeyItem item, bool save = true)
        {
            try
            {
                _KeyGo.AddHotKey(item);
            }
            catch (Exception ex)
            {
                if (item.Enabled)
                {
                    // 禁用后再添加
                    item.Enabled = false;
                    _KeyGo.AddHotKey(item);
                }
                else
                {
                    MessageBox.Show("在添加新的热键时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            FLP_AddItem(item);
            if (save) SaveHotKeyItems(_KeyGo);
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
                AppAutoStart.SetMeAutoStart(enable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置开机自启时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 开机自启动

        #region 拖拽

        private void FLPHotKeys_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FLPHotKeys_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is Array files && files.Length > 0)
            {
                var filepath = files.GetValue(0) as string;
                var frm = new FormHotKey
                {
                    HotKeyItem = new HotKeyItem
                    {
                        StartupPath = filepath,
                    }
                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AddHotKeyItem(frm.HotKeyItem);
                }
            }
        }

        #endregion 拖拽

        #region 配置文件管理

        private string ConfigToString(List<HotKeyItem> items)
        {
            return string.Join(Environment.NewLine, items.Select(item => $"{item.HotKey}|{item.ProcessName}|{item.StartupPath}"));
        }

        private List<HotKeyItem> ParseConfig(string config)
        {
            if (string.IsNullOrWhiteSpace(config))
                throw new ArgumentNullException(nameof(config));

            return config.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(s =>
                         {
                             var strs = s.Split('|');
                             if (strs.Length < 3)
                                 throw new Exception("数据格式不正确，无法解析");
                             return new HotKeyItem
                             {
                                 HotKey = strs[0],
                                 ProcessName = strs[1],
                                 StartupPath = strs[2],
                             };
                         }).ToList();
        }

        private void ImportConfig(string config)
        {
            if (string.IsNullOrWhiteSpace(config))
            {
                MessageBox.Show("导入失败，数据为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var items = ParseConfig(config);
                foreach (var item in items)
                    AddHotKeyItem(item, false);
                SaveHotKeyItems(_KeyGo);
                MessageBox.Show("导入完成", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TSMIExportConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog
            {
                Title = "请选择文件保存位置",
                Filter = "Config file (*.config)|*.config|All file (*.*)|*.*",
                FileName = "KeyGo_Hotkey.config",
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(frm.OpenFile()))
                {
                    writer.Write(ConfigToString(_KeyGo.Items));
                }
                if (MessageBox.Show("写入完成，是否打开目录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start("Explorer", "/select,"+ frm.FileName);
            }
        }

        private void TSMIImportConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog
            {
                Title = "请选择配置文件",
                Filter = "Config file (*.config)|*.config|All file (*.*)|*.*",
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string data;
                using (StreamReader reader = new StreamReader(frm.OpenFile()))
                {
                    data = reader.ReadToEnd();
                }
                ImportConfig(data);
            }
        }

        private void TSMICopyConfig_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(ConfigToString(_KeyGo.Items), true);
        }

        private void TSMIPasteConfig_Click(object sender, EventArgs e)
        {
            ImportConfig(Clipboard.GetText());
        }

        #endregion
    }
}