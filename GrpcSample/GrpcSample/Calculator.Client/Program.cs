using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace Calculator.Client
{
    /// <summary>
    /// 1サービスに複数メソッドを定義したサンプルプログラム（クライアント側）
    /// </summary>
    class Program
    {
        public static int Port => 27182;

        static void Main( string[] args )
        {
            Channel channel = new Channel( $"127.0.0.1:{ Port }", ChannelCredentials.Insecure );

            var client = new Calculator.CalculatorClient( channel );

            {
                var reply = client.Plus( new CalculatorRequest { Arg1 = 1.1, Arg2 = 2.2 } );
                Console.WriteLine( $"{ reply.Arg1 } + { reply.Arg2 } = { reply.Result }" );
            }
            {
                var reply = client.Minus( new CalculatorRequest { Arg1 = 1.2, Arg2 = 3.3 } );
                Console.WriteLine( $"{ reply.Arg1 } - { reply.Arg2 } = { reply.Result }" );
            }
            {
                var reply = client.Multiply( new CalculatorRequest { Arg1 = 1.3, Arg2 = 4.4 } );
                Console.WriteLine( $"{ reply.Arg1 } * { reply.Arg2 } = { reply.Result }" );
            }
            {
                var reply = client.Devide( new CalculatorRequest { Arg1 = 1.4, Arg2 = 5.5 } );
                Console.WriteLine( $"{ reply.Arg1 } / { reply.Arg2 } = { reply.Result }" );
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
}
