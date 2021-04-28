using System;
using System.Windows.Forms;

namespace KeyGo
{
    public partial class FormHotKey : Form
    {
        public FormHotKey()
        {
            InitializeComponent();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
                TxtStartupPath.Text = p.MainModule.FileName;
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