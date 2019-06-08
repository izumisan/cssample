using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    [Foo("foo")]
    [Bar( "bar", Message = "めっせーじ", Value = 31, Lucky = true )]
    public class Class1
    {
    }
}
