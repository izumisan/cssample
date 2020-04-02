using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Markup;

namespace MarkupExtensionSample
{
    public class FizzBuzzMarkup1Extension : MarkupExtension
    {
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return "Fizz Buzz";
        }
    }
}
