using System;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Restarter
{
    public static class Restarter
    {
        public static void Restart( string path, int pid )
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
