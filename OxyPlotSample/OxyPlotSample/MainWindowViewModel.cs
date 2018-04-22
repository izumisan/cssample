using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Threading;
using Prism.Mvvm;
using OxyPlot;

namespace OxyPlotSample
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            _timer.Tick += ( s, e ) =>
            {
                ++_count;

                updatePoints();

                RaisePropertyChanged( nameof( Title ) );
            };
        
            _timer.Start();
        }

        private ObservableCollection<DataPoint> _points = null;

        private ObservableCollection<DataPoint> _points2 = new ObservableCollection<DataPoint>();

        private DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.0) };

        private int _count = 0;

        public string Title
        {
            get { return $@"Count={_count}"; }
        }

        public ObservableCollection<DataPoint> Points
        {
            get
            {
                return _points ?? ( _points =
                    new ObservableCollection<DataPoint>
                    {
                        new DataPoint( 0.0, 0.0 ),
                        new DataPoint( 1.0, 1.0 ),
                        new DataPoint( 2.0, 4.0 ),
                        new DataPoint( 3.0, 9.0 ),
                        new DataPoint( 4.0, 16.0 ),
                        new DataPoint( 5.0, 25.0 )
                    } );
            }
        }

        public ObservableCollection<DataPoint> Points2
        {
            get { return _points2; }
        }

        private void updatePoints()
        {
            _points2.Clear();

            for ( int i = 0; i < 100; ++i )
            {
                _points2.Add( new DataPoint( i, 10 * Math.Sin( _count * i ) ) );
            }
        }
    }
}
