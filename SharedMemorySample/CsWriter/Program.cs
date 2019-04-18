using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using CsShared;

namespace CsWriter
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "<<< Quit on press Enter key >>>" );

            using ( var shm = new SharedMemory() )
            {
                var wdata = new Foo();

                var source = Observable.Interval( TimeSpan.FromSeconds( 1 ) );

                var writer = source.Subscribe( n =>
                {
                    wdata._count = (int)n;
                    wdata._value = n + 0.777;
                    wdata._lucky = ( n % 2 == 0 );
                    wdata._name = "ABCDEFG";
                    for ( int i = 0; i < wdata._array.Length; ++i )
                    {
                        wdata._array[i] = (int)( n + i );
                    }

                    shm.write( wdata );

                    Console.WriteLine( $"write: { n }" );
                } );

                Console.ReadLine();

                wdata._exitFlag = true;
                shm.write( wdata );

                writer.Dispose();
            }
        }
    }
}
