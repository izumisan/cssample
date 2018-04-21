using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace NLogSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var logger = LogManager.GetCurrentClassLogger();
            var logger1 = LogManager.GetLogger( @"logger1" );
            var logger2 = LogManager.GetLogger( @"logger2" );

            logger.Info( @"logger" );
            logger1.Info( @"logger1" );
            logger2.Info( @"logger2" );
        }
    }
}
