using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace EnumComboBox.ViewModels
{
    public class MonthEnumViewModel1 : BindableBase
    {
        public MonthEnumViewModel1()
            : base()
        {
            ChangeCommand = new DelegateCommand( () =>
            {
                SelectedMonthIndex = _random.Next() % 12;
            } );
        }

        private int _selectedMonthIndex = 0;
        private MonthEnum _selectedMonth = MonthEnum.January;
        private Random _random = new Random();

        public int SelectedMonthIndex
        {
            get => _selectedMonthIndex;
            set => SetProperty( ref _selectedMonthIndex, value, () =>
            {
                SelectedMonth = (MonthEnum)( value + 1 );
            } );
        }

        public MonthEnum SelectedMonth
        {
            get => _selectedMonth;
            set => SetProperty( ref _selectedMonth, value, () => Debug.WriteLine( value ) );
        }

        public DelegateCommand ChangeCommand { get; } 
    }
}
