using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace MultiService.Client
{
    /// <summary>
    /// 複数サービスを有するgRPCサーバーを利用するクライアント側プログラム
    /// </summary>
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            Channel channel = new Channel( $"127.0.0.1:{ Port }", ChannelCredentials.Insecure );

            var client1 = new Foo1.Foo1Client( channel );
            var client2 = new Foo2.Foo2Client( channel );

            {
                var reply = client1.Foo( new FooRequest { Value = 11 } );
                Console.WriteLine( $"foo1: { reply.Value }" );
            }
            {
                var reply = client1.Foo( new FooRequest { Value = 22 } );
                Console.WriteLine( $"foo1: { reply.Value }" );
            }
            {
                var reply = client2.Foo( new FooRequest { Value = 33 } );
                Console.WriteLine( $"foo2: { reply.Value }" );
            }
            {
                var reply = client2.Foo( new FooRequest { Value = 44 } );
                Console.WriteLine( $"foo2: { reply.Value }" );
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
