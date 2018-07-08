using System.Collections.ObjectModel;

namespace LoadModuleApp.MonitorModule.Models
{
    public interface IMessageStore
    {
        ReadOnlyObservableCollection<string> Values { get; }
    }
}