# IObservable sequence

イベントから`IObservable<T>`（Observableシーケンス）の生成まとめ

# overview

- IObservableSequence
    - PropertyChanged, EventHandler, EventHandler\<T\>をIObservable\<T\>シーケンスに変換するサンプル

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
```

# FromEventPattern, FromEvent

- FromEventPattern
    - メソッドの引数で、イベントの登録・解除のラムダ式を指定する
    - sender, eventArgsをまとめたオブジェクト（`EventPattern`）を後続に流す.
- FromEvent
    - FromEventPatternと異なり、後続にeventArgsのみを流す
    - FromEventPatternの方が使いやすい？
    - Rxでイベント結合する場合、senderは不要なので、こっちを利用すべき？

# 参考リンク

- [Rxでのイベント変換まとめ - FromEvent vs FromEventPattern](http://neue.cc/2011/07/06_332.html)
- [Re:FromEvent vs FromEventPattern](http://neue.cc/2011/09/10_342.html)
