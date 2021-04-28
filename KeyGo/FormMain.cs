using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KeyGo
{
    public partial class FormMain : Form
    {
        static readonly string _DataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyGo", "HotKey.xml");
        readonly KeyGo _KeyGo;
        
        public FormMain()
        {
            InitializeComponent();
            _KeyGo = LoadHotKeyItems(_DataFilePath);
            _KeyGo.FormHandle = Handle;
            _KeyGo.RegAllKey();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        #region 数据文件IO

        private KeyGo LoadHotKeyItems(string xmlFilePath)
        {
            try
            {
                return KeyGo.LoadXml(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入数据文件异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new KeyGo();
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

        #endregion

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _KeyGo.UnRegAllKey();
        }













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
        #endregion


        private void button1_Click(object sender, EventArgs e)
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
    }
}