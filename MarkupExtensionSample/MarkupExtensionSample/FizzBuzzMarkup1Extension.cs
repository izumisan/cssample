using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Markup;

namespace MarkupExtensionSample
{
    // MarkupExtensionを継承することで
    // XAMLで "{local:FizzBuzzMarkup1}" のように利用できる
    // 
    // - クラス名はxxxxExtensionとするのがルール？マナー？
    // - XAMLでは、Extensionの部分は省略できる
    public class FizzBuzzMarkup1Extension : MarkupExtension
    {
        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return "Fizz Buzz";
        }
    }
}
