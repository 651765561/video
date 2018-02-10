namespace videoII
{
    partial class frm_palymp3
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
            this.but_playMp3 = new System.Windows.Forms.Button();
            this.but_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // but_playMp3
            // 
            this.but_playMp3.Location = new System.Drawing.Point(608, 45);
            this.but_playMp3.Name = "but_playMp3";
            this.but_playMp3.Size = new System.Drawing.Size(75, 23);
            this.but_playMp3.TabIndex = 0;
            this.but_playMp3.Text = "播放";
            this.but_playMp3.UseVisualStyleBackColor = true;
            this.but_playMp3.Click += new System.EventHandler(this.but_playMp3_Click);
            // 
            // but_stop
            // 
            this.but_stop.Location = new System.Drawing.Point(373, 276);
            this.but_stop.Name = "but_stop";
            this.but_stop.Size = new System.Drawing.Size(75, 23);
            this.but_stop.TabIndex = 1;
            this.but_stop.Text = "停止";
            this.but_stop.UseVisualStyleBackColor = true;
            this.but_stop.Click += new System.EventHandler(this.but_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_palymp3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_stop);
            this.Controls.Add(this.but_playMp3);
            this.Name = "frm_palymp3";
            this.Text = "frm_palymp3";
            this.Load += new System.EventHandler(this.frm_palymp3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_playMp3;
        private System.Windows.Forms.Button but_stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}