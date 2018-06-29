using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Unity;
using Unity.Lifetime;

namespace LifetimeManagerSample
{
    class Program
    {
        static void Main( string[] args )
        {
            ContainerControlledLifetimeManagerSample();

            ExternallyControlledLifetimeManagerSample();

            TransientLifetimeManagerSample();

            PerResolveLifetimeManagerSample();
        }

        /// <summary>
        /// ContainerControlledLifetimeManager : コンテナ単位でシングルトンとして管理
        /// </summary>
        static void ContainerControlledLifetimeManagerSample()
        {
            Trace.WriteLine( "----- ContainerControlledLifetimeManager" );

            IUnityContainer container = new UnityContainer();

            // シングルトンとしてFooを登録
            container.RegisterType<IFoo, Foo>( new ContainerControlledLifetimeManager() );

            // コンテナ経由でFooオブジェクトを3つ要求する
            var fooList = Enumerable.Range( 0, 3 ).Select( _ => container.Resolve<IFoo>() ).ToList();

            // リスト要素の1つに値をセットする
            var foo1 = fooList.First();
            foo1.Value = 123;

            Debug.WriteLine( $"[1] size: { fooList.Count }" );

            fooList.ForEach( x =>
            {
                //@@@ 全て同じオブジェクト
                Debug.WriteLine( $"[1] ClassCount: { x.ClassCount }, Value: { x.Value }" );
            } );

            Debug.WriteLine( "-----" );

            //
            // 別コンテナ
            //
            IUnityContainer container2 = new UnityContainer();
            container2.RegisterType<IFoo, Foo>( new ContainerControlledLifetimeManager() );

            var foo2 = container2.Resolve<IFoo>();
            foo2.Value = 234;

            //@@@ foo1とfoo2は別コンテナ経由のオブジェクトなので、両者は別オブジェクト
            Debug.WriteLine( $"[1] ClassCount: { foo1.ClassCount }, Value: { foo1.Value }" );
            Debug.WriteLine( $"[2] ClassCount: { foo2.ClassCount }, Value: { foo2.Value }" );
        }

        /// <summary>
        /// ExternallyControlledLifetimeManager : 弱参照のシングルトン管理
        /// </summary>
        static void ExternallyControlledLifetimeManagerSample()
        {
            Trace.WriteLine( "----- ExternallyControlledLifetimeManager" );

            IUnityContainer container = new UnityContainer();

            // 弱参照のシングルトンとしてFooを登録
            container.RegisterType<IFoo, Foo>( new ExternallyControlledLifetimeManager() );

            // コンテナ経由でFooオブジェクトを3つ要求する
            var fooList = Enumerable.Range( 0, 3 ).Select( _ => container.Resolve<IFoo>() ).ToList();

            Debug.WriteLine( $"[1] size: { fooList.Count }" );

            fooList.ForEach( x =>
            {
                //@@@ 全て同じオブジェクト
                Debug.WriteLine( $"ClassCount: { x.ClassCount }, Value: { x.Value }" );
            } );

            // オブジェクトの破棄 & GCの強制実行
            fooList.Clear();
            GC.Collect();
            Debug.WriteLine( "----- GC" );

            //@@@ GC後は別オブジェクト
            var foo2 = container.Resolve<IFoo>();
            Debug.WriteLine( $"ClassCount: { foo2.ClassCount }, Value: { foo2.Value }" );
        }

        /// <summary>
        /// TransientLifetimeManager : 毎回インスタンスを生成する
        /// </summary>
        static void TransientLifetimeManagerSample()
        {
            Trace.WriteLine( "----- TransientLifetimeManager" );

            IUnityContainer container = new UnityContainer();

            container.RegisterType<IFoo, Foo>( new TransientLifetimeManager() );

            var foo1 = container.Resolve<IFoo>();
            foo1.update();

            var foo2 = container.Resolve<IFoo>();
            foo2.update();

            //@@@ 両者は別オブジェクト
            Debug.WriteLine( $"#1 ClassCount: { foo1.ClassCount }, Value: { foo1.Value }" );
            Debug.WriteLine( $"#2 ClassCount: { foo2.ClassCount }, Value: { foo2.Value }" );
        }

        /// <summary>
        /// PerResolveLifetimeManager : 毎回インスタンスを生成する
        /// </summary>
        static void PerResolveLifetimeManagerSample()
        {
            Trace.WriteLine( "----- PerResolveLifetimeManager" );

            IUnityContainer container = new UnityContainer();

            container.RegisterType<IFoo, Foo>( new PerResolveLifetimeManager() );

            var foo1 = container.Resolve<IFoo>();
            foo1.update();

            var foo2 = container.Resolve<IFoo>();
            foo2.update();

            //@@@ 両者は別オブジェクト
            Debug.WriteLine( $"#1 ClassCount: { foo1.ClassCount }, Value: { foo1.Value }" );
            Debug.WriteLine( $"#2 ClassCount: { foo2.ClassCount }, Value: { foo2.Value }" );
        }
    }
}
