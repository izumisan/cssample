using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace ValidationRuleSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
        }

        private string _input = string.Empty;

        public string Input
        {
            get { return _input; }
            set { SetProperty( ref _input, value ); }
        }
    }
}
