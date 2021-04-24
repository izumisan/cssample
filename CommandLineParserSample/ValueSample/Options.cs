using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace ValueSample
{
    public class Options
    {
        // Value属性に指定するindexは、起動引数の位置を示すインデックスではなく
        // データの並び順を示す数値であり、連番である必要はない

        [Value( 0, HelpText = "1st option" )]
        public string First { get; set; } = string.Empty;

        [Value( 1, HelpText = "2nd option" )]
        public string Second { get; set; } = string.Empty;

        [Value( 2, HelpText = "3rd option" )]
        public string Third { get; set; } = string.Empty;

        [Value( 10, HelpText = "4th option" )]
        public string Fourth { get; set; } = string.Empty;

        // 5つ目以降全てを取得する
        [Value( 100, HelpText = "others" )]
        public IEnumerable<string> Others { get; set; }

        [Option( 'e', "enabled", HelpText = "enabled" )]
        public bool Enabled { get; set; } = false;
    }
}
