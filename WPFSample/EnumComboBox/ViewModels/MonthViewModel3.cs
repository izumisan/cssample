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
    public class MonthViewModel3 : BindableBase
    {
        public MonthViewModel3()
            : base()
        {
            ChangeCommand = new DelegateCommand( () =>
            {
                SelectedMonth = (MonthEnum)( _random.Next( 1, 12 ) );
            } );
        }

        private MonthEnum _selectedMonth = MonthEnum.January;
        private Random _random = new Random( Seed: 3 );

        public IEnumerable<MonthEnum> MonthSource => Enum.GetValues( typeof( MonthEnum ) ).Cast<MonthEnum>();

        public MonthEnum SelectedMonth
        {
            get => _selectedMonth;
            set => SetProperty( ref _selectedMonth, value, () => Debug.WriteLine( $"#3: { value }" ) );
        }

        public DelegateCommand ChangeCommand { get; }
    }
}
