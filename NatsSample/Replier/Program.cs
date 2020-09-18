using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NATS.Client;

namespace Replier
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Replier start..." );

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();

            Console.WriteLine( "connected." );

            var subscription = connection.SubscribeAsync( "fizz.buzz" );
            subscription.MessageHandler += ( s, e ) =>
            {
                var msg = e.Message;
                Console.WriteLine( $"Recieved: { msg }" );

                var rdata = Encoding.UTF8.GetString( msg.Data );

                var reply = FizzBuzz( rdata );

                // 受信メッセージのReplyに指定されているSubjectに対して返信する
                var replyMsg = new Msg
                {
                    Subject = msg.Reply,
                    Data = Encoding.UTF8.GetBytes( reply )
                };
                connection.Publish( replyMsg );
                connection.Flush();
            };

            subscription.Start();

            Console.WriteLine( "Press any key to quit." );
            Console.ReadLine();

            connection.Drain();
            connection.Close();
        }

        private static string FizzBuzz( string value )
        {
            var ret = "invalid";
            int num = 0;
            if ( Int32.TryParse( value, out num ) )
            {
                if ( num % 15 == 0 )
                {
                    ret = "FizzBuzz";
                }
                else if ( num % 5 == 0 )
                {
                    ret = "Buzz";
                }
                else if ( num % 3 == 0 )
                {
                    ret = "Fizz";
                }
                else
                {
                    ret = num.ToString();
                }
            }
            return ret;
        }
    }
}
