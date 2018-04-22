using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using OxyPlot;
using OxyPlot.Series;

namespace OxyPlotSample2
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
            : base()
        {
            var sin = new FunctionSeries( 
                Math.Sin,  // func
                0.0,  // start
                2.0 * Math.PI,  // end
                dx: 0.1,  // 刻み
                title: "sin(x)" );

            Model.Series.Add( sin );


            LineSeries line = new LineSeries();
            line.Points.Add( new DataPoint( 0.0, 0.0 ) );
            line.Points.Add( new DataPoint( 1.0, 1.0 ) );
            line.Points.Add( new DataPoint( 2.0, 0.0 ) );
            line.Points.Add( new DataPoint( 3.0, 1.0 ) );
            line.Points.Add( new DataPoint( 4.0, 0.0 ) );

            line.Title = "line";

            Model.Series.Add( line );
        }

        public PlotModel Model { get; private set; } = new PlotModel();
    }
}
