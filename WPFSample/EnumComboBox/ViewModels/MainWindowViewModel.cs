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

        public MonthViewModel1 MonthVM1 { get; } = new MonthViewModel1();

        public MonthViewModel2 MonthVM2 { get; } = new MonthViewModel2();

        public MonthViewModel3 MonthVM3 { get; } = new MonthViewModel3();
    }
}
