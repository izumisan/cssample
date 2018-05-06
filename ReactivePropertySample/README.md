# ReactivePropertySample

## ReactivePropertySample

ReactivePropertyの基礎
- ReactiveProperty
- ReactiveCommand
- IObservable<T>じゃないものからRxプロパティへの接続
- RxプロパティとRxプロパティの連動

## ReactivePropertySample2

ReactivePropertyの基礎（その2）
- CompositeDisposable
- RxプロパティからRxコマンドの生成

## ReactivePropertySample3

ReactivePropertyの基礎（その3）
- ReactivePropertyによる値の検証

## ObservableSample

IObservable\<T\>の生成
- Observable.Repeat()
- Observable.Range()
- Observable.Generate()
- Observable.Defer()
- Observable.Skip()
- Observable.Take()

## ObservableSample2

IObservable\<T\>の生成（その2）
- Observable.Timer()
- Observable.Interval()
- Observable.Delay()
- Observable.Sample()

# Hot / Cold Observable

- Hot Observable  
    IObservable\<T\>を購読している全てのIObserver\<T\>に対し、同時に同じ値を発行する

- Cold Observable  
    IObservable\<T\>を購読しているそれぞれのIObserver\<T\>に対し、それぞれ個別に値を発行する
