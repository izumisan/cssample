using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Events;
using EventAggregatorApp.Shared;

namespace EventAggregatorApp.OutputModule2.ViewModels
{
    public class OutputModule2ViewModel : BindableBase
    {
        public OutputModule2ViewModel( IEventAggregator eventAggregator )
            : base()
        {
            eventAggregator.GetEvent<InputContentEvent>()
                .Subscribe( e =>
                {
                    var msg = $"#{ Values.Count + 1 } { e.Content }";
                    Values.Insert( 0, msg );
                } );
        }

        public ObservableCollection<string> Values { get; private set; } = new ObservableCollection<string>();
    }
}
