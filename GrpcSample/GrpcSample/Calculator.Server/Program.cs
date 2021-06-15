using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace Calculator.Server
{
    class Program
    {
        public static int Port => 5678;

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
