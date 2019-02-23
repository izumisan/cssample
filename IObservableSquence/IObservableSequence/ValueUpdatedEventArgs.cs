using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObservableSequence
{
    public class ValueUpdatedEventArgs : EventArgs
    {
        public ValueUpdatedEventArgs()
            : base()
        {
        }

        public int Value { get; set; } = 0;
    }
}
