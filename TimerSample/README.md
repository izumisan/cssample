# Timer

C#のタイマー関連のサンプル

# overview

- TimerSample
    - `System.Timers.Timer`
    - タイマーイベントは別スレッドで実行される
- TimerSample2
    - `System.Threading.Timer`
    - タイマーイベントは別スレッドで実行される
    - タイマーイベント（コールバック）は、タイマー生成時に指定する必要がある
- TimerSample3
    - `System.Windows.Threading.DispatcherTimer`
    - タイマーイベントはUIスレッドで実行される

# めも

- `System.Timers.Timer`と`System.Threading.Timer`に大きな違いはない？（あっても普通に使う分には差はない）
    - `System.Timers.Timer`の方が使いやすいので、これ一本でおｋ
- WPFは`System.Windows.Threading.DispatcherTimer`
    - UIスレッドで実行されるので、いろいろ考える必要がない
- `System.Windows.Forms.Timer`なんてものもあるけど、Windows.Formなので省略
