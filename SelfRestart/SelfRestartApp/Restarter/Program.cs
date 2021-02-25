using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;

namespace Restarter
{
    class Program
    {
        /// <summary>
        /// [Usage]
        /// > Restarter プログラムパス プロセスID
        /// </summary>
        /// <param name="args"></param>
        static void Main( string[] args )
        {
            Console.WriteLine( "Restarter" );

            string programPath = string.Empty;
            int processId = 0;

            if ( args.Count() == 2 )
            {
                programPath = args.ElementAt( 0 );
                processId = int.Parse( args.ElementAt( 1 ) );

                Restart( programPath, processId );
            }
        }

        private static void Restart( string path, int pid )
        {
            if ( File.Exists( path ) )
            {
                var monitorProcess = Process.GetProcesses().FirstOrDefault( p => p.Id == pid );
                if ( monitorProcess != null )
                {
                    Console.WriteLine( $"waiting... pid: { pid }" );
                    monitorProcess.WaitForExit( 60000 );  // 60000 msec = 60 sec
                }

                Process.Start( path );
            }
        }
    }
}
