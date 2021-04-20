using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace CommandLineParserSample2
{
    public class Options
    {
        [Option( 'f', "foo", HelpText = "Foo option" )]
        public string Foo { get; set; } = string.Empty;

        [Option( 'b', "bar", HelpText = "Bar option" )]
        public string Bar { get; set; } = string.Empty;

        // Value属性
        // オプション形式でない引数を受け取るための属性
        // IEnumerable<T>とすることで、オプション形式でない全ての引数を受け取る
        [Value( 0, HelpText = "Other options" )]
        public IEnumerable<string> Others { get; set; } = new List<string>();
    }
}
