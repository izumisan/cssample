using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

namespace VerbSample
{
    /// <summary>
    /// サブコマンド1
    /// </summary>
    [Verb( "sub1", isDefault: true, HelpText = "sub command 1" )]
    public class Sub1Options
    {
        [Option( "arg1", HelpText = "sub1 arg text. e.g. foo" )]
        public string Arg1 { get; set; } = string.Empty;

        [Option( "arg2", HelpText = "sub1 arg text. e.g. bar" )]
        public string Arg2 { get; set; } = string.Empty;
    }

    /// <summary>
    /// サブコマンド2
    /// </summary>
    [Verb( "sub2", HelpText = "sub command 2" )]
    public class Sub2Options
    {
        [Option( "arg1", HelpText = "sub2 arg num. e.g. 123" )]
        public int Arg1 { get; set; } = 0;

        [Option( "arg2", HelpText = "sub2 arg num. e.g. 456" )]
        public int Arg2 { get; set; } = 0;
    }
}
