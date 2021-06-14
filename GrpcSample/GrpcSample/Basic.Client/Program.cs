using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace Basic.Client
{
    class Program
    {
        static void Main( string[] args )
        {
            Channel channel = new Channel( "127.0.0.1:5678", ChannelCredentials.Insecure );

            var client = new Basic.FooService.FooServiceClient( channel );

            var reply = client.Foo( new FooRequest { Value = "FOO" } );
            Console.WriteLine( reply.Value );

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
