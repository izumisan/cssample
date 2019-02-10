using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChangedBase
{
    public class NotifyPropertyChagnedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = null;

        public NotifyPropertyChagnedBase()
        {
        }

        protected virtual bool SetProperty<T>( ref T field, T value, [CallerMemberName] string propertyName = null )
        {
            bool ret = false;
            if ( Equals( field, value ) != true )
            {
                field = value;
                ret = true;

                RaisePropertyChanged( propertyName );
            }
            return ret;
        }

        protected virtual bool SetProperty<T>( ref T field, T value, Action onChanged, [CallerMemberName] string propertyName = null )
        {
            bool changed = SetProperty( ref field, value, propertyName );
            if ( changed )
            {
                onChanged?.Invoke();
            }
            return changed;
        }

        protected void RaisePropertyChanged( string propertyName )
        {
            this.PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        protected void RaisePropertyChanged( PropertyChangedEventArgs args )
        {
            this.PropertyChanged?.Invoke( this, args );
        }
    }
}
