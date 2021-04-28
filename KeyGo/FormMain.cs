using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyGo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        void ProcessHotkey(int hotKey_id)
        {
            //if (hotKey_id == 100)
            //    MessageBox.Show("Test");
        }





        private void TxtHotKey1_KeyDown(object sender, KeyEventArgs e)
        {
            TxtHotKey1.Text = e.Modifiers.ToString();
            Console.WriteLine($"down\t{e.KeyData}");
        }










        private void FormMain_Load(object sender, EventArgs e)
        {
            //AppHotKey.RegKey(Handle, 100, AppHotKey.KeyModifiers.Ctrl, Keys.W);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AppHotKey.UnRegKey(Handle, 100);
        }



        #region 窗体消息 热键回调
        private const int WM_HOTKEY = 0x312;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
            case WM_HOTKEY:
                ProcessHotkey(m.WParam.ToInt32());
                break;
            }
        }
        #endregion
    }
}