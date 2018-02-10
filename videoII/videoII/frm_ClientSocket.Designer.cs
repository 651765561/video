namespace videoII
{
    partial class frm_ClientSocket
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
            this.but_connect = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.but_Send = new System.Windows.Forms.Button();
            this.txt_Sendcontext = new System.Windows.Forms.TextBox();
            this.lbl_context = new System.Windows.Forms.Label();
            this.but_recevice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Recevicecontext = new System.Windows.Forms.TextBox();
            this.butplay = new System.Windows.Forms.Button();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.bu_login = new System.Windows.Forms.Button();
            this.but_heartbeat = new System.Windows.Forms.Button();
            this.but_up = new System.Windows.Forms.Button();
            this.but_SignOut = new System.Windows.Forms.Button();
            this.lbl_PTZCmd = new System.Windows.Forms.Label();
            this.txt_PTZCmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // but_connect
            // 
            this.but_connect.Location = new System.Drawing.Point(28, 297);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(87, 25);
            this.but_connect.TabIndex = 0;
            this.but_connect.Text = "连接服务";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(752, 33);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(49, 14);
            this.lbl_status.TabIndex = 1;
            this.lbl_status.Text = "label1";
            // 
            // but_Send
            // 
            this.but_Send.Location = new System.Drawing.Point(528, 367);
            this.but_Send.Name = "but_Send";
            this.but_Send.Size = new System.Drawing.Size(87, 25);
            this.but_Send.TabIndex = 2;
            this.but_Send.Text = "发送信息";
            this.but_Send.UseVisualStyleBackColor = true;
            this.but_Send.Click += new System.EventHandler(this.but_Send_Click);
            // 
            // txt_Sendcontext
            // 
            this.txt_Sendcontext.Location = new System.Drawing.Point(34, 79);
            this.txt_Sendcontext.Multiline = true;
            this.txt_Sendcontext.Name = "txt_Sendcontext";
            this.txt_Sendcontext.Size = new System.Drawing.Size(348, 189);
            this.txt_Sendcontext.TabIndex = 3;
            // 
            // lbl_context
            // 
            this.lbl_context.AutoSize = true;
            this.lbl_context.Location = new System.Drawing.Point(51, 63);
            this.lbl_context.Name = "lbl_context";
            this.lbl_context.Size = new System.Drawing.Size(77, 14);
            this.lbl_context.TabIndex = 4;
            this.lbl_context.Text = "发送内容：";
            // 
            // but_recevice
            // 
            this.but_recevice.Location = new System.Drawing.Point(636, 367);
            this.but_recevice.Name = "but_recevice";
            this.but_recevice.Size = new System.Drawing.Size(87, 25);
            this.but_recevice.TabIndex = 5;
            this.but_recevice.Text = "接收信息";
            this.but_recevice.UseVisualStyleBackColor = true;
            this.but_recevice.Click += new System.EventHandler(this.but_recevice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "接收内容：";
            // 
            // txt_Recevicecontext
            // 
            this.txt_Recevicecontext.Location = new System.Drawing.Point(451, 79);
            this.txt_Recevicecontext.Multiline = true;
            this.txt_Recevicecontext.Name = "txt_Recevicecontext";
            this.txt_Recevicecontext.Size = new System.Drawing.Size(348, 189);
            this.txt_Recevicecontext.TabIndex = 7;
            // 
            // butplay
            // 
            this.butplay.Location = new System.Drawing.Point(780, 367);
            this.butplay.Name = "butplay";
            this.butplay.Size = new System.Drawing.Size(87, 25);
            this.butplay.TabIndex = 8;
            this.butplay.Text = "播发器";
            this.butplay.UseVisualStyleBackColor = true;
            this.butplay.Click += new System.EventHandler(this.butplay_Click);
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(54, 14);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(63, 14);
            this.lbl_ip.TabIndex = 9;
            this.lbl_ip.Text = "IP地址：";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(124, 3);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(492, 23);
            this.txtIp.TabIndex = 10;
            this.txtIp.Text = "192.168.0.226";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(54, 39);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(49, 14);
            this.lbl_port.TabIndex = 11;
            this.lbl_port.Text = "端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(124, 33);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(116, 23);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "5060";
            // 
            // bu_login
            // 
            this.bu_login.Location = new System.Drawing.Point(136, 297);
            this.bu_login.Name = "bu_login";
            this.bu_login.Size = new System.Drawing.Size(87, 25);
            this.bu_login.TabIndex = 13;
            this.bu_login.Text = "登录";
            this.bu_login.UseVisualStyleBackColor = true;
            this.bu_login.Click += new System.EventHandler(this.bu_login_Click);
            // 
            // but_heartbeat
            // 
            this.but_heartbeat.Location = new System.Drawing.Point(257, 297);
            this.but_heartbeat.Name = "but_heartbeat";
            this.but_heartbeat.Size = new System.Drawing.Size(87, 25);
            this.but_heartbeat.TabIndex = 14;
            this.but_heartbeat.Text = "心跳";
            this.but_heartbeat.UseVisualStyleBackColor = true;
            this.but_heartbeat.Click += new System.EventHandler(this.but_heartbeat_Click);
            // 
            // but_up
            // 
            this.but_up.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_up.Location = new System.Drawing.Point(28, 383);
            this.but_up.Name = "but_up";
            this.but_up.Size = new System.Drawing.Size(87, 25);
            this.but_up.TabIndex = 15;
            this.but_up.Text = "云镜控制向上";
            this.but_up.UseVisualStyleBackColor = true;
            this.but_up.LocationChanged += new System.EventHandler(this.but_up_LocationChanged);
            this.but_up.Click += new System.EventHandler(this.but_up_Click_1);
            this.but_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.but_up_MouseDown);
            this.but_up.MouseLeave += new System.EventHandler(this.but_up_MouseLeave);
            this.but_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_up_MouseUp);
            // 
            // but_SignOut
            // 
            this.but_SignOut.Location = new System.Drawing.Point(360, 297);
            this.but_SignOut.Name = "but_SignOut";
            this.but_SignOut.Size = new System.Drawing.Size(87, 25);
            this.but_SignOut.TabIndex = 16;
            this.but_SignOut.Text = "退出";
            this.but_SignOut.UseVisualStyleBackColor = true;
            this.but_SignOut.Click += new System.EventHandler(this.but_SignOut_Click);
            // 
            // lbl_PTZCmd
            // 
            this.lbl_PTZCmd.AutoSize = true;
            this.lbl_PTZCmd.Location = new System.Drawing.Point(34, 339);
            this.lbl_PTZCmd.Name = "lbl_PTZCmd";
            this.lbl_PTZCmd.Size = new System.Drawing.Size(91, 14);
            this.lbl_PTZCmd.TabIndex = 17;
            this.lbl_PTZCmd.Text = "PTZCmd(0-8):";
            // 
            // txt_PTZCmd
            // 
            this.txt_PTZCmd.Location = new System.Drawing.Point(132, 339);
            this.txt_PTZCmd.Name = "txt_PTZCmd";
            this.txt_PTZCmd.Size = new System.Drawing.Size(63, 23);
            this.txt_PTZCmd.TabIndex = 18;
            // 
            // frm_ClientSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 441);
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
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frm_ClientSocket";
            this.Text = "frm_ClientSocket";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ClientSocket_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button but_Send;
        private System.Windows.Forms.TextBox txt_Sendcontext;
        private System.Windows.Forms.Label lbl_context;
        private System.Windows.Forms.Button but_recevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Recevicecontext;
        private System.Windows.Forms.Button butplay;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button bu_login;
        private System.Windows.Forms.Button but_heartbeat;
        private System.Windows.Forms.Button but_up;
        private System.Windows.Forms.Button but_SignOut;
        private System.Windows.Forms.Label lbl_PTZCmd;
        private System.Windows.Forms.TextBox txt_PTZCmd;
    }
}