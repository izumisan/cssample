using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample.Tests
{
    /// <summary>
    /// メソッドを対象としたBaz属性のテスト用クラス
    /// </summary>
    public class BazTestClass
    {
        [Baz]
        public void DoSomething()
        {
        }
    }
}
