using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Markup;

namespace ConverterMarkupExtension
{
    // ConverterクラスをMarkupExtensionとして作成することで
    // XAMLにおいて、Resourcesでコンバーターのインスタンスを生成する必要がなくなる

    public class FizzBuzzConverterExtension : MarkupExtension, IValueConverter
    {
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return this;
        }

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
