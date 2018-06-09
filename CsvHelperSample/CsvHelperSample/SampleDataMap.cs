using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelperSample
{
    public class SampleDataMap : ClassMap<SampleData>
    {
        public SampleDataMap()
        {
            Map( x => x.Str ).Name( "string" ).Default( "empty" );
            Map( x => x.Int ).Name( "int" ).TypeConverter<Int32Converter>().Default( 0 );
            Map( x => x.Double ).Name( "double" ).TypeConverter<DoubleConverter>().Default( 0.0 );

            // 列挙型
            //------------------------------------------------------------------
            // 数値指定
            Map( x => x.Month ).Name( "month" ).TypeConverter<Int32Converter>().Default( MonthEnum.None );

            // 自作コンバータを使用(数値指定 or 要素名指定 に対応)
            Map( x => x.Month2 ).Name( "month2" ).TypeConverter<MonthEnumConverter>().Default( 0 );

            // 汎用コンバータを使用(数値指定 or 要素名指定 に対応)
            Map( x => x.Month3 ).Name( "month3" ).TypeConverter<GenericEnumConverter<MonthEnum>>().Default( 0 );
        }
    }
}
