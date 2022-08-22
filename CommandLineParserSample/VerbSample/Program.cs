/*
    Verb属性のサンプルプログラム

////////////////////////////////////////////////////////////////////////////////
> VerbSample.exe --help

  sub1       (Default Verb) sub command 1

  sub2       sub command 2

  help       Display more information on a specific command.

  version    Display version information.

////////////////////////////////////////////////////////////////////////////////
> VerbSample.exe sub1 --help

  --arg1       sub1 arg text. e.g. foo

  --arg2       sub1 arg text. e.g. bar

  --help       Display this help screen.

  --version    Display version information.

////////////////////////////////////////////////////////////////////////////////
> VerbSample.exe sub2 --help

  --arg1       sub2 arg num. e.g. 123

  --arg2       sub2 arg num. e.g. 456

  --help       Display this help screen.

  --version    Display version information.

////////////////////////////////////////////////////////////////////////////////
# 実行例

> VerbSample.exe sub1 --arg1=aaa --arg2=bbb
sub1: { arg1: aaa, arg2: bbb }

# sub1はdefault指定しているので、省略可能
> VerbSample.exe --arg1=aaa --arg2=bbb
sub1: { arg1: aaa, arg2: bbb }

> VerbSample.exe sub2 --arg1=aaa --arg2=bbb
ERROR(S):
  Option 'arg1' is defined with a bad format.
  Option 'arg2' is defined with a bad format.

  --arg1       sub2 arg num. e.g. 123

  --arg2       sub2 arg num. e.g. 456

  --help       Display this help screen.

  --version    Display version information.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace VerbSample
{
    class Program
    {
        static void Main( string[] args )
        {
            Parser.Default.ParseArguments<Sub1Options, Sub2Options>( args )
                .WithParsed<Sub1Options>( opt =>
                {
                    Console.WriteLine( $"sub1: {{ arg1: { opt.Arg1 }, arg2: { opt.Arg2 } }}" );
                } )
                .WithParsed<Sub2Options>( opt =>
                {
                    Console.WriteLine( $"sub2: {{ arg1: { opt.Arg1 }, arg2: { opt.Arg2 } }}" );
                } )
                .WithNotParsed( err =>
                {
                    // Nothing.
                    // (最低限のエラーメッセージは自動で出力される)
                } );
        }
    }
}
