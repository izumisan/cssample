using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample2
{
    [MessagePackObject]
    public class Foo
    {
        // Keyアトリビュートでstring型を指定した場合、
        // パラメータはmapとしてシリアライズされる
        [Key("id")]
        public int Id { get; set; } = 0;
        [Key("name")]
        public string Name { get; set; } = string.Empty;
        [Key("bar")]
        public Bar Bar { get; set; } = new Bar();

        // 全てのpublicプロパティ/フィールドはシリアライズ対象となるため
        // Keyアトリビュートを指定する必要がある
        // シリアライズ対象から除外する場合は、"IgnoreMember"を指定する必要がある
        [IgnoreMember]
        public int Value { get; set; } = 0;
    }
}
