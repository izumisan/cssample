using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace ReactivePropertySample.Model
{
    public class Counter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        public Counter()
        {
        }

        private int _count = 0;

        public int Count
        {
            get { return _count; }
            set
            {
                if ( _count != value )
                {
                    _count = value;
                    PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( Count ) ) );
                }
            }
        }

        public void up()
        {
            ++Count;
        }

        public void down()
        {
            --Count;
        }

        public void reset()
        {
            Count = 0;
        }
    }
}
