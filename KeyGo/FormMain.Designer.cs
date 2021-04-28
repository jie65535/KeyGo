
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
            this.TSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPowerOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMICloseToMin = new System.Windows.Forms.ToolStripMenuItem();
            this.FLPHotKeys.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLPHotKeys
            // 
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
            this.TSMICloseToMin,
            this.TSMIPowerOnStartup,
            this.TSMIExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // TSMIExit
            // 
            this.TSMIExit.Name = "TSMIExit";
            this.TSMIExit.Size = new System.Drawing.Size(180, 22);
            this.TSMIExit.Text = "退出";
            this.TSMIExit.Click += new System.EventHandler(this.TSMIExit_Click);
            // 
            // TSMIPowerOnStartup
            // 
            this.TSMIPowerOnStartup.CheckOnClick = true;
            this.TSMIPowerOnStartup.Name = "TSMIPowerOnStartup";
            this.TSMIPowerOnStartup.Size = new System.Drawing.Size(180, 22);
            this.TSMIPowerOnStartup.Text = "开机自启动";
            this.TSMIPowerOnStartup.CheckedChanged += new System.EventHandler(this.TSMIPowerOnStartup_CheckedChanged);
            // 
            // TSMICloseToMin
            // 
            this.TSMICloseToMin.CheckOnClick = true;
            this.TSMICloseToMin.Name = "TSMICloseToMin";
            this.TSMICloseToMin.Size = new System.Drawing.Size(180, 22);
            this.TSMICloseToMin.Text = "关闭为最小化";
            this.TSMICloseToMin.CheckedChanged += new System.EventHandler(this.TSMICloseToMin_CheckedChanged);
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
        private System.Windows.Forms.ToolStripMenuItem TSMIPowerOnStartup;
        private System.Windows.Forms.ToolStripMenuItem TSMICloseToMin;
    }
}

