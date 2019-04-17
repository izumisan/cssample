using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsShared;

namespace CsWriter
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "<<< Quit on press Enter key >>>" );

            bool exitFlag = false;
            var task = Task.Run( () =>
            {
                var shm = new SharedMemory();
                var wdata = new Foo();

                int count = 0;
                while ( exitFlag != true )
                {
                    wdata._count = count;
                    wdata._value = count + 0.777;
                    wdata._lucky = ( count % 2 == 0 );
                    wdata._name = "ABCDEFG";
                    for ( int i = 0; i < wdata._array.Count(); ++i )
                    {
                        wdata._array[i] = count + i;
                    }

                    shm.write( wdata );

                    Console.WriteLine( $"write: { count }" );

                    Task.Delay( 1000 ).Wait();
                    ++count;
                }

                wdata._exitFlag = true;
                shm.write( wdata );
            } );

            Console.ReadLine();

            exitFlag = true;

            Task.WaitAll( task );
        }
    }
}
