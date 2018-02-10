using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace videoII
{
    public partial class frm_ClientSocket : Form
    {
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        Socket clientSocket;
        public frm_ClientSocket()
        {
            InitializeComponent();
        }
        /*
         <?xml version="1.0" encoding="UTF-8"?>
<Message>
<User>客户端URL </User>
<Camera>摄像机URL </Camera>
    <PTZCmd>PTZ动作</PTZCmd>
    <Param>速度</Param>
    <Stop>0：开始，1：停止</Stop>
    <Priority>用户优先级</Priority>
</Message>

34020000003000000001@192.168.0.226
admin
admin

<?xml version="1.0" encoding="UTF-8"?>
<Message>
    <User>34020000003000000001@192.168.0.226</User>
    <UserName>admin</UserName >
    <Password>admin</ Password >
    <ClientType>1</ClientType>
</Message>

         */
        private void but_connect_Click(object sender, EventArgs e)
        {
            int port = 1234;
            string host = "192.168.0.11";//服务器端ip地址
            host = txtIp.Text.Trim();
            port = int.Parse(txtPort.Text);

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(ipe);

            CameraControl bllCameraControl = new CameraControl();

        }

        private void frm_ClientSocket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void but_Send_Click(object sender, EventArgs e)
        {
            //send message
            string sendStr = txt_Sendcontext.Text.Trim();
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);

            //string recStr = "";
            //byte[] recBytes = new byte[4096];
            //int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            //recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            //txt_Recevicecontext.Text += recStr + "/n/r";
        }

        private void but_recevice_Click(object sender, EventArgs e)
        {
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            txt_Recevicecontext.Text += recStr + "/n/r";
        }

        private void butplay_Click(object sender, EventArgs e)
        {
            frm_play frm = new frm_play();
            frm.Show();
        }

        private void bu_login_Click(object sender, EventArgs e)
        {
            /*
             协议头不同的部分有
             * 1.协议编号 
             * 2.协议体内容长度
             * 
             */
            /*
             * \r\n
             REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0
Call-ID: abedreg;branch
Proxy-Info:1000
Content-Type:Application/xml
Expires:3600
Cseq:2 REGISTER
From:<sip:000000000000000000@127.0.0.1>;tag=123
Max-Forwards:70
To:<sip:000000000000000000@127.0.0.1>
Content-Length:196

<?xml version="1.0" encoding="UTF-8"?>
<Message>
<User>34020000003000000001@192.168.0.226</User>
<UserName>admin</UserName>
<Password>admin</Password>
<ClientType>1</ClientType>
</Message>
             */




            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<Message>\r\n");
            strBody.Append("<User>34020000003000000001@192.168.0.226</User>\r\n");
            strBody.Append("<UserName>admin</UserName>\r\n");
            strBody.Append("<Password>admin</Password>\r\n");
            strBody.Append("<ClientType>1</ClientType>\r\n");
            strBody.Append("</Message>");

            /*协议头*/
            StringBuilder strHeader = new StringBuilder();
            strHeader.Append("REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0\r\n");
            strHeader.Append("Call-ID: abedreg;branch\r\n");
            strHeader.Append("Proxy-Info:1000\r\n");
            strHeader.Append("Content-Type:Application/xml\r\n");
            strHeader.Append("Expires:3600\r\n");
            strHeader.Append("Cseq:2 REGISTER\r\n");
            strHeader.Append("From:<sip:000000000000000000@127.0.0.1>;tag=123\r\n");
            strHeader.Append("Max-Forwards:70\r\n");
            strHeader.Append("To:<sip:000000000000000000@127.0.0.1>\r\n");
            int len = strBody.ToString().Length;
            strHeader.Append("Content-Length:" + len + "\r\n\r\n");//196动态 是协议体长度

            string contentStr = strHeader.ToString() + strBody.ToString();
            /*发送指令*/
            string sendStr = contentStr;
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);
            /*接收返回值*/
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            txt_Recevicecontext.Text += recStr + "/n/r";
        }
        /// <summary>
        /// 心跳30秒执行一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_heartbeat_Click(object sender, EventArgs e)
        {
            /*
             REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0
            Call-ID: abedreg;branch
            Proxy-Info:1002
            Content-Type:Application/xml
            Expires:3600
            Cseq:3 REGISTER
            From:<sip:000000000000000000@127.0.0.1>;tag=123
            Max-Forwards:70
            To:<sip:000000000000000000@127.0.0.1>
            Content-Length:140

            <?xml version="1.0" encoding="UTF-8"?>
            <Message>
            <DeviceID>34020000003000000001@192.168.0.226</DeviceID>
            <Status>1</Status>
            </Message>
             */




            Thread t = new Thread(new ParameterizedThreadStart(heartbeat));
            t.IsBackground = true;
            HeartBeatParameter p = new HeartBeatParameter();
            p.second = 30;
            p.hostIP = "192.168.0.226";
            p.UserID = "34020000003000000001";
            p.CameraUrl = p.UserID + "@" + p.hostIP;
            p.Status = 1;
            t.Start(p);
        }

        /// <summary>
        /// 定时执行心跳方法
        /// </summary>
        /// <param name="second">间隔时间</param>
        private void heartbeat(object second)
        {
            HeartBeatParameter obj = (HeartBeatParameter)second;
            while (true)
            {
                cacheLock.EnterWriteLock();
                try
                {
                    /*协议体*/
                    StringBuilder strBody = new StringBuilder();

                    strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
                    strBody.Append("<Message>\r\n");
                    //  strBody.Append("<DeviceID>34020000003000000001@192.168.0.226</DeviceID>\r\n");
                    strBody.Append("<DeviceID>" + obj.CameraUrl + "</DeviceID>\r\n");
                    strBody.Append("<Status>" + obj.Status + "</Status>\r\n");
                    strBody.Append("</Message>\r\n");

                    /*协议头*/
                    int len = strBody.ToString().Length;
                    StringBuilder strHeader = new StringBuilder();
                    strHeader.Append("REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0\r\n");
                    strHeader.Append("Call-ID: abedreg;branch\r\n");
                    strHeader.Append("Proxy-Info:1002\r\n");
                    strHeader.Append("Content-Type:Application/xml\r\n");
                    strHeader.Append("Expires:3600\r\n");
                    strHeader.Append("Cseq:3 REGISTER\r\n");
                    strHeader.Append("From:<sip:000000000000000000@127.0.0.1>;tag=123\r\n");
                    strHeader.Append("Max-Forwards:70\r\n");
                    strHeader.Append("To:<sip:000000000000000000@127.0.0.1>\r\n");
                    strHeader.Append("Content-Length:" + len + "\r\n\r\n");

                    string contentStr = strHeader.ToString() + strBody.ToString();
                    /*发送指令*/
                    string sendStr = contentStr;
                    byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
                    int num = clientSocket.Send(sendBytes);
                    /*接收返回值*/
                    string recStr = "";
                    byte[] recBytes = new byte[4096];
                    int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
                    recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
                    SetText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+recStr + "/n/r");

                   // txt_Recevicecontext.Text += recStr + "/n/r";
                }
                finally {
                    Thread.Sleep(1000 * obj.second);
                    cacheLock.ExitWriteLock();
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
        private void but_up_Click(object sender, EventArgs e)
        { /*
               REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0
                Call-ID: abedreg;branch
                Proxy-Info:1006
                Content-Type:Application/xml
                Expires:3600
                Cseq:4 REGISTER
                From:<sip:000000000000000000@127.0.0.1>;tag=123
                Max-Forwards:70
                To:<sip:000000000000000000@127.0.0.1>
                Content-Length:246

                <?xml version="1.0" encoding="UTF-8"?>
                <Message>
                <User>34020000003000000001@192.168.0.226</User>
                <Camera>20000000001320000002@192.168.0.226</Camera>
 		                <PTZCmd>0</PTZCmd>
                <Param>5</Param>
                <Stop>0</Stop>
                <Priority>0</Priority>
                </Message>

               */
         //   SetCloudMirrorControl();
          
        }

        private void SetCloudMirrorControl()
        {
            int PTZCmd = int.Parse(txt_PTZCmd.Text);
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<Message>\r\n");
            strBody.Append("<User>34020000003000000001@192.168.0.226</User>\r\n");
            strBody.Append("<Camera>20000000001320000002@192.168.0.226</Camera>\r\n");
            strBody.Append("<PTZCmd>" + PTZCmd + "</PTZCmd>\r\n");
            strBody.Append("<Param>5</Param>\r\n");
            strBody.Append("<Stop>0</Stop>\r\n");
            strBody.Append("<Priority>0</Priority>\r\n");
            strBody.Append("</Message>\r\n");

            /*协议头*/
            int len = strBody.ToString().Length;
            string strheader = "";
            strheader = GetAgreementHeader(1006, len);

            string contentStr = strheader.ToString() + strBody.ToString();
            /*发送指令*/
            string sendStr = contentStr;
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);
            /*接收返回值*/
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            txt_Recevicecontext.Text += recStr + "/n/r";
        }
        /// <summary>
        /// 获取协议头内容
        /// </summary>
        /// <param name="AgreementID">协议编号</param>
        /// <param name="AgreementBodylen">协议体内容长度</param>
        /// <returns></returns>
        private string GetAgreementHeader(int AgreementID, int AgreementBodylen)
        {
            /*协议头*/
            StringBuilder strHeader = new StringBuilder();
            strHeader.Append("REGISTER sip:000000000000000000@127.0.0.1 SIP/2.0\r\n");
            strHeader.Append("Call-ID: abedreg;branch\r\n");
            strHeader.Append("Proxy-Info:" + AgreementID + "\r\n");
            strHeader.Append("Content-Type:Application/xml\r\n");
            strHeader.Append("Expires:3600\r\n");
            strHeader.Append("Cseq:2 REGISTER\r\n");
            strHeader.Append("From:<sip:000000000000000000@127.0.0.1>;tag=123\r\n");
            strHeader.Append("Max-Forwards:70\r\n");
            strHeader.Append("To:<sip:000000000000000000@127.0.0.1>\r\n");
            strHeader.Append("Content-Length:" + AgreementBodylen + "\r\n\r\n");//196动态 是协议体长度
            return strHeader.ToString();
        }

        private void but_SignOut_Click(object sender, EventArgs e)
        {
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<User>34020000003000000001@192.168.0.226</User>");
            strBody.Append("</Message>");
            /*协议头*/
            int len = strBody.ToString().Length;
            string strheader = "";
            strheader = GetAgreementHeader(1008, len);
            string contentStr = strheader.ToString() + strBody.ToString();
            /*发送指令*/
            string sendStr = contentStr;
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);
            /*接收返回值*/
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            txt_Recevicecontext.Text += recStr + "/n/r";
        }

       

        private void but_up_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void but_up_MouseDown(object sender, MouseEventArgs e)
        {
            CameraControl bllCameraControl = new CameraControl();
            CloudMirrorParameter p = new CloudMirrorParameter();
            int PTZCmd = int.Parse(txt_PTZCmd.Text);
            p.hostIP = "192.168.0.226";
            p.Param = 5;
            p.Priority = 0;
            p.PTZCmd = PTZCmd;
            p.Stop = 0;
            p.UserId = "34020000003000000001";
            p.UserUrl = "34020000003000000001@192.168.0.226";
            p.CameraID = "20000000001320000002";
            p.CameraUrl = "20000000001320000002@192.168.0.226";
            CloudMirrorControl(p);
        }

        private void but_up_MouseUp(object sender, MouseEventArgs e)
        {
            CameraControl bllCameraControl = new CameraControl();
            CloudMirrorParameter p = new CloudMirrorParameter();
            int PTZCmd = int.Parse(txt_PTZCmd.Text);
            p.hostIP = "192.168.0.226";
            p.Param = 5;
            p.Priority = 0;
            p.PTZCmd = PTZCmd;
            p.Stop = 1;
            p.UserId = "34020000003000000001";
            p.UserUrl = "34020000003000000001@192.168.0.226";
            p.CameraID = "20000000001320000002";
            p.CameraUrl = "20000000001320000002@192.168.0.226";
            CloudMirrorControl(p);
        }

        /// <summary>
        /// 云镜控制
        /// </summary>
        /// <param name="p">云镜控制参数</param>
        /// <returns></returns>
        public string CloudMirrorControl(CloudMirrorParameter p)
        {
            string str = "";
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<Message>\r\n");
            // strBody.Append("<User>34020000003000000001@192.168.0.226</User>\r\n");
            strBody.Append("<User>" + p.UserUrl + "</User>\r\n");
            //  strBody.Append("<Camera>20000000001320000002@192.168.0.226</Camera>\r\n");
            strBody.Append("<Camera>" + p.CameraUrl + "</Camera>\r\n");
            //  strBody.Append("<PTZCmd>0</PTZCmd>\r\n");
            strBody.Append("<PTZCmd>" + p.PTZCmd + "</PTZCmd>\r\n");
            //  strBody.Append("<Param>5</Param>\r\n");
            strBody.Append("<Param>" + p.Param + "</Param>\r\n");
            //   strBody.Append("<Stop>0</Stop>\r\n");
            strBody.Append("<Stop>" + p.Stop + "</Stop>\r\n");
            // strBody.Append("<Priority>0</Priority>\r\n");
            strBody.Append("<Priority>" + p.Priority + "</Priority>\r\n");
            strBody.Append("</Message>\r\n");

            /*协议头*/
            int len = strBody.ToString().Length;
            string strheader = "";
            strheader = GetAgreementHeader(1006, len);

            string contentStr = strheader.ToString() + strBody.ToString();
            /*发送指令*/
            string sendStr = contentStr;
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);
            /*接收返回值*/
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            return recStr;
        }

        private void but_up_Click_1(object sender, EventArgs e)
        {

        }

        private void but_up_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show(this,"ff");
        }

        private void but_up_LocationChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this, "ff");
        }

    }

    //public class HeartBeatParameter
    //{

    //    public string hostIP { get; set; }

    //    public int second { get; set; }

    //    public int Status { get; set; }

    //    public string DeviceID { get; set; }

    //    public string DeviceUrl { get; set; }


    //}
}
