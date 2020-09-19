using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NATS.Client;

namespace Subscriber
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Subscriber start..." );

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();  // URLを省略した場合、localhost:4222 でコネクト

            Console.WriteLine( "connected." );

            var subscription = connection.SubscribeAsync( "foo.bar" );
            subscription.MessageHandler += ( s, e ) =>
            {
                Console.WriteLine( $"Recieved: { e.Message }" );
            };

            subscription.Start();

            Console.WriteLine( "Press any key to quit." );
            Console.ReadLine();

            connection.Drain();
            connection.Close();
        }
    }
}
