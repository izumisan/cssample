using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace CommandLineParserSample
{
    class Program
    {
        static void Main( string[] args )
        {
            Parser.Default.ParseArguments<CommandLineOptions>( args )
                .WithParsed( opt =>
                {
                    // 起動引数のパースに成功した場合の処理

                    Console.WriteLine( $"file: { opt.File }" );
                } )
                .WithNotParsed( err =>
                {
                    // 起動引数のパースに失敗した場合の処理

                    // 本例では CommandLineOptionsで --file オプションを Required 指定しているので、
                    // 引数なしで起動した場合はパース失敗扱いになり、以下のテキストが表示される.
                    // ちなみに、--help や --version といったデフォルトで自動的に付加されるオプション
                    // を指定した場合もパース失敗扱いになり、このブロック部分が実行される.
                    /*
                    ERROR(S):
                      Required option 'f, file' is missing.

                      -f, --file    Required. 設定ファイルパス

                      --help        Display this help screen.

                      --version     Display version information.

                    !!! Illegal arguments !!!
                    */

                    Console.WriteLine( "!!! Illegal arguments !!!" );
                } );
        }
    }
}
