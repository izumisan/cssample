using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace JsonNETSample
{
    public class Foo
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("value")]
        public int Value { get; set; } = 0;

        [JsonProperty("lucky")]
        public bool Lucky { get; set; } = false;
    }
}
