using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.TypeConversion;

namespace CsvHelperSample
{
    public class MonthEnumConverter : EnumConverter
    {
        public MonthEnumConverter()
            : base( typeof( MonthEnum ) )
        {
        }
    }
}
