using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; // 用 DllImport 需用此 命名空间

namespace videoII
{
    public class ClientMediaSDK
    {
        //动态链接库初始化
        [DllImport("ClientMediaSDK.dll")]
        public static extern int client_media_init(int hWnd);
        public int Do_client_media_init(int hWnd)
        {
            return client_media_init(hWnd);
        }

        //动态链接库初始化
        [DllImport("ClientMediaSDK.dll")]
        public static extern int client_media_realtime_open(string url, IntPtr hWnd, int callback, int callbackID);
        //  private static extern int LED_Startup();
        //动态链接库初始化
        [DllImport("ClientMediaSDK.dll")]
        public static extern int client_media_realtime_play(int sessionID);

        //动态链接库初始化
        [DllImport("ClientMediaSDK.dll")]
        public static extern int client_media_release();

          //动态链接库初始化
        [DllImport("ClientMediaSDK.dll")]
        public static extern int client_media_realtime_close(int sessionId);
        

        public int Do_client_media_realtime_open(string url, IntPtr hWnd, int callback, int callbackId)
        {
            return client_media_realtime_open(url, hWnd, callback, callbackId);
        }
        public int Do_client_media_realtime_play(int sessionID)
        {
            return client_media_realtime_play(sessionID);
        }

        public int Do_client_media_release() { 
            return client_media_release(); 
        }

        public  int Do_client_media_realtime_close(int sessionID){
            return client_media_realtime_close(sessionID);
        }
    }
}
