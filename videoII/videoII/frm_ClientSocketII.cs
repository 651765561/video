using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace videoII
{
    public partial class frm_ClientSocketII : Form
    {
        CameraControl bllCameraControl = new CameraControl();
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        VoiceControl bllVoiceControl = new VoiceControl();
        int v_num = -1;
        public frm_ClientSocketII()
        {
            InitializeComponent();
          v_num=  bllVoiceControl.Do_VoiceTalk_Init();
        }

        private void but_connect_Click(object sender, EventArgs e)
        {
            int port = 1234;
            string host = "192.168.0.11";//服务器端ip地址
            host = txtIp.Text.Trim();
            port = int.Parse(txtPort.Text);

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);


            bllCameraControl.ConnectSocket(host, port);
        }

        private void bu_login_Click(object sender, EventArgs e)
        {

            //txt_Recevicecontext.Text += recStr + "/n/r";

            var userId = "34020000003000000001";
            var hostIp = "192.168.0.226";
            hostIp = txtIp.Text.Trim();
            int port = int.Parse(txtPort.Text);
            string str = bllCameraControl.Login(userId, hostIp, port);
            txt_Recevicecontext.Text = str;
        }

        private void butplay_Click(object sender, EventArgs e)
        {
            BusinessLogic.railway_user bllrailway_user = new BusinessLogic.railway_user();
           var userid= bllrailway_user.GetUserID("adm");
           BusinessLogic.railway_server bllrailway_server = new BusinessLogic.railway_server();
          // var ip = bllrailway_server.GetServerIP("34020000002090000001");
            frm_play frm = new frm_play();
            frm.Show();
        }

        private void but_heartbeat_Click(object sender, EventArgs e)
        {
            HeartBeatParameter p = new HeartBeatParameter();
            p.second = 30;
            p.hostIP = "192.168.0.226";
            p.hostIP = txtIp.Text.Trim();
            p.UserID = "34020000003000000001";
            p.UserID = "34020000003000000001";
            p.CameraUrl = p.UserID + "@" + p.hostIP;
            p.Status = 1;
            int port = int.Parse(txtPort.Text);
            p.port = port;
            Thread t = new Thread(new ParameterizedThreadStart(heartbeat));
            t.IsBackground = true;
            t.Start(p);
        }

        private void heartbeat(object obj)
        {
            HeartBeatParameter p = (HeartBeatParameter)obj;
            string recStr = "";
            while (true)
            {
                cacheLock.EnterWriteLock();
                try
                {

                    recStr = bllCameraControl.heartbeatII(p);
                }
                finally
                {
                    SetText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + recStr + "/n/r");
                    
                    cacheLock.ExitWriteLock();
                    Thread.Sleep(1000 * p.second);
                }

            }

        }

        delegate void SetTextCallBack(string text);
        private void SetText(string text)
        {
            if (this.txt_Recevicecontext.InvokeRequired)
            {
                SetTextCallBack stcb = new SetTextCallBack(SetText);
                this.Invoke(stcb, new object[] { text });
            }
            else
            {
                this.txt_Recevicecontext.Text = text;
            }
        }

        private void frm_ClientSocketII_Load(object sender, EventArgs e)
        {

        }

        private void but_up_MouseDown(object sender, MouseEventArgs e)
        {
            CameraControl bllCameraControl = new CameraControl();
            CloudMirrorParameter p = new CloudMirrorParameter();
            int PTZCmd = int.Parse(txt_PTZCmd.Text);
           // p.hostIP = "192.168.0.226";
            p.hostIP = txtIp.Text.Trim();
            
            p.Param = 5;
            p.Priority = 0;
            p.PTZCmd = PTZCmd;
            p.Stop = 0;
            p.UserId = "34020000003000000001";
            p.UserUrl = "34020000003000000001@"+txtIp.Text.Trim();
            //p.CameraID = "20000000001320000002";
            //p.CameraUrl = "20000000001320000002@" + txtIp.Text.Trim();
            p.CameraID = "20000000001320000002";
            p.CameraUrl =  p.CameraID +"@" + txtIp.Text.Trim();
            p.port = 5060;
            bllCameraControl.CloudMirrorControl(p);
        }

        private void but_up_MouseUp(object sender, MouseEventArgs e)
        {
            CameraControl bllCameraControl = new CameraControl();
            CloudMirrorParameter p = new CloudMirrorParameter();
            int PTZCmd = int.Parse(txt_PTZCmd.Text);
            p.hostIP = txtIp.Text.Trim();
            p.Param = 5;
            p.Priority = 0;
            p.PTZCmd = PTZCmd;
            p.Stop = 1;
            p.UserId = "34020000003000000001";
            p.UserUrl = "34020000003000000001@"+txtIp.Text.Trim();
         //   p.CameraID = "20000000001320000002";
            p.CameraID = "20000000001320000002";
            p.CameraUrl = p.CameraID+"@" + txtIp.Text.Trim();
            p.port = 5060;
            bllCameraControl.CloudMirrorControl(p);
        }

        private void but_up_Click(object sender, EventArgs e)
        {

        }

        private void but_SignOut_Click(object sender, EventArgs e)
        {
            ///*协议体*/
            //StringBuilder strBody = new StringBuilder();
            //strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            //strBody.Append("<User>34020000003000000001@192.168.0.226</User>");
            //strBody.Append("</Message>");
            ///*协议头*/
            //int len = strBody.ToString().Length;
            //string strheader = "";
            //strheader = GetAgreementHeader(1008, len);
            //string contentStr = strheader.ToString() + strBody.ToString();
            ///*发送指令*/
            //string sendStr = contentStr;
            //byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            //int num = clientSocket.Send(sendBytes);
            ///*接收返回值*/
            //string recStr = "";
            //byte[] recBytes = new byte[4096];
            //int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            //recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            //txt_Recevicecontext.Text += recStr + "/n/r";
            SignOutParameter p = new SignOutParameter();
            p.UserUrl = "34020000003000000001@" + txtIp.Text.Trim();
            p.UserId = "34020000003000000001";
            p.hostIP = txtIp.Text.Trim();
            p.port = 5060;
            bllCameraControl.SignOut(p);
        }
        int VoiceTalkNum = -1;
        private void but_startVoice_Click(object sender, EventArgs e)
        {
            string ip = txtIp.Text.Trim();
            ip = "192.168.0.227";
            string CameraID = "20000000001320000002";
          VoiceTalkNum=  bllVoiceControl.Do_VoiceTalk_Start(ip,CameraID);
          MessageBox.Show(this, VoiceTalkNum.ToString());

        }

        private void but_stopVoice_Click(object sender, EventArgs e)
        {
            bllVoiceControl.Do_VoiceTalk_Stop();
        }

        private void butPlayMp3_Click(object sender, EventArgs e)
        {
            frm_palymp3 frmpalymp3 = new frm_palymp3();
            frmpalymp3.ShowDialog();
        }
    }
}
