using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using Udp.Shared;

namespace UdpReceiver
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "UdpReceiver (exit on received \"quit\")" );
            //var udp = new UdpClient( Constants.IpAddress, Constants.Port );  // Receiverなのでこれはダメ
            //var udp = new UdpClient( Constants.Port );  // 0.0.0.0:<port> でリッスンする（全アドレスリッスン）
            var address = IPAddress.Parse( Constants.IpAddress );
            var localEP = new IPEndPoint( address, Constants.Port );
            var udp = new UdpClient( localEP );

            Console.WriteLine( $"Listening... addr: { Constants.IpAddress }, port: { Constants.Port }" );

            while ( true )
            {
                IPEndPoint remoteEP = null;
                byte[] rdata = udp.Receive( ref remoteEP );

                var msg = Encoding.UTF8.GetString( rdata );
                Console.WriteLine( $"Rx: addr: { remoteEP.Address }, port: { remoteEP.Port }, msg: { msg }" );

                if ( msg.Equals( "quit" ) )
                {
                    break;
                }
            }

            udp.Close();
        }
    }
}
