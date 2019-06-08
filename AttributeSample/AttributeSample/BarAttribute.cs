using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    /*
        AllowMultipleにtrueを指定した場合、
        同じ対象に属性を複数指定することができるようになる

        Inheritedにtrueを指定した場合、
        クラス継承時、属性値も継承されるようになる
    */
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true )]
    public class BarAttribute : Attribute
    {
        public BarAttribute( string name )
        {
            Name = name;
        }

        public string Name { get; private set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Value { get; set; } = 0;
        public bool Lucky { get; set; } = false;
    }
}
