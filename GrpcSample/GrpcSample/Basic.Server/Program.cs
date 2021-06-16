using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

// gRPCサーバー側プログラム
// 
// 1. protoファイルより自動生成された`FooService.FooServiceBase`を継承したサービスクラスを実装する
// 2. 作成したサービスクラスを`Grpc.Core.Server`に登録する

namespace Basic.Server
{
    class Program
    {
        public static int Port => 27182;  // 適当

        static void Main( string[] args )
        {
            // `Grpc.Core.Server`クラスに、作成したサービスクラスを登録する
            var server = new Grpc.Core.Server
            {
                Services = { FooService.BindService( new FooServiceImpl() ) },
                Ports = { new ServerPort( "localhost", Port, ServerCredentials.Insecure ) }
            };
            server.Start();

            Console.WriteLine( $"FooService listening on port { Port }" );
            Console.WriteLine( "Press any key to stop server..." );
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
