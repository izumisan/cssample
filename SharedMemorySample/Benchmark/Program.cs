using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsShared;
using System.Diagnostics;

namespace Benchmark
{
    class Program
    {
        static void Main( string[] args )
        {
            using ( var writer = new SharedMemory() )
            using ( var reader = new SharedMemory() )
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                int loopCount = 1000000;
                for ( int i = 0; i < loopCount; ++i )
                {
                    var foo = new Foo();
                    reader.read( ref foo );
                    ++foo._count;
                    writer.write( foo );
                }
                stopwatch.Stop();

                Console.WriteLine( $"total: { stopwatch.ElapsedMilliseconds } [msec]" );
                Console.WriteLine( $"average: { (double)stopwatch.ElapsedMilliseconds / (double)loopCount / 2.0 * 1000.0 } [usec]" );
            }

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
