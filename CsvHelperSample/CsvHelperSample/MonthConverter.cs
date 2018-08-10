using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelperSample
{
    public class MonthConverter : DefaultTypeConverter
    {
        public MonthConverter()
            : base()
        {
        }

        public override object ConvertFromString( string text, IReaderRow row, MemberMapData memberMapData )
        {
            dynamic ret = null;

            if ( !string.IsNullOrEmpty( text ) )
            {
                int value = 0;

                if ( int.TryParse( text, out value ) )
                {
                    // 数値⇒列挙型

                    if ( Enum.IsDefined( typeof( MonthEnum ), value ) )
                    {
                        ret = (MonthEnum)value;
                    }
                }
                else
                {
                    // 文字列⇒列挙型

                    var table = new Dictionary<string, MonthEnum>
                    {
                        { "none", MonthEnum.None },
                        { "jan", MonthEnum.Jan },
                        { "feb", MonthEnum.Feb },
                        { "mar", MonthEnum.Mar },
                        { "apr", MonthEnum.Apr },
                        { "may", MonthEnum.May },
                        { "jun", MonthEnum.Jun },
                        { "jul", MonthEnum.Jul },
                        { "aug", MonthEnum.Aug },
                        { "sep", MonthEnum.Sep },
                        { "oct", MonthEnum.Oct },
                        { "nov", MonthEnum.Nov },
                        { "dec", MonthEnum.Dec }
                    };

                    if ( table.ContainsKey( text ) )
                    {
                        ret = table[text];
                    }
                }
            }

            if ( ret == null )
            {
                ret = base.ConvertFromString( text, row, memberMapData );
            }

            return ret;
        }
    }
}
