using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udp.Shared
{
    public class Constants
    {
        public static string IpAddress => "127.0.0.1";  // localhost は IPAddress.Parse() で例外となる
        public static int Port => 35824;
    }
}
