
namespace KeyGo
{
    partial class UCHotKeyItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LblHotKey = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnEnable = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblHotKey
            // 
            this.LblHotKey.Font = new System.Drawing.Font("微软雅黑", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblHotKey.Location = new System.Drawing.Point(5, 31);
            this.LblHotKey.Name = "LblHotKey";
            this.LblHotKey.Size = new System.Drawing.Size(100, 20);
            this.LblHotKey.TabIndex = 0;
            this.LblHotKey.Text = "Ctrl+W";
            this.LblHotKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoEllipsis = true;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.Location = new System.Drawing.Point(5, 6);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(100, 25);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "WeChat";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEnable
            // 
            this.BtnEnable.BackgroundImage = global::KeyGo.Properties.Resources.ImgEnable;
            this.BtnEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnEnable.Location = new System.Drawing.Point(6, 54);
            this.BtnEnable.Name = "BtnEnable";
            this.BtnEnable.Size = new System.Drawing.Size(30, 30);
            this.BtnEnable.TabIndex = 1;
            this.BtnEnable.UseVisualStyleBackColor = true;
            this.BtnEnable.Click += new System.EventHandler(this.BtnEnable_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.BackgroundImage = global::KeyGo.Properties.Resources.ImgDel;
            this.BtnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDel.Location = new System.Drawing.Point(74, 54);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(30, 30);
            this.BtnDel.TabIndex = 3;
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnSet
            // 
            this.BtnSet.BackgroundImage = global::KeyGo.Properties.Resources.ImgSet;
            this.BtnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSet.Location = new System.Drawing.Point(40, 54);
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.Size = new System.Drawing.Size(30, 30);
            this.BtnSet.TabIndex = 2;
            this.BtnSet.UseVisualStyleBackColor = true;
            this.BtnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // UCHotKeyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.BtnEnable);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnSet);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblHotKey);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCHotKeyItem";
            this.Size = new System.Drawing.Size(110, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblHotKey;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button BtnSet;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnEnable;
    }
}
