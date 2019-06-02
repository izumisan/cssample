using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EnumSample
{
    public class Foo
    {
        /// <summary>
        /// 属性を指定していないEnumプロパティ
        /// </summary>
        public MonthEnum Month1 { get; set; } = MonthEnum.None;

        /// <summary>
        /// JsonConverterにStringEnumConverterを指定したEnumプロパティ
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MonthEnum Month2 { get; set; } = MonthEnum.None;
    }
}
