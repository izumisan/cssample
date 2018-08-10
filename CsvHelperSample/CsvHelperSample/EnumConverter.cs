using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.TypeConversion;

namespace CsvHelperSample
{
    public class EnumConverter<T> : EnumConverter 
        where T : struct
    {
        public EnumConverter()
            : base( typeof( T ) )
        {
        }
    }
}
