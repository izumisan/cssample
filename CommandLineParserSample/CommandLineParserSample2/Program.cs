using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace CommandLineParserSample2
{
    class Program
    {
        static void Main( string[] args )
        {
            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( opt =>
                {
                    if ( string.IsNullOrEmpty( opt.Foo ) != true )
                    {
                        Console.WriteLine( $"foo: { opt.Foo }" );
                    }
                    if ( string.IsNullOrEmpty( opt.Bar ) != true )
                    {
                        Console.WriteLine( $"bar: { opt.Bar }" );
                    }
                    if ( opt.Others.Any() )
                    {
                        Console.WriteLine( "[others]" );
                        opt.Others.ToList().ForEach( x => Console.WriteLine( x ) );
                    }

                    // e.g.
                    // > a.exe -f FOO -b BAR 1st 2nd 3rd
                    // 
                    // foo: FOO
                    // bar: BAR
                    // [others]
                    // 1st
                    // 2nd
                    // 3rd
                } )
                .WithNotParsed( _ => Console.WriteLine( "!!!parse error!!!" ) );
        }
    }
}
