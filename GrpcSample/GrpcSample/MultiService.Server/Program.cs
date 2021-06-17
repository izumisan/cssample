using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace MultiService.Server
{
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            var server = new Grpc.Core.Server
            {
                Services =
                {
                    Foo1.BindService( new Foo1Service() ),
                    Foo2.BindService( new Foo2Service() )
                },
                Ports = { new ServerPort( "localhost", Port, ServerCredentials.Insecure ) }
            };
            server.Start();

            Console.WriteLine( $"MultiService.Server listening on port { Port }" );
            Console.WriteLine( "Press any key to stop server..." );
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
