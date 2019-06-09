using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample.Tests
{
    public enum MonthEnum
    {
        Undefined = 0,
        [DisplayName("睦月")]
        Jan,
        [DisplayName( "如月" )]
        Feb,
        [DisplayName( "弥生" )]
        Mar,
        [DisplayName( "卯月" )]
        Apr,
        [DisplayName( "皐月" )]
        May,
        [DisplayName( "水無月" )]
        Jun,
        [DisplayName( "文月" )]
        Jul,
        [DisplayName( "葉月" )]
        Aug,
        [DisplayName( "長月" )]
        Sep,
        [DisplayName( "神無月" )]
        Oct,
        [DisplayName( "霜月" )]
        Nov,
        [DisplayName( "師走" )]
        Dec
    }
}
