using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TimerSample2
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "start..." );
            Debug.WriteLine( $"Main thread id: { System.Threading.Thread.CurrentThread.ManagedThreadId }" );

            int count = 0;

            System.Threading.TimerCallback callback = state =>
            {
                ++count;
                var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine( $"{ DateTime.Now.ToString( "HH:mm:ss.fff" ) }, count:{ count }, id:{ id }" );
            };
            var timer = new System.Threading.Timer( callback, null, 0, 1000 );

            Console.WriteLine( "Press any key..." );
            Console.ReadLine();

            timer.Dispose();
            Console.WriteLine( "end." );
        }
    }
}
