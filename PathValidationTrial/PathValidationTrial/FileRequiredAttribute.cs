using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PathValidationTrial
{
    public class FileRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid( object value )
        {
            return base.IsValid( value ) && File.Exists( value.ToString() );
        }
    }
}
