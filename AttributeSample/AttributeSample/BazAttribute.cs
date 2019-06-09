using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    /// <summary>
    /// メソッドを対象にしたBaz属性
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    public class BazAttribute : Attribute
    {
    }
}
