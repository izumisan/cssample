using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample.Tests
{
    /// <summary>
    /// Bar属性を指定したテスト用クラス
    /// </summary>
    [Bar( "bar1", Message = "めっせーじ1", Value = 31, Lucky = true )]
    [Bar( "bar2", Message = "めっせーじ2", Value = 32, Lucky = true )]
    public class BarTestClass
    {
    }
}
