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
    public class MonthEnumViewModel2 : BindableBase
    {
        public MonthEnumViewModel2()
            : base()
        {
            MonthSource = new Dictionary<MonthEnum, string>
            {
                { MonthEnum.January, "睦月" },
                { MonthEnum.Februrary, "如月" },
                { MonthEnum.March, "弥生" },
                { MonthEnum.April, "卯月" },
                { MonthEnum.May, "皐月" },
                { MonthEnum.June, "水無月" },
                { MonthEnum.July, "文月" },
                { MonthEnum.August, "葉月" },
                { MonthEnum.September, "長月" },
                { MonthEnum.October, "神無月" },
                { MonthEnum.November, "霜月" },
                { MonthEnum.December, "師走" }
            };

            ChangeCommand = new DelegateCommand( () =>
            {
                SelectedMonth = (MonthEnum)( _random.Next() % 12 + 1 );
            } );
        }

        private MonthEnum _selectedMonth = MonthEnum.January;
        private Random _random = new Random();

        public IReadOnlyDictionary<MonthEnum, string> MonthSource { get; set; }

        public MonthEnum SelectedMonth
        {
            get => _selectedMonth;
            set => SetProperty( ref _selectedMonth, value, () => Debug.WriteLine( value ) );
        }

        public DelegateCommand ChangeCommand { get; }
    }
}
