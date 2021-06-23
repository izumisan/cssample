using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace Calculator.Server
{
    /// <summary>
    /// 1サービスに複数メソッドを定義したサンプルプログラム（サーバー側）
    /// </summary>
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            var server = new Grpc.Core.Server
            {
                Services = { Calculator.BindService( new CalculatorService() ) },
                Ports = { new ServerPort( "localhost", Port, ServerCredentials.Insecure ) }
            };
            server.Start();

            Console.WriteLine( $"CalculatorService listening on port { Port }" );
            Console.WriteLine( "Press any key to stop server..." );
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }
}
