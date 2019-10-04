using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace livedemo
{
    class Program
    {
        class Cat
        {
            public float Weight { get; set; }
            public float Height { get; set; }
            
        }

        

        static void Main(string[] args)
        {
            var timer = new Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Console.ReadKey();

            timer.Stop();
            timer.Dispose();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Event raised at: {0:hh:MM:ss}", e.SignalTime);
        }
    }
}
