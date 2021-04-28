
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
            this.TxtHotKey1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtHotKey1
            // 
            this.TxtHotKey1.BackColor = System.Drawing.Color.White;
            this.TxtHotKey1.Location = new System.Drawing.Point(96, 122);
            this.TxtHotKey1.Name = "TxtHotKey1";
            this.TxtHotKey1.ReadOnly = true;
            this.TxtHotKey1.Size = new System.Drawing.Size(213, 23);
            this.TxtHotKey1.TabIndex = 0;
            this.TxtHotKey1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtHotKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHotKey1_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 315);
            this.Controls.Add(this.TxtHotKey1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyGo!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHotKey1;
    }
}

