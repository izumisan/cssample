using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Console
{
    class Program
    {
        static void Main( string[] args )
        {
            double[] t = new double[100];
            double[] sin = new double[100];
            double[] cos = new double[100];

            double freq = 1.0;
            for ( int i = 0; i < 100; ++i )
            {
                t[i] = i * 0.01;
                sin[i] = Math.Sin( 2.0 * Math.PI * freq * t[i] );
                cos[i] = Math.Cos( 2.0 * Math.PI * freq * t[i] );
            }

            var plot = new ScottPlot.Plot( 800, 600 );
            plot.AddScatter( t, sin );
            plot.AddScatter( t, cos );

            plot.Title( "Title" );
            plot.XLabel( "X label" );
            plot.YLabel( "Y label" );

            plot.SaveFig( "basic.console.png" );
        }
    }
}
