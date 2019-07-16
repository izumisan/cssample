using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TimerSample
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("start...");
            Debug.WriteLine( $"Main thread id: { System.Threading.Thread.CurrentThread.ManagedThreadId }" );

            var timer = new System.Timers.Timer( 1000.0 );
            int count = 0;
            timer.Elapsed += ( s, e ) =>
            {
                ++count;
                var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine( $"{ e.SignalTime.ToString( "HH:mm:ss.fff" ) }, count:{ count }, id:{ id }" );
            };

            timer.Start();

            Console.WriteLine("Press any key...");
            Console.ReadLine();

            timer.Stop();
            timer.Dispose();
            Console.WriteLine( "end." );
        }
    }
}
