using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Markup;

namespace MarkupExtensionSample
{
    public class FizzBuzzMarkup2Extension : MarkupExtension
    {
        public int Value { get; set; } = 0;

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            var ret = 0.ToString();
            if ( 0 < Value )
            {
                if ( Value % 15 == 0 )
                {
                    ret = "FizzBuzz";
                }
                else if ( Value % 5 == 0 )
                {
                    ret = "Buzz";
                }
                else if ( Value % 3 == 0 )
                {
                    ret = "Fizz";
                }
                else
                {
                    ret = Value.ToString();
                }
            }
            return ret;
        }
    }
}
