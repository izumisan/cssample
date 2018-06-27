using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainerApp.CountModule.Models
{
    public class Counter : ICounter
    {
        public Counter()
        {
        }

        private int _count = 0;

        public int Count
        {
            get { return _count++; }
        }
    }
}
