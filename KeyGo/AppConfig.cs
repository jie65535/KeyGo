using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KeyGo
{
    /// <summary>
    /// 应用配置帮助类
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether [power boot].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [power boot]; otherwise, <c>false</c>.
        /// </value>
        public bool PowerBoot { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [close to hide].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [close to hide]; otherwise, <c>false</c>.
        /// </value>
        public bool CloseToHide { get; set; } = true;


        /// <summary>
        /// Loads the XML.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static AppConfig LoadXml(string filePath)
        {
            AppConfig data = null;
            if (File.Exists(filePath))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(AppConfig));
                using (var stream = File.OpenRead(filePath))
                {
                    if (stream.Length > 0)
                    {
                        data = formatter.Deserialize(stream) as AppConfig;
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

            XmlSerializer formatter = new XmlSerializer(typeof(AppConfig));
            using (var stream = File.Create(filePath))
            {
                formatter.Serialize(stream, this);
            }
        }
    }
}
