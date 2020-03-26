using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

namespace EnumComboBox.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
        }

        public MonthEnumViewModel1 MonthEnumVM1 { get; } = new MonthEnumViewModel1();
    }
}
