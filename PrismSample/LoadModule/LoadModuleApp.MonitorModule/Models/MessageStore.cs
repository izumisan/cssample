using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Prism.Events;

namespace LoadModuleApp.MonitorModule.Models
{
    public class MessageStore : IMessageStore
    {
        public MessageStore( IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;

            Values = new ReadOnlyObservableCollection<string>( _source );

            _eventAggregator.GetEvent<PubSubEvent<string>>()
                .Subscribe( s => _source.Add( s ) );
        }

        private IEventAggregator _eventAggregator = null;

        private ObservableCollection<string> _source = new ObservableCollection<string>();

        public ReadOnlyObservableCollection<string> Values { get; private set; }
    }
}
