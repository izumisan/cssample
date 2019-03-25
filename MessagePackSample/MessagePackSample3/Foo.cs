using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample3
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class Foo
    {
            public int Id { get; set; } = 0;
            public string Name { get; set; } = string.Empty;
            public double Value { get; set; } = 0;
    }
}
