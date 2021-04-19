using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace CommandLineParserSample
{
    public class CommandLineOptions
    {
        // Option属性に起動オプションを設定する
        //
        // - このサンプルの場合、以下のオプションが有効となる
        //   "-f path/to/file"
        //   "--file path/to/file"
        //   "--file=path/to/file"
        //
        // - "--version"と"--help"は、自動的に定義されるっぽい
        [Option( 'f', "file", Required = true, HelpText = "設定ファイルパス" )]
        public string File { get; set; } = string.Empty;
    }
}
