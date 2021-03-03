# 
# 引数で指定したプログラムを起動するスクリプト
#
# > restarter.ps1 path/to/program processId
#
Param( [string] $path, [int] $processId )
Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$cscode = @'
using System;
using System.Linq;
using System.IO;
using System.Diagnostics;

public static class Restarter
{
    public static void Restart( string path, int pid )
    {
        if ( File.Exists( path ) )
        {
            var monitorProcess = Process.GetProcesses().FirstOrDefault( p => p.Id == pid );
            if ( monitorProcess != null )
            {
                Console.WriteLine( "waiting... pid: " + pid );
                monitorProcess.WaitForExit( 10000 );  // 10000 msec = 10 sec
            }

            Process.Start( path );
        }
        else
        {
            Console.WriteLine( "File NOT found! path: " + path );
        }
    }
}
'@

Add-Type -TypeDefinition $cscode -Language CSharp 

[Restarter]::Restart( $path, $processId )
