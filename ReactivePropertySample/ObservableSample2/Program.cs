using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reactive.Linq;

namespace ObservableSample2
{
    class Program
    {
        static void Main( string[] args )
        {
            Debug.Print( @"---Observable.Timer()" );
            TimerExample();

            Debug.Print( @"---Observable.Interval()" );
            IntervalExample();

            Debug.Print( @"---Observable.Delay()" );
            DelayExample();

            Debug.Print( @"---Observable.Sample()" );
            SampleExample();
        }

        /// <summary>
        /// Observable.Timer()
        /// 
        /// 指定した時間おきに値を発行するIO<T>を生成する
        /// </summary>
        static void TimerExample()
        {
            // 3秒後から1秒おきに発行するIO<T>の生成
            var source = Observable.Timer(
                TimeSpan.FromSeconds( 3.0 ),
                TimeSpan.FromSeconds( 1.0 ) );

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var subscription = source.Subscribe(
                i => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnNext({i})" ),
                ex => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnError({ex.Message})" ),
                () => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) Completed()" ) );

            // 動作確認のためのウェイト
            Task.Delay( TimeSpan.FromSeconds( 7.0 ) ).Wait();

            stopwatch.Stop();

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Interval()
        /// 
        /// 指定した時間おきに値を発行するIO<T>を生成する
        /// </summary>
        static void IntervalExample()
        {
            // 1秒おきに発行するIO<T>の生成
            var source = Observable.Interval( TimeSpan.FromSeconds( 1.0 ) );

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var subscription = source.Subscribe(
                i => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnNext({i})" ),
                ex => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnError({ex.Message})" ),
                () => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) Completed()" ) );

            // 動作確認のためのウェイト
            Task.Delay( TimeSpan.FromSeconds( 5.0 ) ).Wait();

            stopwatch.Stop();

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Delay()
        /// </summary>
        static void DelayExample()
        {
            var source = Observable.Range( 0, 5 );

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // 2秒のディレイをかける
            var subscription = source
                .Delay( TimeSpan.FromSeconds( 2.0 ) )
                .Subscribe(
                i => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnNext({i})" ),
                ex => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnError({ex.Message})" ),
                () => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) Completed()" ) );

            // 動作確認のためのウェイト
            Task.Delay( TimeSpan.FromSeconds( 2.5 ) ).Wait();

            stopwatch.Stop();

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Sample()
        /// 
        /// 指定した間隔でサンプリングするIO<T>を生成する
        /// </summary>
        static void SampleExample()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // 0.1secおきに実行し、
            // Amp=1.0, freq=0.1Hzのサイン波を求め、
            // 1sec周期で表示する.
            var subscription = Observable.Interval( TimeSpan.FromMilliseconds( 100.0 ) )
                .Select( i =>
                {
                    double time = 0.1 * i;
                    return Math.Sin( 2.0 * Math.PI * 0.1 * time );
                } )
                .Sample( TimeSpan.FromMilliseconds( 1000.0 ) )
                .Subscribe(
                x => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnNext({x})" ),
                ex => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnError({ex.Message})" ),
                () => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) Completed()" ) );

            // 動作確認のためのウェイト
            Task.Delay( TimeSpan.FromSeconds( 12.0 ) ).Wait();

            stopwatch.Stop();

            subscription.Dispose();
        }
    }
}
