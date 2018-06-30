using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Events;
using Microsoft.Practices.Unity;
using EventAggregatorApp.Shared;

namespace EventAggregatorApp.InputModule.ViewModels
{
    public class InputViewModel : BindableBase
    {
        public InputViewModel()
            : base()
        {
            UpdateCommand = new DelegateCommand( () => Value = _random.Next() );

            PublishCommand = new DelegateCommand( publishCommandExecute );
        }

        private Random _random = new Random();

        private int _value = 0;

        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        public int Value
        {
            get { return _value; }
            set { SetProperty( ref _value, value ); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public DelegateCommand PublishCommand { get; private set; }

        private void publishCommandExecute()
        {
            EventAggregator.GetEvent<InputContentEvent>()
                .Publish( new InputContent { Content = Value } );
        }
    }
}
