using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KeyGo
{
    public partial class FormMain : Form
    {
        private static readonly string _DataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyGo", "HotKey.xml");
        private readonly KeyGo _KeyGo;

        public FormMain()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName thisAssemName = assembly.GetName();
            Text += $" - {thisAssemName.Version}";

            _KeyGo = LoadHotKeyItems(_DataFilePath);
            _KeyGo.FormHandle = Handle;
            var p = Process.GetCurrentProcess();
            if (_KeyGo.Items.Count == 0)
            {
                _KeyGo.Items.Add(new HotKeyItem
                {
                    ProcessName = p.ProcessName,
                    StartupPath = p.MainModule.FileName,
                    HotKey = "Ctrl+G",
                });
            }
            _KeyGo.RegAllKey();

            FLPHotKeys.SuspendLayout();
            foreach (var item in _KeyGo.Items)
                FLP_AddItem(item);
            FLPHotKeys.ResumeLayout();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine(_DataFilePath);
        }

        bool isExit;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExit)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _KeyGo.UnRegAllKey();
            SaveHotKeyItems(_KeyGo);
        }

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

        private void BtnTest_Click(object sender, EventArgs e)
        {
            //_KeyGo.Items.Add(new HotKeyItem
            //{
            //    ProcessName = "QQ",
            //    StartupPath = "",
            //    HotKey = "Ctrl+Q",
            //    Enabled = true,
            //    TriggerCounter = 0,
            //    CreationTime = DateTime.Now,
            //    LastModifiedTime = DateTime.Now,
            //});
            //SaveHotKeyItems(_KeyGo);
            //new FormHotKey().ShowDialog();
        }

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

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // 鼠标左键点击托盘图标才触发
            if (e.Button != MouseButtons.Left)
                return;

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

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            // 如果最小化，则隐藏窗体
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            isExit = true;
            Close();
        }

        private void TSMIPowerOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("暂未完成", "TODO");
        }

        private void TSMICloseToMin_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("暂未完成", "TODO");
        }
    }
}