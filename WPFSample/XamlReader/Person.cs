using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlReader
{
    public class Person
    {
        public Person()
        {
            Birthday = DateTime.Now;
        }

        public DateTime Birthday { get; private set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; } = 0;
    }
}
