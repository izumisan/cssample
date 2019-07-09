using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

namespace FileDrop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
        }

        private string _dropFile = string.Empty;

        public ObservableCollection<string> Files { get; } = new ObservableCollection<string>();

        public string DropFile
        {
            get { return _dropFile; }
            set { SetProperty( ref _dropFile, value, () => Files.Add( _dropFile ) ); }
        }
    }
}
