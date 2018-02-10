using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace videoII
{

    public class PlayMp3
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand,
        string lpstrReturnString, uint uReturnLength, uint hWndCallback);

        public void StratPlay(string mp3FileName)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"open ");
            str.Append(@" "" ");
            // str.Append(@"F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3");
            str.Append(mp3FileName);
            str.Append(@" ""  ");
            //str.Append(@"""F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3"" ");
            str.Append("alias temp_alias");
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(str.ToString(), null, 0, 0);
            // mciSendString(@"open ""F:\Work\video（录像播放 马工）\videoII\videoII\gg.mp3"" alias temp_alias", null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);
        }

        public void StopPlay()
        {
            mciSendString(@"close temp_alias", null, 0, 0);
        }
    }
}
