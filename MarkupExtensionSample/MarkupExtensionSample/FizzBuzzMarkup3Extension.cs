using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Markup;

namespace MarkupExtensionSample
{
    public class FizzBuzzMarkup3Extension : MarkupExtension
    {
        // 引数付きコンストラクタを定義することで
        // XAMLで "{local:FizzBuzzMarkup3 xxx}" のようにプロパティの部分（Value=）を省略することができる
        public FizzBuzzMarkup3Extension( int value )
        {
            Value = value;
        }

        // ConstructorArgumentAttributeを指定しなくても問題なく動作するが、
        // 一般的に作法としてConstructorArgumentを指定するらしい
        [ConstructorArgument( "value" )]
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
