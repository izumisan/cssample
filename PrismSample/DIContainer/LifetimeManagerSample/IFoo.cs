using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeManagerSample
{
    interface IFoo
    {
        int ClassCount { get; }
        int Value { get; set; }
        void update();
    }
}
