using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using Udp.Shared;

namespace UdpSender
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "UdpSender (exit if input \"quit\")" );
            //var udp = new UdpClient();  // [1]
            var udp = new UdpClient( Constants.IpAddress, Constants.Port );  // [2]

            while ( true )
            {
                Console.Write( "> " );
                var input = Console.ReadLine();
                var bytes = Encoding.UTF8.GetBytes( input );

                // UdpClientのコンストラクタでアドレスポートを指定していない場合(see. [1])
                //udp.Send( bytes, bytes.Length, Constants.IpAddress, Constants.Port );

                // UdpClientのコンストラクタでアドレス、ポート番号を指定している場合 (see. [2])
                udp.Send( bytes, bytes.Length );

                if ( input.Equals( "quit" ) )
                {
                    break;
                }
            }

            udp.Close();
        }
    }
}
