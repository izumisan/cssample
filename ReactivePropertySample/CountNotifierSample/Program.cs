using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reactive.Linq;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace CountNotifierSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var countNotifier = new CountNotifier();

            countNotifier.Subscribe( x => Debug.Print( $"CountChangedStatus={ x }: Count={ countNotifier.Count }" ) );

            countNotifier.Increment(); //=> CountChangedStatus=Increment: Count=1
            countNotifier.Increment( 10 );  //=> CountChangedStatus=Increment: Count=11

            countNotifier.Decrement(); //=> CountChangedStatus=Decrement: Count=10
            countNotifier.Decrement( 2 ); //=> CountChangedStatus=Decrement: Count=8

            countNotifier.Decrement( 100 ); //=> CountChangedStatus=Decrement: Count=0
                                            //   CountChangedStatus=Empty: Count=0

            countNotifier.Increment( int.MaxValue - 1 ); //=> CountChangedStatus=Increment: Count=2147483646
            countNotifier.Increment(); //=> CountChangedStatus=Increment: Count=2147483647
                                       //   CountChangedStatus=Max: Count=2147483647
            countNotifier.Increment(); // (出力なし)
            countNotifier.Increment(); // (出力なし)

            countNotifier.Decrement( int.MaxValue - 1 ); //=> CountChangedStatus=Decrement: Count=1
            countNotifier.Decrement(); //=> CountChangedStatus=Decrement: Count=0
                                       //   CountChangedStatus=Empty: Count=0
            countNotifier.Decrement(); // (出力なし)
            countNotifier.Decrement(); // (出力なし)

            // Increment(Decrement)の戻り値(IDisposable)をDisposeすると
            // Increment(Decrement)を取り消す
            IDisposable source1 = countNotifier.Increment( 1 ); //=> CountChangedStatus=Increment: Count=1
            IDisposable source2 = countNotifier.Increment( 2 ); //=> CountChangedStatus=Increment: Count=3
            IDisposable source3 = countNotifier.Increment( 3 ); //=> CountChangedStatus=Increment: Count=6
            source3.Dispose(); //=> CountChangedStatus=Decrement: Count=3
            source1.Dispose(); //=> CountChangedStatus=Decrement: Count=2
        }
    }
}
