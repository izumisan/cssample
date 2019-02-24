using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace IObservableSequence
{
    public class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;
        public event EventHandler Value2Updated = null;
        public event EventHandler<ValueUpdatedEventArgs> Value3Updated = null;

        public Foo()
        {
        }

        private int _value1 = 0;
        private int _value2 = 0;
        private int _value3 = 0;

        public int Value1
        {
            get { return _value1; }
            set
            {
                if ( _value1 != value )
                {
                    _value1 = value;

                    // PropertyChagnedの発火
                    this.PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( Value1 ) ) );
                }
            }
        }

        public int Value2
        {
            get { return _value2; }
            set
            {
                if ( _value2 != value )
                {
                    _value2 = value;

                    // EventHanderの発火
                    this.Value2Updated?.Invoke( this, new EventArgs() );
                }
            }
        }

        public int Value3
        {
            get { return _value3; }
            set
            {
                if ( _value3 != value )
                {
                    _value3 = value;

                    // EventHander<T>の発火
                    this.Value3Updated?.Invoke( this, new ValueUpdatedEventArgs { Value = value } );
                }
            }
        }
    }
}
