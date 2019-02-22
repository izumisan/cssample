# IObservable sequence

# `IObserver<T>`, `IObservable<T>`

- `IObserver<T>`
    - void OnNext( T value )
    - void OnError( Exception ex )
    - void OnCompleted()
- `IObservable<T>`
    - IDisposable Subcribe( IObserver observer )

# IObservableインタフェースの拡張メソッド

```cs
IDisposable Subscribe<T>( this IObservable<T> source );

IDisposable Subscribe<T>( this IObservable<T> source, 
                          Action<T> onNext );

IDisposable Subscribe<T>( this IObservable<T> source, 
                          Action<T> onNext, 
                          Action<Exception> onError );

IDisposable Subscribe<T>( this IObservable<T> source, 
                          Action<T> onNext, 
                          Action onCompleted );

IDisposable Subscribe<T>( this IObservable<T> source, 
                          Action<T> onNext, 
                          Action<Exception> onError, 
                          Action onCompleted );
````

# 参考リンク

- [Rxでのイベント変換まとめ - FromEvent vs FromEventPattern](http://neue.cc/2011/07/06_332.html)
