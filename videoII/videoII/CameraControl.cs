using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace videoII
{
    public class CameraControl
    {
        Socket clientSocket = null;

        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="hostIP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string Login(string userId, string hostIP, int port)
        {
            if (clientSocket == null)
            {
                ConnectSocket(hostIP, port);
            }
            //string str = "";
            //用户id@接入服务IP
            string clientUrl = userId + "@" + hostIP;
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<Message>\r\n");
            // strBody.Append("<User>34020000003000000001@192.168.0.226</User>\r\n");
            strBody.Append("<User>" + clientUrl + "</User>\r\n");
            strBody.Append("<UserName>admin</UserName>\r\n");
            strBody.Append("<Password>admin</Password>\r\n");
            strBody.Append("<ClientType>1</ClientType>\r\n");
            strBody.Append("</Message>");

            /*协议头*/

            int len = strBody.ToString().Length;


            string strheader = GetAgreementHeader(1000, len);

            string contentStr = strheader + strBody.ToString();
            /*发送指令*/
            string sendStr = contentStr;
            byte[] sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            int num = clientSocket.Send(sendBytes);
            /*接收返回值*/
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recBytes, 0, bytes);
            // txt_Recevicecontext.Text += recStr + "/n/r";

            return recStr;
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
        /// <summary>
        /// socket连接
        /// </summary>
        /// <param name="hostIP"></param>
        /// <param name="port"></param>
        public void ConnectSocket(string hostIP, int port)
        {
            //int port = port;
            //string host = hostIP;//服务器端ip地址
            //host = txtIp.Text.Trim();
            //port = int.Parse(txtPort.Text);

            IPAddress ip = IPAddress.Parse(hostIP);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

             clientSocket.Connect(ipe);
        }

        /// <summary>
        /// 定时执行心跳方法
        /// </summary>
        /// <param name="second">间隔时间</param>
        public void heartbeat(HeartBeatParameter second)
        {
            HeartBeatParameter obj = second;
            if (clientSocket == null)
            {
                ConnectSocket(obj.hostIP, obj.port);
            }
            while (true)
            {
                /*协议体*/
                StringBuilder strBody = new StringBuilder();

                strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
                strBody.Append("<Message>\r\n");
                //   strBody.Append("<DeviceID>34020000003000000001@192.168.0.226</DeviceID>\r\n");
                strBody.Append("<DeviceID>" + obj.UserID + "</DeviceID>\r\n");
                strBody.Append("<Status>" + obj.Status + "</Status>\r\n");
                strBody.Append("</Message>\r\n");

                /*协议头*/
                int len = strBody.ToString().Length;
               
                string strheader = GetAgreementHeader(1002, len);
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
             

                Thread.Sleep(1000 * obj.second);
            }
        }

        /// <summary>
        /// 定时执行心跳方法
        /// </summary>
        /// <param name="second">间隔时间</param>
        public string  heartbeatII(HeartBeatParameter obj)
        {
            if (clientSocket == null)
            {
                ConnectSocket(obj.hostIP, obj.port);
            }
           
                /*协议体*/
                StringBuilder strBody = new StringBuilder();

                strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
                strBody.Append("<Message>\r\n");
                //   strBody.Append("<DeviceID>34020000003000000001@192.168.0.226</DeviceID>\r\n");
                strBody.Append("<DeviceID>" + obj.UserID + "</DeviceID>\r\n");
                strBody.Append("<Status>" + obj.Status + "</Status>\r\n");
                strBody.Append("</Message>\r\n");

                /*协议头*/
                int len = strBody.ToString().Length;

                string strheader = GetAgreementHeader(1002, len);
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
        /// <summary>
        /// 云镜控制
        /// </summary>
        /// <param name="p">云镜控制参数</param>
        /// <returns></returns>
        public string CloudMirrorControl(CloudMirrorParameter p)
        {
            if (clientSocket == null)
            {
                ConnectSocket(p.hostIP,p.port);
            }
            string str = "";
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            strBody.Append("<Message>\r\n");
           // strBody.Append("<User>34020000003000000001@192.168.0.226</User>\r\n");
            strBody.Append("<User>"+p.UserUrl+"</User>\r\n");
          //  strBody.Append("<Camera>20000000001320000002@192.168.0.226</Camera>\r\n");
            strBody.Append("<Camera>"+p.CameraUrl+"</Camera>\r\n");
          //  strBody.Append("<PTZCmd>0</PTZCmd>\r\n");
            strBody.Append("<PTZCmd>"+p.PTZCmd+"</PTZCmd>\r\n");
          //  strBody.Append("<Param>5</Param>\r\n");
            strBody.Append("<Param>"+p.Param+"</Param>\r\n");
         //   strBody.Append("<Stop>0</Stop>\r\n");
            strBody.Append("<Stop>"+p.Stop+"</Stop>\r\n");
           // strBody.Append("<Priority>0</Priority>\r\n");
            strBody.Append("<Priority>"+p.Priority+"</Priority>\r\n");
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

        
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="p">相机退出参数</param>
        /// <returns></returns>
        public string SignOut(SignOutParameter p)
        {
            if (clientSocket == null)
            {
                ConnectSocket(p.hostIP, p.port);
            }
            /*协议体*/
            StringBuilder strBody = new StringBuilder();
            strBody.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
           // strBody.Append("<User>34020000003000000001@192.168.0.226</User>");
            strBody.Append("<Message>");
            strBody.Append("<User>"+p.UserUrl+"</User>");
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
            return recStr;
        }

    }

    public class SignOutParameter {
        public int port { get; set; }
        public string hostIP { get; set; }
        public string UserId { get; set; }
        public string UserUrl { get; set; }
    }
    
    /// <summary>
    /// 云镜控制参数
    /// </summary>
    public class CloudMirrorParameter
    {
        public int port { get; set; }
        public string hostIP { get; set; }
        public string UserId { get; set; }
        public string UserUrl { get; set; }
        public string CameraID { get; set; }
        public string CameraUrl { get; set; }
        /// <summary>
        /// 动作参数
        /// </summary>
        public int PTZCmd { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public int Param { get; set; }
        /// <summary>
        /// 启停 0：开始，1：停止
        /// </summary>
        public int Stop { get; set; }
        /// <summary>
        /// 用户优先级(默认0)
        /// </summary>
        public int Priority { get; set; }

    }
    /// <summary>
    /// 心跳参数
    /// </summary>
    public class HeartBeatParameter
    {
        public int port { get; set; }
        public string hostIP { get; set; }

        public int second { get; set; }

        public int Status { get; set; }

        public string UserID { get; set; }

        public string CameraUrl { get; set; }


    }
}
