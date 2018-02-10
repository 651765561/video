namespace videoII
{
    partial class frm_play
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.but_Openvideo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.but_closevideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_Openvideo
            // 
            this.but_Openvideo.Location = new System.Drawing.Point(475, 441);
            this.but_Openvideo.Name = "but_Openvideo";
            this.but_Openvideo.Size = new System.Drawing.Size(75, 23);
            this.but_Openvideo.TabIndex = 0;
            this.but_Openvideo.Text = "打开视频";
            this.but_Openvideo.UseVisualStyleBackColor = true;
            this.but_Openvideo.Click += new System.EventHandler(this.but_Openvideo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(673, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            // 
            // but_closevideo
            // 
            this.but_closevideo.Location = new System.Drawing.Point(581, 441);
            this.but_closevideo.Name = "but_closevideo";
            this.but_closevideo.Size = new System.Drawing.Size(75, 23);
            this.but_closevideo.TabIndex = 2;
            this.but_closevideo.Text = "关闭视频";
            this.but_closevideo.UseVisualStyleBackColor = true;
            this.but_closevideo.Click += new System.EventHandler(this.but_closevideo_Click);
            // 
            // frm_play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 476);
            this.Controls.Add(this.but_closevideo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.but_Openvideo);
            this.Name = "frm_play";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.frm_play_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Openvideo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button but_closevideo;
    }
}

