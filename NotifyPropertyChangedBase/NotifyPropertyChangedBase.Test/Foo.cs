using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NotifyPropertyChangedBase;

namespace NotifyPropertyChangedBase.Test
{
    public class Foo : NotifyPropertyChagnedBase
    {
        public Foo()
            : base()
        {
        }

        private int _value1 = 0;
        private int _value2 = 0;
        private int _value3 = 0;

        public int Value1
        {
            get { return _value1; }
            set { SetProperty( ref _value1, value ); }
        }

        public int Value2
        {
            get { return _value2; }
            set
            {
                SetProperty( ref _value2, value, () =>
                {
                    Value3 = Value2 + 1;
                } );
            }
        }

        public int Value3
        {
            get { return _value3; }
            private set { SetProperty( ref _value3, value ); }
        }
    }
}
