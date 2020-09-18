using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NATS.Client;

namespace Requestor
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Requestor start..." );

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();

            Console.WriteLine( "connected." );

            while ( true )
            {
                Console.Write( "> " );

                var input = Console.ReadLine();
                if ( input != "quit" )
                {
                    var reply = connection.Request( "fizz.buzz", Encoding.UTF8.GetBytes( input ) );

                    Console.WriteLine( $"Reply: { reply }" );
                }
                else
                {
                    break;
                }
            }

            connection.Drain();
            connection.Close();
        }
    }
}
