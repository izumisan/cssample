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
            var connection = factory.CreateConnection();

            Console.WriteLine( "connected." );

            // Subscribe時にQueueGroup名を指定すると、
            // 同じQueueGroup名の有するサブスクライバーのうち、
            // ランダムで1つのサブスクライバーのみメッセージを受け取る
            string queueGroup = "foo-group";
            var subscription = connection.SubscribeAsync( "foo.bar", queueGroup );

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
