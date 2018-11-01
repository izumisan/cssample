using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace ZoomSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            for ( double t = 0.0; t < 10.0; t += 0.05 )
            {
                SinValues.Add( new ObservablePoint( t, Math.Sin( 2.0 * Math.PI * 1.0 * t ) ) );
            }
        }

        public ChartValues<ObservablePoint> SinValues { get; private set; } = new ChartValues<ObservablePoint>();
    }
}
