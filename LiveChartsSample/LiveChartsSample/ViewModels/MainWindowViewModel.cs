using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace LiveChartsSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            SinValues = new ChartValues<ObservablePoint>();
            CosValues = new ChartValues<ObservablePoint>();
            TanValues = new ChartValues<ObservablePoint>();

            for ( double x = 0.0; x <= 2.0 * Math.PI; x += 0.4 )
            {
                SinValues.Add( new ObservablePoint( x, Math.Sin( x ) ) );
                CosValues.Add( new ObservablePoint( x, Math.Cos( x ) ) );
                TanValues.Add( new ObservablePoint( x, Math.Tan( x ) ) );
            }

            FooValues = new ChartValues<ObservablePoint>
            {
                new ObservablePoint( 0.0, 0.0 ),
                new ObservablePoint( 1.0, 1.0 ),
                new ObservablePoint( 2.0, 0.0 ),
                new ObservablePoint( 3.0, -1.0 ),
                new ObservablePoint( 4.0, 0.0 ),
                new ObservablePoint( 5.0, 1.0 ),
                new ObservablePoint( 6.0, 0.0 ),
            };

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sin",
                    Values = SinValues
                },
                new LineSeries
                {
                    Title = "Cos",
                    Values = CosValues
                },
                new LineSeries
                {
                    Title = "Tan",
                    Values = TanValues
                },
                new LineSeries
                {
                    Title = "Foo",
                    Values = FooValues
                }
            };
        }

        public SeriesCollection SeriesCollection { get; set; }

        public ChartValues<ObservablePoint> SinValues { get; set; }

        public ChartValues<ObservablePoint> CosValues { get; set; }

        public ChartValues<ObservablePoint> TanValues { get; set; }

        public ChartValues<ObservablePoint> FooValues { get; set; }
    }
}
