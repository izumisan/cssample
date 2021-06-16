using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

// gRPCクライアント側プログラム
//
// 1. `Grpc.Core.Channel`を生成し、コネクションを確立する
// 2. protoファイルより自動生成された`FooService.FooServiceClient`を介して、
//    関数をリモート実行する

namespace Basic.Client
{
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            Channel channel = new Channel( $"127.0.0.1:{ Port }", ChannelCredentials.Insecure );

            var client = new Basic.FooService.FooServiceClient( channel );

            var reply = client.Foo( new FooRequest { Value = "FOO" } );
            Console.WriteLine( reply.Value );

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
