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

            // MonthConverter
            // 愚直に実装したコンバータ
            Map( x => x.Month1 ).Name( "month2" ).TypeConverter<MonthConverter>().Default( 0 );

            // MonthEnumConverter
            // EnumConverterを継承して作成したMonthEnum専用コンバータ
            Map( x => x.Month2 ).Name( "month2" ).TypeConverter<MonthEnumConverter>().Default( 0 );

            // EnumConverter<T>
            // 列挙型用汎用コンバータ
            Map( x => x.Month3 ).Name( "month2" ).TypeConverter<EnumConverter<MonthEnum>>().Default( 0 );


            References<FooDataMap>( x => x.Foo );
        }
    }
}
