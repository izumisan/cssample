using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ValidationAttributeSample2.ValidationAttributes
{
    /// <summary>
    /// ValidationAttributeのサブクラスの実装サンプル
    /// 
    /// bool ValidationAttribute.IsValid( object value )をオーバーライドしたバージョン
    /// </summary>
    public class FooAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            bool ret = false;
            int num = 0;
            if ( ( value is string ) && ( int.TryParse( value.ToString(), out num ) ) )
            {
                if ( num % 3 == 0 )
                {
                    ret = true;
                }
            }
            return ret;
        }
    }
}
