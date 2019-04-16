using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsShared;

namespace CsReader
{
    class Program
    {
        static void Main( string[] args )
        {
            var shm = new SharedMemory();

            var rdata = new Foo();

            while ( rdata._exitFlag == false )
            {
                shm.read( ref rdata );

                Console.WriteLine( $"count: { rdata._count }, value: { rdata._value }, array[511]: { rdata._array[511] }" );

                Task.Delay( 1000 ).Wait();
            }
        }
    }
}
