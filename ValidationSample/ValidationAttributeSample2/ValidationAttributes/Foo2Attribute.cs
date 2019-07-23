using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ValidationAttributeSample2.ValidationAttributes
{
    /// <summary>
    /// ValidationAttributeのサブクラスの実装サンプル
    /// 
    /// ValidationResult ValidationAttribute.IsValid( object value, ValidationContext validationContext )
    /// をオーバーライドしたバージョン
    /// </summary>
    public class Foo2Attribute : ValidationAttribute
    {
        // 両方定義した場合、bool IsValid( object value )は呼ばれないっぽい...?

        //public override bool IsValid( object value )
        //{
        //    Trace.WriteLine( "bool IsValid( object value )" );

        //    bool ret = false;
        //    int num = 0;
        //    if ( ( value is string ) && ( int.TryParse( value.ToString(), out num ) ) )
        //    {
        //        if ( num % 3 == 0 )
        //        {
        //            ret = true;
        //        }
        //    }
        //    return ret;
        //}

        protected override ValidationResult IsValid( object value, ValidationContext validationContext )
        {
            Trace.WriteLine( "ValidationResult IsValid( object value, ValidationContext validationContext )" );

            var ret = ValidationResult.Success;
            int num = 0;
            if ( ( value is string ) && ( int.TryParse( value.ToString(), out num ) ) )
            {
                if ( num % 3 != 0 )
                {
                    ret = new ValidationResult( ErrorMessage );
                }
            }
            return ret;
        }
    }
}
