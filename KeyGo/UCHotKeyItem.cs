using System;
using System.Drawing;
using System.Windows.Forms;

using KeyGo.Properties;

namespace KeyGo
{
    public partial class UCHotKeyItem : UserControl
    {
        public UCHotKeyItem()
        {
            InitializeComponent();
        }

        private HotKeyItem _HotKeyItem;

        public HotKeyItem HotKeyItem
        {
            get => _HotKeyItem;
            set => ShowHotKeyItem(_HotKeyItem = value);
        }

        public KeyGo KeyGo { get; set; }

        /// <summary>
        /// 值改变时触发
        /// </summary>
        public event EventHandler ValueChangedEvent;

        private void OnValueChanged() => ValueChangedEvent?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="item">The item.</param>
        private void ShowHotKeyItem(HotKeyItem item)
        {
            LblTitle.Text   = item.ProcessName;
            LblHotKey.Text  = item.HotKey;
            HotKeyBtnEnable = item.Enabled;
            if (item.Enabled && item.HotKeyID == 0)
                LblHotKey.ForeColor = Color.Red;
            else
                LblHotKey.ForeColor = Color.Black;
        }

        /// <summary>
        /// 热键使能按钮状态
        /// </summary>
        private bool HotKeyBtnEnable
        {
            set
            {
                if (value)
                    BtnEnable.BackgroundImage = Resources.ImgEnable;
                else
                    BtnEnable.BackgroundImage = Resources.ImgDisable;
            }
        }

        /// <summary>
        /// 切换热键使能状态
        /// </summary>
        private void BtnEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (HotKeyItem.Enabled)
                {
                    KeyGo.UnRegKey(HotKeyItem);
                    HotKeyItem.Enabled = false;
                }
                else
                {
                    KeyGo.RegKey(HotKeyItem);
                    HotKeyItem.Enabled = true;
                }
                HotKeyBtnEnable = HotKeyItem.Enabled;
                OnValueChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show("在切换热键使能时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置热键参数
        /// </summary>
        private void BtnSet_Click(object sender, EventArgs e)
        {
            string oldKey = HotKeyItem.HotKey;
            var frm = new FormHotKey()
            {
                HotKeyItem = this.HotKeyItem,
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var item = frm.HotKeyItem;
                // 如果热键发生改变，则需要重新注册
                if (oldKey != item.HotKey)
                {
                    try
                    {
                        KeyGo.ChangeHotKey(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("在重新注册热键时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ShowHotKeyItem(item);
                OnValueChanged();
            }
        }

        /// <summary>
        /// 删除热键项
        /// </summary>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定删除该热键？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    KeyGo.DelHotKey(HotKeyItem);
                    Parent?.Controls.Remove(this);
                    OnValueChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("在注销热键时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}