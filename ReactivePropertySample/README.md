# ReactiveProperty

ReactivePropertyのサンプル

# overview

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

## Notifier系クラス

- BooleanNotifierSample
    - BooleanNotifierのサンプルプログラム
- CountNotifierSample
    - CountNotifierのサンプルプログラム
- SingleProcessByCountNotifier
    - CountNotifierを利用して、多重実行を抑制したサンプルプログラム

# 覚書

# Hot / Cold Observable

- Hot Observable  
    IObservable\<T\>を購読している全てのIObserver\<T\>に対し、同時に同じ値を発行する

- Cold Observable  
    IObservable\<T\>を購読しているそれぞれのIObserver\<T\>に対し、それぞれ個別に値を発行する

# ReactivePropertyに変換する

- `ToReactiveProperty()`
    - `INotifyPropertyChanged`をもつクラスのプロパティをReactivePropertyに変換する
- `ToReadOnlyReactiveProperty()`
    - `INotifyPropertyChanged`をもつクラスのプロパティをReadOnlyReactivePropertyに変換する
- `ToReactivePropertyAsSynchronized()`
    - `INotifyPropertyChanged`をもつクラスのプロパティをReactivePropertyに変換する
    - ReactivePropertyの変更は、変換元クラスの指定したプロパティにも反映される（同期される）
    - convert引数, convertBack引数を持つため、単純な変換を行うことができる
- `ReactiveProperty.FromObject()`
    - `INotifyPropertyChanged`を**実装していない**クラスのプロパティをReactivePropertyに変換する
    - ReactivePropertyの変更は、変換元のプロパティに反映される
    - 変換元のプロパティ変更は、当然ReactiveProperty側に反映されない

# `IObservable<T>`に変換する

- `INotifyPropertyChanged`を実装したクラスの特定のプロパティを`IObservable<T>`に変換する
    - `ObservableProperty()`
- `INotifyPropertyChanged`を`IObservable<T>`に変換する
    - `PropertyChangedAsObservable()`
    - `INotifyPropertyChanged`の拡張メソッド
    - `IObservable<NotifyPropertyChangedEventArgs>`に変換する
- `INotifyCollectionChanged`を`IObservable<T>`に変換する
    - `CollectionChangedAsObservable()`
    - `ObservableAddChanged()`
    - `ObservableRemoveChanged()`

# Notifier系クラス

- BooleanNotifier
- CountNotifier
- ScheduledNotifier
- BusyNotifier
