namespace videoII
{
    partial class frm_ClientSocketII
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
            this.txt_PTZCmd = new System.Windows.Forms.TextBox();
            this.lbl_PTZCmd = new System.Windows.Forms.Label();
            this.but_SignOut = new System.Windows.Forms.Button();
            this.but_up = new System.Windows.Forms.Button();
            this.but_heartbeat = new System.Windows.Forms.Button();
            this.bu_login = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.butplay = new System.Windows.Forms.Button();
            this.txt_Recevicecontext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_recevice = new System.Windows.Forms.Button();
            this.lbl_context = new System.Windows.Forms.Label();
            this.txt_Sendcontext = new System.Windows.Forms.TextBox();
            this.but_Send = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.but_connect = new System.Windows.Forms.Button();
            this.but_startVoice = new System.Windows.Forms.Button();
            this.but_stopVoice = new System.Windows.Forms.Button();
            this.butPlayMp3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_PTZCmd
            // 
            this.txt_PTZCmd.Location = new System.Drawing.Point(115, 351);
            this.txt_PTZCmd.Name = "txt_PTZCmd";
            this.txt_PTZCmd.Size = new System.Drawing.Size(63, 21);
            this.txt_PTZCmd.TabIndex = 37;
            // 
            // lbl_PTZCmd
            // 
            this.lbl_PTZCmd.AutoSize = true;
            this.lbl_PTZCmd.Location = new System.Drawing.Point(17, 351);
            this.lbl_PTZCmd.Name = "lbl_PTZCmd";
            this.lbl_PTZCmd.Size = new System.Drawing.Size(77, 12);
            this.lbl_PTZCmd.TabIndex = 36;
            this.lbl_PTZCmd.Text = "PTZCmd(0-8):";
            // 
            // but_SignOut
            // 
            this.but_SignOut.Location = new System.Drawing.Point(343, 309);
            this.but_SignOut.Name = "but_SignOut";
            this.but_SignOut.Size = new System.Drawing.Size(87, 25);
            this.but_SignOut.TabIndex = 35;
            this.but_SignOut.Text = "退出";
            this.but_SignOut.UseVisualStyleBackColor = true;
            this.but_SignOut.Click += new System.EventHandler(this.but_SignOut_Click);
            // 
            // but_up
            // 
            this.but_up.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_up.Location = new System.Drawing.Point(11, 395);
            this.but_up.Name = "but_up";
            this.but_up.Size = new System.Drawing.Size(87, 25);
            this.but_up.TabIndex = 34;
            this.but_up.Text = "云镜控制向上";
            this.but_up.UseVisualStyleBackColor = true;
            this.but_up.Click += new System.EventHandler(this.but_up_Click);
            this.but_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.but_up_MouseDown);
            this.but_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_up_MouseUp);
            // 
            // but_heartbeat
            // 
            this.but_heartbeat.Location = new System.Drawing.Point(240, 309);
            this.but_heartbeat.Name = "but_heartbeat";
            this.but_heartbeat.Size = new System.Drawing.Size(87, 25);
            this.but_heartbeat.TabIndex = 33;
            this.but_heartbeat.Text = "心跳";
            this.but_heartbeat.UseVisualStyleBackColor = true;
            this.but_heartbeat.Click += new System.EventHandler(this.but_heartbeat_Click);
            // 
            // bu_login
            // 
            this.bu_login.Location = new System.Drawing.Point(119, 309);
            this.bu_login.Name = "bu_login";
            this.bu_login.Size = new System.Drawing.Size(87, 25);
            this.bu_login.TabIndex = 32;
            this.bu_login.Text = "登录";
            this.bu_login.UseVisualStyleBackColor = true;
            this.bu_login.Click += new System.EventHandler(this.bu_login_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(93, 45);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(116, 21);
            this.txtPort.TabIndex = 31;
            this.txtPort.Text = "5060";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(23, 51);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(41, 12);
            this.lbl_port.TabIndex = 30;
            this.lbl_port.Text = "端口：";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(93, 15);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(492, 21);
            this.txtIp.TabIndex = 29;
            this.txtIp.Text = "192.168.0.238";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(23, 26);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(53, 12);
            this.lbl_ip.TabIndex = 28;
            this.lbl_ip.Text = "IP地址：";
            // 
            // butplay
            // 
            this.butplay.Location = new System.Drawing.Point(763, 379);
            this.butplay.Name = "butplay";
            this.butplay.Size = new System.Drawing.Size(87, 25);
            this.butplay.TabIndex = 27;
            this.butplay.Text = "播发器";
            this.butplay.UseVisualStyleBackColor = true;
            this.butplay.Click += new System.EventHandler(this.butplay_Click);
            // 
            // txt_Recevicecontext
            // 
            this.txt_Recevicecontext.Location = new System.Drawing.Point(434, 91);
            this.txt_Recevicecontext.Multiline = true;
            this.txt_Recevicecontext.Name = "txt_Recevicecontext";
            this.txt_Recevicecontext.Size = new System.Drawing.Size(348, 189);
            this.txt_Recevicecontext.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "接收内容：";
            // 
            // but_recevice
            // 
            this.but_recevice.Location = new System.Drawing.Point(619, 379);
            this.but_recevice.Name = "but_recevice";
            this.but_recevice.Size = new System.Drawing.Size(87, 25);
            this.but_recevice.TabIndex = 24;
            this.but_recevice.Text = "接收信息";
            this.but_recevice.UseVisualStyleBackColor = true;
            // 
            // lbl_context
            // 
            this.lbl_context.AutoSize = true;
            this.lbl_context.Location = new System.Drawing.Point(34, 75);
            this.lbl_context.Name = "lbl_context";
            this.lbl_context.Size = new System.Drawing.Size(65, 12);
            this.lbl_context.TabIndex = 23;
            this.lbl_context.Text = "发送内容：";
            // 
            // txt_Sendcontext
            // 
            this.txt_Sendcontext.Location = new System.Drawing.Point(17, 91);
            this.txt_Sendcontext.Multiline = true;
            this.txt_Sendcontext.Name = "txt_Sendcontext";
            this.txt_Sendcontext.Size = new System.Drawing.Size(348, 189);
            this.txt_Sendcontext.TabIndex = 22;
            // 
            // but_Send
            // 
            this.but_Send.Location = new System.Drawing.Point(511, 379);
            this.but_Send.Name = "but_Send";
            this.but_Send.Size = new System.Drawing.Size(87, 25);
            this.but_Send.TabIndex = 21;
            this.but_Send.Text = "发送信息";
            this.but_Send.UseVisualStyleBackColor = true;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(735, 45);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(41, 12);
            this.lbl_status.TabIndex = 20;
            this.lbl_status.Text = "label1";
            // 
            // but_connect
            // 
            this.but_connect.Location = new System.Drawing.Point(11, 309);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(87, 25);
            this.but_connect.TabIndex = 19;
            this.but_connect.Text = "连接服务";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // but_startVoice
            // 
            this.but_startVoice.Location = new System.Drawing.Point(511, 459);
            this.but_startVoice.Name = "but_startVoice";
            this.but_startVoice.Size = new System.Drawing.Size(87, 25);
            this.but_startVoice.TabIndex = 38;
            this.but_startVoice.Text = "启动语音";
            this.but_startVoice.UseVisualStyleBackColor = true;
            this.but_startVoice.Click += new System.EventHandler(this.but_startVoice_Click);
            // 
            // but_stopVoice
            // 
            this.but_stopVoice.Location = new System.Drawing.Point(619, 459);
            this.but_stopVoice.Name = "but_stopVoice";
            this.but_stopVoice.Size = new System.Drawing.Size(87, 25);
            this.but_stopVoice.TabIndex = 39;
            this.but_stopVoice.Text = "停止语音";
            this.but_stopVoice.UseVisualStyleBackColor = true;
            this.but_stopVoice.Click += new System.EventHandler(this.but_stopVoice_Click);
            // 
            // butPlayMp3
            // 
            this.butPlayMp3.Location = new System.Drawing.Point(951, 380);
            this.butPlayMp3.Name = "butPlayMp3";
            this.butPlayMp3.Size = new System.Drawing.Size(75, 23);
            this.butPlayMp3.TabIndex = 40;
            this.butPlayMp3.Text = "播放mp3";
            this.butPlayMp3.UseVisualStyleBackColor = true;
            this.butPlayMp3.Click += new System.EventHandler(this.butPlayMp3_Click);
            // 
            // frm_ClientSocketII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 538);
            this.Controls.Add(this.butPlayMp3);
            this.Controls.Add(this.but_stopVoice);
            this.Controls.Add(this.but_startVoice);
            this.Controls.Add(this.txt_PTZCmd);
            this.Controls.Add(this.lbl_PTZCmd);
            this.Controls.Add(this.but_SignOut);
            this.Controls.Add(this.but_up);
            this.Controls.Add(this.but_heartbeat);
            this.Controls.Add(this.bu_login);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.butplay);
            this.Controls.Add(this.txt_Recevicecontext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_recevice);
            this.Controls.Add(this.lbl_context);
            this.Controls.Add(this.txt_Sendcontext);
            this.Controls.Add(this.but_Send);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.but_connect);
            this.Name = "frm_ClientSocketII";
            this.Text = "frm_ClientSocketII";
            this.Load += new System.EventHandler(this.frm_ClientSocketII_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PTZCmd;
        private System.Windows.Forms.Label lbl_PTZCmd;
        private System.Windows.Forms.Button but_SignOut;
        private System.Windows.Forms.Button but_up;
        private System.Windows.Forms.Button but_heartbeat;
        private System.Windows.Forms.Button bu_login;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Button butplay;
        private System.Windows.Forms.TextBox txt_Recevicecontext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_recevice;
        private System.Windows.Forms.Label lbl_context;
        private System.Windows.Forms.TextBox txt_Sendcontext;
        private System.Windows.Forms.Button but_Send;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Button but_startVoice;
        private System.Windows.Forms.Button but_stopVoice;
        private System.Windows.Forms.Button butPlayMp3;
    }
}