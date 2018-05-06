using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reactive.Linq;

namespace ObservableSample
{
    class Program
    {
        static void Main( string[] args )
        {
            Debug.Print( @"---Observable.Repeat()" );
            RepeatExample();

            Debug.Print( @"---Observable.Range()" );
            RangeExample();

            Debug.Print( @"---Observable.Generate()" );
            GenerateExample();

            Debug.Print( @"---Observable.Generate() ex2" );
            GenerateExample2();

            Debug.Print( @"---Observable.Defer()" );
            DeferExample();

            Debug.Print( @"---Observable.Skip()" );
            SkipExample();

            Debug.Print( @"---Observable.Take()" );
            TakeExample();
        }

        /// <summary>
        /// Observable.Repeate()
        /// 
        /// 特定の値を指定した回数発行するIObservable<T>を生成する
        /// </summary>
        static void RepeatExample()
        {
            // 7を3回発行するIObservable<int>を生成
            IObservable<int> source = Observable.Repeat( 7, 3 );

            Debug.Print( @"購読開始" );

            // 購読された後でOnNextが発行される
            IDisposable subscription = source.Subscribe(
                i => Debug.Print( $@"OnNext({i})" ),
                ex => Debug.Print( $@"OnError({ex.Message})" ),
                () => Debug.Print( $@"Completed()" ) );

            Debug.Print( @"購読停止" );

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Range()
        /// 
        /// 指定したレンジの値を順次発行するIObservable<int>を生成する
        /// </summary>
        static void RangeExample()
        {
            // 3から7回カウントアップした値(3,4,5,6,7,8,9)を発行するIO<T>を生成
            var source = Observable.Range( 3, 7 );

            var subscription = source.Subscribe(
                i => Debug.Print( $@"OnNext({i})" ),
                ex => Debug.Print( $@"OnError({ex.Message})" ),
                () => Debug.Print( $@"Completed()" ) );

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Generate()
        /// </summary>
        static void GenerateExample()
        {
            // 0からi<10の間、iをインクリメントしつつi*iを返すIO<T>を生成する
            // (つまり、for(int i=0; i<10; ++i ){ return i*i; }のようなもの)
            var source = Observable.Generate(
                0,
                i => i < 10,
                i => ++i,
                i => i * i );

            var subscription = source.Subscribe(
                i => Debug.Print( $@"OnNext({i})" ),
                ex => Debug.Print( $@"OnError({ex.Message})" ),
                () => Debug.Print( $@"Completed()" ) );

            subscription.Dispose();
        }

        static void GenerateExample2()
        {
            // 0.1秒おきに値を発行するIO<T>を生成する
            var source = Observable.Generate(
                0,
                i => i < 10,
                i => ++i,
                i => i,
                _ => TimeSpan.FromSeconds( 0.1 ) );

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var subscription = source.Subscribe(
                i => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnNext({i})" ),
                ex => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) OnError({ex.Message})" ),
                () => Debug.Print( $@"({stopwatch.ElapsedMilliseconds} msec) Completed()" ) );

            // Completedが発行されるまでの1秒以上待機する
            Task.Delay( TimeSpan.FromSeconds( 1.2 ) ).Wait();

            stopwatch.Stop();

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Defer()
        /// 
        /// IO<T>を返すラムダ式を引数に指定することで、
        /// Subscribeされる度に引数で指定したラムダ式を生成する
        /// </summary>
        static void DeferExample()
        {
            Debug.Print( @"ex1" );
            {
                int x = 0;
                var source = Observable.Defer( () => Observable.Range( x++, 3 ) );

                var subscription = source.Subscribe(
                    i => Debug.Print( $@"OnNext({i})" ),
                    ex => Debug.Print( $@"OnError({ex.Message})" ),
                    () => Debug.Print( $@"Completed()" ) );

                // Subscribeする度にDefer()で指定したラムダ式を生成するので、
                // ここで生成されるIO<T>の最初の値は1となる
                var subscription2 = source.Subscribe(
                    i => Debug.Print( $@"OnNext({i})" ),
                    ex => Debug.Print( $@"OnError({ex.Message})" ),
                    () => Debug.Print( $@"Completed()" ) );

                subscription.Dispose();
                subscription2.Dispose();
            }


            Debug.Print( @"ex2" );
            {
                // Defer()を使用せずに普通にRange()を使用した場合

                int x = 0;
                var source = Observable.Range( x++, 3 );

                var subscription = source.Subscribe(
                    i => Debug.Print( $@"OnNext({i})" ),
                    ex => Debug.Print( $@"OnError({ex.Message})" ),
                    () => Debug.Print( $@"Completed()" ) );

                var subscription2 = source.Subscribe(
                    i => Debug.Print( $@"OnNext({i})" ),
                    ex => Debug.Print( $@"OnError({ex.Message})" ),
                    () => Debug.Print( $@"Completed()" ) );

                subscription.Dispose();
                subscription2.Dispose();
            }
        }

        /// <summary>
        /// Observble.Skip()
        /// </summary>
        static void SkipExample()
        {
            var source = Observable.Range( 0, 10 );

            var subscription = source
                .Skip( 3 )
                .Subscribe(
                i => Debug.Print( $@"OnNext({i})" ),
                ex => Debug.Print( $@"OnError({ex.Message})" ),
                () => Debug.Print( $@"Completed()" ) );

            subscription.Dispose();
        }

        /// <summary>
        /// Observable.Take()
        /// </summary>
        static void TakeExample()
        {
            var source = Observable.Range( 0, 10 );

            var subscription = source
                .Take( 3 )
                .Subscribe(
                i => Debug.Print( $@"OnNext({i})" ),
                ex => Debug.Print( $@"OnError({ex.Message})" ),
                () => Debug.Print( $@"Completed()" ) );

            subscription.Dispose();
        }
    }
}