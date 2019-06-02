using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SerializeFormatSample
{
    public class Foo
    {
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; } = 0;
        public bool Lucky { get; set; } = false;
        public MonthEnum Month { get; set; } = MonthEnum.None;
    }
}
