using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample
{
    [MessagePackObject]
    public class Foo
    {
        // Keyアトリビュートでint型を指定した場合、
        // パラメータは配列としてシリアライズされる

        [Key(0)]
        public int Value1 { get; set; } = 0;

        [Key(1)]
        public double Value2 { get; set; } = 0.0;

        [Key(2)]
        public string Name { get; set; } = string.Empty;

        [Key(3)]
        public IEnumerable<int> ValueList { get; set; } = new List<int>();

        [Key(4)]
        public Dictionary<int, string> Dictionary { get; set; } = new Dictionary<int, string>();
    }
}
