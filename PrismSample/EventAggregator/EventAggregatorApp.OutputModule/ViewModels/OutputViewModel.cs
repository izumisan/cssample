using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Events;
using EventAggregatorApp.Shared;

namespace EventAggregatorApp.OutputModule.ViewModels
{
    public class OutputViewModel : BindableBase
    {
        public OutputViewModel( IEventAggregator eventAggregator )
            : base()
        {
            eventAggregator.GetEvent<InputContentEvent>()
                .Subscribe( x => Value = x.Content.ToString() );
        }

        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { SetProperty( ref _value, value ); }
        }
    }
}
