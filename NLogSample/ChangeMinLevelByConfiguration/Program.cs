using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NLog;

namespace ChangeMinLevelByConfiguration
{
    class Program
    {
        static void Main( string[] args )
        {
            SetOutLogTrace();
            
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

        [Conditional("DEBUG")]
        static void SetOutLogTrace()
        {
            // configファイルで設定している
            // < logger name = "*" minlevel = "Info" writeTo = "f" />
            // のルールのminlevel="Info"を"Trace"相当となるように書き換える
            var rule = LogManager.Configuration.LoggingRules[0];
            rule.EnableLoggingForLevels( LogLevel.Trace, LogLevel.Fatal );
        }
    }
}
