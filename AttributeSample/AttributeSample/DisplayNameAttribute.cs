using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    [AttributeUsage( AttributeTargets.Field )]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute( string displayName )
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; private set; } = string.Empty;
    }
}
