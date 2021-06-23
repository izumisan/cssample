using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ClientStreamingRpc.Client
{
    /// <summary>
    /// Client-side streaming RPC のサンプルプログラム（クライアント側）
    /// 
    /// 複数リクエストに対し、サーバーから1レスポンスを得る
    /// </summary>
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            Channel channel = new Channel( $"127.0.0.1:{ Port }", ChannelCredentials.Insecure );
            var client = new FooServiceClient( new FooService.FooServiceClient( channel ) );

            var requests = new List<FooRequest>();
            for ( int i = 0; i < 10; ++i )
            {
                requests.Add( new FooRequest { Value = i } );
            }

            var task = client.Total( requests );
            task.Wait();
            Console.WriteLine( $"total: { task.Result.Value }" );
            

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
