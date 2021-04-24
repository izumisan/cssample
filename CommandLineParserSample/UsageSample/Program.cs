using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace UsageSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var parserResult = Parser.Default.ParseArguments<Options>( args );

            // ParserResultExtensions(WithParsed, WithNotParsed etc.)を利用せず、
            // パースしたオブジェクトを取得するサンプル
            if ( parserResult.Tag == ParserResultType.Parsed )
            {
                // パース成功時、ParserResut<T> を Parsed<T> にキャストすることでコンテンツを取得する
                var opt = ( parserResult as Parsed<Options> ).Value;

                Console.WriteLine( $"file: { opt.File }" );
                Console.WriteLine( $"enabled: { opt.Enabled }" );
            }
            else if ( parserResult.Tag == ParserResultType.NotParsed )
            {
                // パース失敗時、ParserResut<T> を NotParsed<T> にキャストすることでエラーコンテンツを取得する
                var err = ( parserResult as NotParsed<Options> ).Errors;

                err.ToList().ForEach( x => Console.WriteLine( x.ToString() ) );
            }
            else
            {
                // Nothing.
            }
        }
    }
}
