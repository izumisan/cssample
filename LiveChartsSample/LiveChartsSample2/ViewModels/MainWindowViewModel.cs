using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LiveChartsSample2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            P1Command = new DelegateCommand( () => Pentagon.Add( new ObservablePoint { X = P1[0], Y = P1[1] } ) );
            P2Command = new DelegateCommand( () => Pentagon.Add( new ObservablePoint { X = P2[0], Y = P2[1] } ) );
            P3Command = new DelegateCommand( () => Pentagon.Add( new ObservablePoint { X = P3[0], Y = P3[1] } ) );
            P4Command = new DelegateCommand( () => Pentagon.Add( new ObservablePoint { X = P4[0], Y = P4[1] } ) );
            P5Command = new DelegateCommand( () => Pentagon.Add( new ObservablePoint { X = P5[0], Y = P5[1] } ) );
            ClearCommand = new DelegateCommand( () => Pentagon.Clear() );
            RotationRight = new DelegateCommand( () => rotation( 15.0 ) );
            RotationLeft = new DelegateCommand( () => rotation( -15.0 ) );

            // Chart No.2用
            // X軸（横軸）にy-value、Y軸（縦軸）にx-valueをマッピング
            Mapper = Mappers.Xy<ObservablePoint>()
                     .X( point => point.Y )
                     .Y( point => point.X );
        }

        private static double degToRad = Math.PI / 180.0;
        private static double radToDeg = 180.0 / Math.PI;

        public ChartValues<ObservablePoint> Pentagon { get; private set; } = new ChartValues<ObservablePoint>();

        public CartesianMapper<ObservablePoint> Mapper { get; private set; }

        public DelegateCommand P1Command { get; private set; }
        public DelegateCommand P2Command { get; private set; }
        public DelegateCommand P3Command { get; private set; }
        public DelegateCommand P4Command { get; private set; }
        public DelegateCommand P5Command { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand RotationRight { get; private set; }
        public DelegateCommand RotationLeft { get; private set; }

        private Vector P1
        {
            get { return DenseVector.OfArray( new double[] { 1.0, 0.0 } ); }
        }

        private Vector P2
        {
            get { return ( rotationMatrix( 72.0 * degToRad ) * P1 ) as Vector; }
        }

        private Vector P3
        {
            get { return ( rotationMatrix( 72.0 * degToRad ) * P2 ) as Vector; }
        }

        private Vector P4
        {
            get { return ( rotationMatrix( 72.0 * degToRad ) * P3 ) as Vector; }
        }

        private Vector P5
        {
            get { return ( rotationMatrix( 72.0 * degToRad ) * P4 ) as Vector; }
        }

        private DenseMatrix rotationMatrix( double angle )
        {
            return DenseMatrix.OfArray( new double[,]
            {
                { Math.Cos( angle ), -1.0 * Math.Sin( angle ) },
                { Math.Sin( angle ), Math.Cos( angle ) }
            } );
        }

        private void rotation( double angle )
        {
            foreach ( var point in Pentagon )
            {
                var pos = DenseVector.OfArray( new double[] { point.X, point.Y } );
                pos = rotationMatrix( angle * degToRad ) * pos;

                point.X = pos[0];
                point.Y = pos[1];
            }
        }
    }
}
