using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using LoadModuleApp.MonitorModule.Models;

namespace LoadModuleApp.MonitorModule.ViewModels
{
    public class MonitorViewModel : BindableBase
    {
        public MonitorViewModel( IMessageStore messageStore )
            : base()
        {
            ( messageStore.Values as INotifyCollectionChanged ).CollectionChanged += ( _, e ) =>
            {
                if ( e.Action == NotifyCollectionChangedAction.Add )
                {
                    this.Values.AddRange( e.NewItems.Cast<string>() );
                }
            };
        }

        public string Title { get; } = "Monitor";

        public ObservableCollection<string> Values { get; } = new ObservableCollection<string>();
    }
}
