using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;

namespace DataTriggerAnimation
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }

        public ReactiveProperty<bool> Checked { get; set; } = new ReactiveProperty<bool>();
    }
}
