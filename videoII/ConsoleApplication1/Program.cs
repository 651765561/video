using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 在应用程序启动时运行的代码  
            //System.Timers.Timer myTimer = new System.Timers.Timer(1000);
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            //myTimer.Interval = 1000;
            //myTimer.Enabled = true;  

            Thread t = new Thread(WriteY);
            t.Start();
            t.IsBackground = true;
        }
        private static void WriteY()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(1000);
            }
           
        }
        private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
