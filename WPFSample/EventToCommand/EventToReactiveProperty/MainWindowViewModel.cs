using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Reactive.Bindings;

namespace EventToReactiveProperty
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }

        public ReactiveProperty<Point> MousePoint { get; set; } = new ReactiveProperty<Point>();
    }
}
