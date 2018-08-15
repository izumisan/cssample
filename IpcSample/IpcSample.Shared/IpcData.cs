using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IpcSample.Shared
{
    public class IpcData : MarshalByRefObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        public IpcData()
        {
        }

        private int _value = 0;

        public int Value
        {
            get { return _value; }
            set
            {
                if ( _value != value )
                {
                    _value = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void RaisePropertyChanged( [CallerMemberName] string propertyName = "" )
        {
            this.PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );  // イベント発行
        }
    }
}
