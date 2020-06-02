using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;

namespace Converter
{
    public class FizzBuzzConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var ret = string.Empty;
            if ( value.GetType() == typeof( double ) )
            {
                int val = (int)( (double)value );
                if ( val % 15 == 0 )
                {
                    ret = "Fizz Buzz";
                }
                else if ( val % 5 == 0 )
                {
                    ret = "Buzz";
                }
                else if ( val % 3 == 0 )
                {
                    ret = "Fizz";
                }
                else
                {
                    ret = val.ToString();
                }
            }
            return ret;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
