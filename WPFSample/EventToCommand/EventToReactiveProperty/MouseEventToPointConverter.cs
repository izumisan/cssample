using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Input;
using System.Reactive;
using System.Reactive.Linq;
using Reactive.Bindings.Interactivity;

namespace EventToReactiveProperty
{
    public class MouseEventToPointConverter : ReactiveConverter<MouseEventArgs, Point>
    {
        protected override IObservable<Point> OnConvert( IObservable<MouseEventArgs> source )
        {
            return source.Select( x => x.GetPosition( this.AssociateObject as IInputElement ) );
        }
    }
}
