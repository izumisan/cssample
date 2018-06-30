using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeManagerSample
{
    class Foo : IFoo
    {
        public Foo()
        {
            ++_classCount;
        }

        private static int _classCount = 0;

        private static Random _random = new Random();

        public int ClassCount
        {
            get { return _classCount; }
        }

        public int Value { get; set; } = 0;

        public void update()
        {
            Value = _random.Next();
        }
    }
}
