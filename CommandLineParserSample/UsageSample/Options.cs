using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;
using CommandLine.Text;

namespace UsageSample
{
    public class Options
    {
        [Option( 'f', "file", HelpText = "input file path" )]
        public string File { get; set; } = string.Empty;

        [Option( 'e', "enabled", HelpText = "xxx mode enabled" )]
        public bool Enabled { get; set; } = false;

        // Usage属性のサンプル
        // - Usage属性は、static IEnumerable<Example> なプロパティに設定する
        // - この例の場合、以下のusageが表示される
        //
        // USAGE:
        // Convert foo.json.:
        //  UsageSample --file foo.json
        // Convert bar.json with xxx.:
        //  UsageSample --enabled --file bar.json
        //
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example( "Convert foo.json.", new Options { File = "foo.json" } );
                yield return new Example( "Convert bar.json with xxx.", new Options { File = "bar.json", Enabled = true } );
            }
        }
    }
}
