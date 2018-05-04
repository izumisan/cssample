using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ReactivePropertySample3
{
    public class IntValidationAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            //return base.IsValid( value );
            return int.TryParse( value as string, out _ );
        }
    }
}
