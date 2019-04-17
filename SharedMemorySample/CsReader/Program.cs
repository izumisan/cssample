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

                Console.Write( $"count: { rdata._count }, " );
                Console.Write( $"value: { rdata._value }, " );
                Console.Write( $"lucky: { rdata._lucky }, " );
                Console.Write( $"name: { rdata._name }, " );
                Console.WriteLine( $"array[7]: { rdata._array[7] }" );

                Task.Delay( 1000 ).Wait();
            }
        }
    }
}
