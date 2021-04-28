using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KeyGo
{
    public class KeyGo
    {
        static int _RegMaxID;

        [XmlIgnore]
        public IntPtr FormHandle { get; set; }

        public List<HotKeyItem> Items { get; set; } = new List<HotKeyItem>();

        #region FILE IO

        /// <summary>
        /// Loads the XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static KeyGo LoadXml(string filePath)
        {
            KeyGo data = null;
            if (File.Exists(filePath))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(KeyGo));
                using (var stream = File.OpenRead(filePath))
                {
                    if (stream.Length > 0)
                    {
                        data = formatter.Deserialize(stream) as KeyGo;
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// Saves the XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SaveXml(string filePath)
        {
            if (!File.Exists(filePath))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            XmlSerializer formatter = new XmlSerializer(typeof(KeyGo));
            using (var stream = File.Create(filePath))
            {
                formatter.Serialize(stream, this);
            }
        }

        #endregion


        /// <summary>
        /// Processes the hotkey.
        /// </summary>
        /// <param name="hotKey_id">The hot key identifier.</param>
        public void ProcessHotkey(int hotKey_id)
        {
            var hotkey = Items.Find(k => k.HotKeyID == hotKey_id);
            if (hotkey != null)
            {
                ++hotkey.TriggerCounter;
                MessageBox.Show($"ID:{hotkey.HotKeyID}\nKeys:{hotkey.HotKey}\nProcessName:{hotkey.ProcessName}\nStartupPath:{hotkey.StartupPath}", "HotKey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        #region HotKey Register

        /// <summary>
        /// Regs all key.
        /// </summary>
        public void RegAllKey()
        {
            foreach (var item in Items)
            {
                if (!item.Enabled)
                    continue;

                try
                {
                    RegKey(item);
                }
                catch (Exception)
                {
                    // 忽视异常，外部通过ID是否被设置判断执行结果
                }
            }
        }

        /// <summary>
        /// Uns the reg all key.
        /// </summary>
        public void UnRegAllKey()
        {
            foreach (var item in Items)
            {
                try
                {
                    UnRegKey(item);
                }
                catch (Exception)
                {
                    // 忽视异常，外部通过ID是否被设置判断执行结果
                }
            }
        }

        /// <summary>
        /// 注册热键 - 成功后，会设置 HotKeyID
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">
        /// item
        /// or
        /// HotKey - 热键不能为空！
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// 功能键不能为空！
        /// or
        /// 快捷键不能为空！
        /// </exception>
        public void RegKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.HotKey))
                throw new ArgumentNullException(nameof(item.HotKey), "热键不能为空！");

            // 如果注册过该热键，ID不为0。卸载热键会将ID置零。
            if (item.HotKeyID != 0)
                return;

            int id = Interlocked.Increment(ref _RegMaxID);

            var keys = item.HotKey.Split('+');
            Keys keyCode = Keys.None;
            AppHotKey.KeyModifiers keyModifiers = AppHotKey.KeyModifiers.None;
            foreach (var key in keys)
            {
                switch (key.ToLower())
                {
                case "ctrl":
                    keyModifiers |= AppHotKey.KeyModifiers.Ctrl;
                    break;
                case "shift":
                    keyModifiers |= AppHotKey.KeyModifiers.Shift;
                    break;
                case "alt":
                    keyModifiers |= AppHotKey.KeyModifiers.Alt;
                    break;
                case "win":
                    keyModifiers |= AppHotKey.KeyModifiers.WindowsKey;
                    break;
                default:
                    keyCode = (Keys)Enum.Parse(typeof(Keys), key);
                    break;
                }
            }

            if (keyModifiers == AppHotKey.KeyModifiers.None)
                throw new InvalidOperationException("功能键不能为空！");
            if (keyCode == Keys.None)
                throw new InvalidOperationException("快捷键不能为空！");

            AppHotKey.RegKey(FormHandle, id, keyModifiers, keyCode);
            item.HotKeyID = id;
        }

        /// <summary>
        /// 注销热键 - 完成后，会清零 HotKeyID
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">item</exception>
        public void UnRegKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (item.HotKeyID == 0)
                return;

            AppHotKey.UnRegKey(FormHandle, item.HotKeyID);
            item.HotKeyID = 0;
        }

        #endregion
    }
}