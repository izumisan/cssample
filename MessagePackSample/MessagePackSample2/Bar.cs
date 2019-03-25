using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample2
{
    // MessagePackObject(keyAsPropertyName: true)を指定した場合
    // プロパティ名にKeyが使用される（Keyアトリビュートは省略できる）

    [MessagePackObject(keyAsPropertyName: true)]
    public class Bar
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; } = 0.0;
    }
}
