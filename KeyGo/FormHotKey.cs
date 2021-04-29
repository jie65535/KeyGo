using System;
using System.IO;
using System.Windows.Forms;

namespace KeyGo
{
    public partial class FormHotKey : Form
    {
        public FormHotKey()
        {
            InitializeComponent();
        }

        public HotKeyItem HotKeyItem { get; set; }

        private void FormHotKey_Load(object sender, EventArgs e)
        {
            if (HotKeyItem != null)
            {
                TxtProcessName.Text = HotKeyItem.ProcessName;
                TxtStartupPath.Text = HotKeyItem.StartupPath;
                TxtHotKey.Text      = HotKeyItem.HotKey;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtProcessName.Text))
            {
                MessageBox.Show("请设置进程名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(TxtStartupPath.Text) && !File.Exists(TxtStartupPath.Text))
            {
                MessageBox.Show("请选择有效的启动路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(TxtHotKey.Text))
            {
                MessageBox.Show("请设置快捷键", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Modified = true;

            if (HotKeyItem == null)
                HotKeyItem = new HotKeyItem();
            else
                Modified = !(HotKeyItem.ProcessName == TxtProcessName.Text && HotKeyItem.StartupPath == TxtStartupPath.Text && HotKeyItem.HotKey == TxtHotKey.Text);

            if (Modified)
            {
                HotKeyItem.ProcessName = TxtProcessName.Text.Trim();
                HotKeyItem.StartupPath = TxtStartupPath.Text.Trim();
                HotKeyItem.HotKey = TxtHotKey.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void TxtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None)
                return;
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                return;

            string text = e.KeyCode.ToString();
            if (e.Shift)
                text = "Shift+" + text;
            if (e.Alt)
                text = "Alt+" + text;
            if (e.Control)
                text = "Ctrl+" + text;

            TxtHotKey.Text = text;
        }

        private void BtnSelectProcess_Click(object sender, EventArgs e)
        {
            var frm = new FormProcessSelector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var p = frm.SelectedItem;
                TxtProcessName.Text = p.ProcessName;
                try
                {
                    TxtStartupPath.Text = p.MainModule.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法获取进程的启动路径：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnSelectStartupPath_Click(object sender, EventArgs e)
        {
            var frm = new OpenFileDialog()
            {
                Title = "请选择启动应用",
                Filter = "Exe file (*.exe)|*.exe|All file (*.*)|*.*",
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TxtStartupPath.Text = frm.FileName;
            }
        }
    }
}