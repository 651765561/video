using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace videoII
{
    public class VoiceControl
    {
        //动态链接库初始化
        [DllImport("libVoice.dll")]
        public static extern int VoiceTalk_Init();

        [DllImport("libVoice.dll")]
        public static extern int VoiceTalk_Start(string ip, string camera_id);

        [DllImport("libVoice.dll")]
        public static extern int VoiceTalk_Release();

        [DllImport("libVoice.dll")]
        public static extern int VoiceTalk_Stop();

        /// <summary>
        /// 语音初始化
        /// </summary>
        /// <returns></returns>
        public int Do_VoiceTalk_Init()
        {
            return VoiceTalk_Init();
        }

        /// <summary>
        /// 语音资源释放
        /// </summary>
        /// <returns></returns>
        public int Do_VoiceTalk_Release()
        {
            return VoiceTalk_Release();
        }

        /// <summary>
        /// 语音开始
        /// </summary>
        /// <param name="ip">服务ip</param>
        /// <param name="camera_id">相机设备编号</param>
        /// <returns></returns>
        public int Do_VoiceTalk_Start(string ip, string camera_id)
        {
            return VoiceTalk_Start(ip, camera_id);
        }

        /// <summary>
        /// 语音停止
        /// </summary>
        /// <returns></returns>
        public int Do_VoiceTalk_Stop()
        {
            return VoiceTalk_Stop();
        }
    }
}
