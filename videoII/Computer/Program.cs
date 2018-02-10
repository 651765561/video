using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Computer
{
  public  class Program
    {
      
        static void Main(string[] args)
      {
          Console.Title = "获取计算机配置信息";
          Console.BackgroundColor = ConsoleColor.Green;
        
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Red; //设置字体颜色为红色 
            GetMemoryStatus();

 

            string val1 = HardDiskInfo();
           Console.WriteLine(val1);

         
         //var cpu=  pcCpuLoad.NextValue().ToString()+"%";
         //Console.WriteLine("cpu:" + cpu);
           //CPU频率
           ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
           foreach (ManagementObject MyObject in MySearcher.Get())
           {
               Console.WriteLine("CPU型号：" + MyObject.Properties["Name"].Value.ToString());
               Console.WriteLine("CPU频率：" + MyObject.Properties["CurrentClockSpeed"].Value.ToString());
           }
            //CPU使用率
           PerformanceCounter pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
           pcCpuLoad.NextValue();
           ParameterizedThreadStart p = new ParameterizedThreadStart(ThreadForCpuView);
           Thread newThread = new Thread(ThreadForCpuView);
           newThread.Start(pcCpuLoad);
        }


        private static void ThreadForCpuView(object obj)
        {
            PerformanceCounter pcCpuLoad = (PerformanceCounter)obj;
          
            while (true)
            {
                Thread.Sleep(1000);
                float cpuLoad = pcCpuLoad.NextValue();
                Console.WriteLine("CPU使用率:" + cpuLoad + "%");
            }
        }
        internal enum WmiType
        {
            Win32_Processor,
            Win32_PerfFormattedData_PerfOS_Memory,
            Win32_PhysicalMemory,
            Win32_NetworkAdapterConfiguration,
            Win32_LogicalDisk
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);
        public static void GetMemoryStatus()
        {
            MEMORY_INFO MemInfo;
            MemInfo = new MEMORY_INFO();
            GlobalMemoryStatus(ref MemInfo);

            double totalMb = double.Parse(MemInfo.dwTotalPhys.ToString()) / 1024 / 1024;
            double avaliableMb = double.Parse(MemInfo.dwAvailPhys.ToString()) / 1024 / 1024;

            Console.WriteLine("内存总量" + totalMb + " MB");
            Console.WriteLine("内存空闲" + avaliableMb + " MB");
        }
       
        /// <summary>
        /// 获取硬盘信息
        /// </summary>
        /// <returns></returns>
        public static string HardDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            StringBuilder sr = new StringBuilder();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    var val1 = (double)drive.TotalSize / 1024 / 1024/1024;
                    var val2 = (double)drive.TotalFreeSpace / 1024 / 1024/1024;
                    Console.WriteLine("DriveFormat:" + drive.DriveFormat + "drive.Name:" + drive.Name);
                    Console.WriteLine("磁盘总量:" + val1+"GB");
                    Console.WriteLine("磁盘空闲:" + val2 + "GB");
                    Console.WriteLine("==========================================");
                    sr.AppendFormat("{0}:{2}/{3}MB/{4}MB/{1}%可用;",
                        drive.Name,
                        string.Format("{0:F2}", val2 / val1 * 100),
                        drive.DriveFormat,
                        (long)val1,
                        (long)val2);
                }
            }
            return sr.ToString();
        }

       
    }
}
