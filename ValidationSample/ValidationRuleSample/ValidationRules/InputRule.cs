using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Globalization;

namespace ValidationRuleSample.ValidationRules
{
    public class InputRule : ValidationRule
    {
        public int MinLength { get; set; } = 0;
        public int MaxLength { get; set; } = int.MaxValue;

        public override ValidationResult Validate( object value, CultureInfo cultureInfo )
        {
            var str = value.ToString();

            if ( str.Length < MinLength )
            {
                return new ValidationResult( false, $"入力は{ MinLength }文字以上必要です." );
            }
            if ( MaxLength < str.Length )
            {
                return new ValidationResult( false, $"入力は{ MaxLength }文字までです." );
            }

            return ValidationResult.ValidResult;
        }
    }
}
