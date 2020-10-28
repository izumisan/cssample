using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace ProcessInfo
{
    class Program
    {
        static void Main( string[] args )
        {
            // 端末情報
            Debug.WriteLine( $"コンピュータ名: { Environment.MachineName }" );
            Debug.WriteLine( $"ユーザ名: { Environment.UserName }" );

            // プロセス情報
            var p = Process.GetCurrentProcess();
            Debug.WriteLine( $"プロセスID: { p.Id }" );
            Debug.WriteLine( $"プロセス名: { p.ProcessName }" );
            Debug.WriteLine( $"ファイル名; { p.MainModule.FileName }" );

            // 起動チェック
            Debug.WriteLine( $"ProcessInfo 実行中？: { Process.GetProcessesByName( "ProcessInfo" ).Any() }" );
            Debug.WriteLine( $"FooApp 実行中？: { Process.GetProcessesByName( "FooApp" ).Any() }" );
        }
    }
}
