using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NATS.Client;

namespace Publisher
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Publisher start..." );

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();

            Console.WriteLine( "connected." );

            int count = 0;
            while ( true )
            {
                ++count;
                Console.Write( $"{ count.ToString() }: " );

                var input = Console.ReadLine();
                if ( input != "quit" )
                {
                    connection.Publish( "foo.bar", Encoding.UTF8.GetBytes( input ) );
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
