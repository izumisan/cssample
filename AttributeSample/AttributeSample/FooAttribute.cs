using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    /*
        自作属性クラスは、Attributeクラスを派生して作成する
        AttributeUsage属性で、自作属性の付与する対象を指定する
    */
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct )]
    public class FooAttribute : Attribute
    {
        public FooAttribute( string name )
        {
            Name = name;
        }

        public string Name { get; private set; } = string.Empty;
    }
}
