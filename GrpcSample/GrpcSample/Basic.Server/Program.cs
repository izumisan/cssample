﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;

namespace Basic.Server
{
    class Program
    {
        public static int Port => 5678;  // 適当

        static void Main( string[] args )
        {
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
