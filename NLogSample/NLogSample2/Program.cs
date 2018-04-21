using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace NLogSample2
{
    class Program
    {
        static void Main( string[] args )
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Factory.Configuration.Variables.Add( @"logFileName", @"aaa" );

            logger.Info( @"info" );
        }
    }
}
