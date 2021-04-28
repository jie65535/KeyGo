using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace KeyGo
{
    public partial class FormProcessSelector : Form
    {
        public FormProcessSelector()
        {
            InitializeComponent();
        }

        public Process SelectedItem { get; private set; }

        private void FormProcessSelector_Load(object sender, EventArgs e)
        {
            LoadProcessesInfo();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcessesInfo();
        }

        private class VOProcess
        {
            public string Text { get; set; }
            public Process Process { get; set; }
        }

        private void LoadProcessesInfo()
        {
            var processes = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero);
            CmbProcesses.BeginUpdate();
            CmbProcesses.DataSource = processes.Select(p => new VOProcess { Text = $"{p.ProcessName} | {p.MainWindowTitle}", Process = p }).ToList();
            CmbProcesses.DisplayMember = "Text";
            CmbProcesses.EndUpdate();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (CmbProcesses.SelectedItem is VOProcess p)
            {
                SelectedItem = p.Process;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("未选择进程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}