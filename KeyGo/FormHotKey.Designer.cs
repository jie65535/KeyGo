
namespace KeyGo
{
    partial class FormHotKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProcessName = new System.Windows.Forms.TextBox();
            this.TxtStartupPath = new System.Windows.Forms.TextBox();
            this.TxtHotKey = new System.Windows.Forms.TextBox();
            this.BtnSelectProcess = new System.Windows.Forms.Button();
            this.BtnSelectStartupPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // BtnAccept
            // 
            this.BtnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAccept.Location = new System.Drawing.Point(320, 64);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(75, 23);
            this.BtnAccept.TabIndex = 2;
            this.BtnAccept.Text = "确定";
            this.BtnAccept.UseVisualStyleBackColor = true;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(401, 64);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "进程名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "启动路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "触发热键：";
            // 
            // TxtProcessName
            // 
            this.TxtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProcessName.Location = new System.Drawing.Point(86, 6);
            this.TxtProcessName.Name = "TxtProcessName";
            this.TxtProcessName.Size = new System.Drawing.Size(168, 23);
            this.TxtProcessName.TabIndex = 7;
            this.toolTip1.SetToolTip(this.TxtProcessName, "应用将通过该名称来查找窗口");
            // 
            // TxtStartupPath
            // 
            this.TxtStartupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtStartupPath.Location = new System.Drawing.Point(86, 35);
            this.TxtStartupPath.Name = "TxtStartupPath";
            this.TxtStartupPath.Size = new System.Drawing.Size(354, 23);
            this.TxtStartupPath.TabIndex = 7;
            this.toolTip1.SetToolTip(this.TxtStartupPath, "应用将通过该路径来启动程序");
            // 
            // TxtHotKey
            // 
            this.TxtHotKey.BackColor = System.Drawing.Color.White;
            this.TxtHotKey.Location = new System.Drawing.Point(86, 64);
            this.TxtHotKey.Name = "TxtHotKey";
            this.TxtHotKey.ReadOnly = true;
            this.TxtHotKey.Size = new System.Drawing.Size(120, 23);
            this.TxtHotKey.TabIndex = 7;
            this.TxtHotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TxtHotKey, "应用将通过该热键来触发控制");
            this.TxtHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHotKey_KeyDown);
            // 
            // BtnSelectProcess
            // 
            this.BtnSelectProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectProcess.Location = new System.Drawing.Point(260, 6);
            this.BtnSelectProcess.Name = "BtnSelectProcess";
            this.BtnSelectProcess.Size = new System.Drawing.Size(30, 23);
            this.BtnSelectProcess.TabIndex = 8;
            this.BtnSelectProcess.Text = "...";
            this.toolTip1.SetToolTip(this.BtnSelectProcess, "选择进程获取信息");
            this.BtnSelectProcess.UseVisualStyleBackColor = true;
            this.BtnSelectProcess.Click += new System.EventHandler(this.BtnSelectProcess_Click);
            // 
            // BtnSelectStartupPath
            // 
            this.BtnSelectStartupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectStartupPath.Location = new System.Drawing.Point(446, 35);
            this.BtnSelectStartupPath.Name = "BtnSelectStartupPath";
            this.BtnSelectStartupPath.Size = new System.Drawing.Size(30, 23);
            this.BtnSelectStartupPath.TabIndex = 9;
            this.BtnSelectStartupPath.Text = "...";
            this.toolTip1.SetToolTip(this.BtnSelectStartupPath, "手动选择启动文件路径");
            this.BtnSelectStartupPath.UseVisualStyleBackColor = true;
            this.BtnSelectStartupPath.Click += new System.EventHandler(this.BtnSelectStartupPath_Click);
            // 
            // FormHotKey
            // 
            this.AcceptButton = this.BtnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(488, 99);
            this.Controls.Add(this.BtnSelectStartupPath);
            this.Controls.Add(this.BtnSelectProcess);
            this.Controls.Add(this.TxtHotKey);
            this.Controls.Add(this.TxtStartupPath);
            this.Controls.Add(this.TxtProcessName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAccept);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHotKey";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "热键设置";
            this.Load += new System.EventHandler(this.FormHotKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProcessName;
        private System.Windows.Forms.TextBox TxtStartupPath;
        private System.Windows.Forms.TextBox TxtHotKey;
        private System.Windows.Forms.Button BtnSelectProcess;
        private System.Windows.Forms.Button BtnSelectStartupPath;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}