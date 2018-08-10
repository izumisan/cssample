using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelperSample
{
    public class SampleData
    {
        public string Str { get; set; } = string.Empty;
        public int Int { get; set; } = 0;
        public double Double { get; set; } = 0.0;
        public MonthEnum Month { get; set; } = MonthEnum.None;
        public MonthEnum Month1 { get; set; } = MonthEnum.None;
        public MonthEnum Month2 { get; set; } = MonthEnum.None;
        public MonthEnum Month3 { get; set; } = MonthEnum.None;

        public FooData Foo { get; set; } = new FooData();
    }
}
