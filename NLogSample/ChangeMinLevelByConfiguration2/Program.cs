using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NLog;

namespace ChangeMinLevelByConfiguration2
{
    class Program
    {
        static void Main( string[] args )
        {
            SetupConfiguration();

            ILogger logger = LogManager.GetCurrentClassLogger();
            logger.Info( "========== START ==========" );
            logger.Trace( "trace message" );
            logger.Debug( "debug message" );
            logger.Info( "info message" );
            logger.Warn( "warn message" );
            logger.Error( "error message" );
            logger.Fatal( "fatal message" );
            logger.Info( "==========  END  ==========" );
        }

        private static void SetupConfiguration()
        {
            LogManager.Configuration.Variables.Add( "debuglog", "ignore" );
            SetDebulogEnabled();
        }

        [Conditional( "DEBUG" )]
        private static void SetDebulogEnabled()
        {
            LogManager.Configuration.Variables["debuglog"] = "enabled";
        }
    }
}
