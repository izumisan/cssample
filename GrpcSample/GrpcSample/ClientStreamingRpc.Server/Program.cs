using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace ClientStreamingRpc.Server
{
    /// <summary>
    /// Client-side streaming RPC のサンプルプログラム（サーバー側）
    /// 
    /// クライアントからの複数リクエストに対し、1レスポンスを返す
    /// </summary>
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            var server = new Grpc.Core.Server
            {
                Services = { FooService.BindService( new FooServiceImpl() ) },
                Ports = { new ServerPort( "localhost", Port, ServerCredentials.Insecure ) }
            };
            server.Start();

            Console.WriteLine( $"ClientStreamingRpc.Server listening on port { Port }" );
            Console.WriteLine( "Press any key to stop server..." );
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
