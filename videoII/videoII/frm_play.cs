using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace videoII
{
    public partial class frm_play : Form
    {
        ClientMediaSDK bb = new ClientMediaSDK();
        VoiceControl vc = new VoiceControl();
        int sessionID = 99990;
        int nn = 0;
        public frm_play()
        {
            InitializeComponent();
           
              var num = bb.Do_client_media_init(0);

             
        }

        private void but_Openvideo_Click(object sender, EventArgs e)
        {
         //  bb.Do_client_media_release();
            /*tcp连接；
             socket 句柄；
            Windows一个api: Send (socket  p)
             * ip:192.168.0.226
             * port:7554
             */
          
           // var ip = "rtsp://192.168.0.226/34020000001320397400";	//财务
       //    var ip = "rtsp://192.168.0.226/20000000001320000002";	//财务
          var ip = "rtsp://192.168.0.238/20000000001320000002";
          // var ip = "rtsp://192.168.0.238/20000000001320000003";
          ip = "rtsp://192.168.0.238/20000000001320000001";
          ip = "rtsp://192.168.0.238/20000000001320000002";
            var jubing = this.Handle;
             sessionID = bb.Do_client_media_realtime_open(ip, jubing, 0, -1);
          //var gg = bb.Do_client_media_realtime_close(sessionID);
          //sessionID = bb.Do_client_media_realtime_open(ip, jubing, 0, -1);
    
            var val = bb.Do_client_media_realtime_play(sessionID);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bb.Do_client_media_release();
            Application.Exit();
        }

        private void but_closevideo_Click(object sender, EventArgs e)
        {
            var gg = bb.Do_client_media_realtime_close(sessionID);
        }

        private void frm_play_Load(object sender, EventArgs e)
        {

        }

        

    }
}
