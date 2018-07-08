using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;

namespace LoadModuleApp.LoaderModule.Models
{
    public class MessagePublisher : IMessagePublisher
    {
        public MessagePublisher( IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;
        }

        private IEventAggregator _eventAggregator = null;

        private int _count = 0;

        public void publish( string message )
        {
            ++_count;

            _eventAggregator.GetEvent<PubSubEvent<string>>()
                .Publish( message );
        }
    }
}
