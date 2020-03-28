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
    public class MonthViewModel1 : BindableBase
    {
        public MonthViewModel1()
            : base()
        {
            ChangeCommand = new DelegateCommand( () =>
            {
                SelectedMonthIndex = _random.Next( 0, 11 );
            } );
        }

        private int _selectedMonthIndex = 0;
        private MonthEnum _selectedMonth = MonthEnum.January;
        private Random _random = new Random( Seed: 1 );

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
            set => SetProperty( ref _selectedMonth, value, () => Debug.WriteLine( $"#1: { value }" ) );
        }

        public DelegateCommand ChangeCommand { get; } 
    }
}
