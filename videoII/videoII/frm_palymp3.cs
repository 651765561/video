using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace videoII
{
    public partial class frm_palymp3 : Form
    {
        PlayMp3 bll = new PlayMp3();

        
    
    public void theout(object source, System.Timers.ElapsedEventArgs e)   
     {   
        MessageBox.Show("OK!");   
     }
        public frm_palymp3()
        {
            InitializeComponent();

            //Thread t = new Thread(WriteY);
            //t.Start();
            //t.IsBackground = true;
           
        }
        private  void WriteY()
        {
            while (true)
            {
                string path = Application.StartupPath + @"\bk.mp3";
                bll.StratPlay(path);
                //label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //Thread.Sleep(1000);
            }

        }
        private void but_playMp3_Click(object sender, EventArgs e)
        {
           
            string path = Application.StartupPath + @"\gg.mp3";
            bll.StratPlay(path);
        
        }

        private void but_stop_Click(object sender, EventArgs e)
        {
            //StopPlay();
           // mciSendString(@"close temp_alias", null, 0, 0);
           // mciSendString(@"close ""F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3"" alias temp_alias", null, 0, 0);
            bll.StopPlay();
        }

        private void frm_palymp3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string path = Application.StartupPath + @"\bk.mp3";
            //bll.StratPlay(path);
        }

        //public void StopPlay()
        //{
        //    mciSendString(@"close temp_alias", null, 0, 0);
        //}

        //public void StratPlay(string mp3FileName) {
        //    StringBuilder str = new StringBuilder();
        //    str.Append(@"open ");
        //    str.Append(@" "" ");
        //   // str.Append(@"F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3");
        //    str.Append(mp3FileName);
        //    str.Append(@" ""  ");
        //    //str.Append(@"""F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3"" ");
        //    str.Append("alias temp_alias");
        //    mciSendString(@"close temp_alias", null, 0, 0);
        //    mciSendString(str.ToString(), null, 0, 0);
        //    // mciSendString(@"open ""F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3"" alias temp_alias", null, 0, 0);
        //    mciSendString("play temp_alias repeat", null, 0, 0); 
        //}


    }
}
