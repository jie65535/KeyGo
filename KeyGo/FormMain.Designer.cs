
namespace KeyGo
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.FLPHotKeys = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMICloseToHide = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPowerBoot = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIConfigFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIExportConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIImportConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMICopyConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPasteConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.FLPHotKeys.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLPHotKeys
            // 
            this.FLPHotKeys.AllowDrop = true;
            this.FLPHotKeys.AutoScroll = true;
            this.FLPHotKeys.BackColor = System.Drawing.Color.White;
            this.FLPHotKeys.Controls.Add(this.BtnAdd);
            this.FLPHotKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPHotKeys.Location = new System.Drawing.Point(0, 0);
            this.FLPHotKeys.Margin = new System.Windows.Forms.Padding(0);
            this.FLPHotKeys.Name = "FLPHotKeys";
            this.FLPHotKeys.Padding = new System.Windows.Forms.Padding(3);
            this.FLPHotKeys.Size = new System.Drawing.Size(488, 197);
            this.FLPHotKeys.TabIndex = 0;
            this.FLPHotKeys.DragDrop += new System.Windows.Forms.DragEventHandler(this.FLPHotKeys_DragDrop);
            this.FLPHotKeys.DragEnter += new System.Windows.Forms.DragEventHandler(this.FLPHotKeys_DragEnter);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Image = global::KeyGo.Properties.Resources.ImgAdd;
            this.BtnAdd.Location = new System.Drawing.Point(6, 6);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(110, 90);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIConfigFile,
            this.TSMICloseToHide,
            this.TSMIPowerBoot,
            this.TSMIExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // TSMICloseToHide
            // 
            this.TSMICloseToHide.CheckOnClick = true;
            this.TSMICloseToHide.Name = "TSMICloseToHide";
            this.TSMICloseToHide.Size = new System.Drawing.Size(180, 22);
            this.TSMICloseToHide.Text = "关闭为最小化";
            this.TSMICloseToHide.CheckedChanged += new System.EventHandler(this.TSMICloseToHide_CheckedChanged);
            // 
            // TSMIPowerBoot
            // 
            this.TSMIPowerBoot.CheckOnClick = true;
            this.TSMIPowerBoot.Name = "TSMIPowerBoot";
            this.TSMIPowerBoot.Size = new System.Drawing.Size(180, 22);
            this.TSMIPowerBoot.Text = "开机自启动";
            this.TSMIPowerBoot.CheckedChanged += new System.EventHandler(this.TSMIPowerBoot_CheckedChanged);
            // 
            // TSMIExit
            // 
            this.TSMIExit.Name = "TSMIExit";
            this.TSMIExit.Size = new System.Drawing.Size(180, 22);
            this.TSMIExit.Text = "退出";
            this.TSMIExit.Click += new System.EventHandler(this.TSMIExit_Click);
            // 
            // TSMIConfigFile
            // 
            this.TSMIConfigFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIExportConfig,
            this.TSMIImportConfig,
            this.TSMICopyConfig,
            this.TSMIPasteConfig});
            this.TSMIConfigFile.Name = "TSMIConfigFile";
            this.TSMIConfigFile.Size = new System.Drawing.Size(180, 22);
            this.TSMIConfigFile.Text = "配置文件";
            // 
            // TSMIExportConfig
            // 
            this.TSMIExportConfig.Name = "TSMIExportConfig";
            this.TSMIExportConfig.Size = new System.Drawing.Size(180, 22);
            this.TSMIExportConfig.Text = "导出文件";
            this.TSMIExportConfig.Click += new System.EventHandler(this.TSMIExportConfig_Click);
            // 
            // TSMIImportConfig
            // 
            this.TSMIImportConfig.Name = "TSMIImportConfig";
            this.TSMIImportConfig.Size = new System.Drawing.Size(180, 22);
            this.TSMIImportConfig.Text = "导入文件";
            this.TSMIImportConfig.Click += new System.EventHandler(this.TSMIImportConfig_Click);
            // 
            // TSMICopyConfig
            // 
            this.TSMICopyConfig.Name = "TSMICopyConfig";
            this.TSMICopyConfig.Size = new System.Drawing.Size(180, 22);
            this.TSMICopyConfig.Text = "复制到剪切板";
            this.TSMICopyConfig.Click += new System.EventHandler(this.TSMICopyConfig_Click);
            // 
            // TSMIPasteConfig
            // 
            this.TSMIPasteConfig.Name = "TSMIPasteConfig";
            this.TSMIPasteConfig.Size = new System.Drawing.Size(180, 22);
            this.TSMIPasteConfig.Text = "从剪切板读入";
            this.TSMIPasteConfig.Click += new System.EventHandler(this.TSMIPasteConfig_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 197);
            this.Controls.Add(this.FLPHotKeys);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyGo!";
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FLPHotKeys.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLPHotKeys;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIExit;
        private System.Windows.Forms.ToolStripMenuItem TSMIPowerBoot;
        private System.Windows.Forms.ToolStripMenuItem TSMICloseToHide;
        private System.Windows.Forms.ToolStripMenuItem TSMIConfigFile;
        private System.Windows.Forms.ToolStripMenuItem TSMIExportConfig;
        private System.Windows.Forms.ToolStripMenuItem TSMIImportConfig;
        private System.Windows.Forms.ToolStripMenuItem TSMICopyConfig;
        private System.Windows.Forms.ToolStripMenuItem TSMIPasteConfig;
    }
}

