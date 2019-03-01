using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

namespace DataTriggerAnimation2
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
        }

        private bool _checked = false;

        public bool Checked
        {
            get { return _checked; }
            set { SetProperty( ref _checked, value ); }
        }
    }
}
