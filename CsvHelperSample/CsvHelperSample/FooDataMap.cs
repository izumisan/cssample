using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelperSample
{
    public class FooDataMap : ClassMap<FooData>
    {
        public FooDataMap()
        {
            Map( x => x.data1 ).Name( "foo.data1" ).TypeConverter<Int32Converter>().Default( 0 );
            Map( x => x.data2 ).Name( "foo.data2" ).TypeConverter<Int32Converter>().Default( 0 );
        }
    }
}
