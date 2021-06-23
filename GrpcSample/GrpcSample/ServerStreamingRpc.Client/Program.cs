using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ServerStreamingRpc.Client
{
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            Channel channel = new Channel( $"127.0.0.1:{ Port }", ChannelCredentials.Insecure );
            var client = new FooServiceClient( new FooService.FooServiceClient( channel ) );

            var task = client.GetFooList( 123 );
            task.Wait();
            foreach ( var item in task.Result )
            {
                Console.WriteLine( item );
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
