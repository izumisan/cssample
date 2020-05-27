# XamlBehaviorsWpf

BlendSDKのビヘイビアがOSS化された`Microsoft.Xaml.Behaviors.Wpf`のサンプル
- [Github](https://github.com/Microsoft/XamlBehaviorsWpf)
- [nuget](https://www.nuget.org/packages/Microsoft.Xaml.Behaviors.Wpf/)

# overview

- XamlBehaviorsWpfSample
    - 今まで通り、BlendSDKのトリガー、アクションを利用した比較用プログラム
    - `Microsoft.Expression.Interactions`への参照追加が必要
- XamlBehaviorsWpfSample2
    - BlendSDKのinteractivity, interactionsを、OSS化された`Microsft.Xaml.Behaviors.Wpf`に置き換えたプログラムサンプル
    - `EventTrigger`などが`System.Windows.Interactivity`から`Microsoft.Xaml.Behaviors`に破壊的変更がなされている

# Note

- `xmlns:i`と`xmlns:ei`をそれぞれ`"http://schemas.microsoft.com/xaml/behaviors"`に置き換えてしまえばいける
    - Before
        ```
        xmlns:i ="http://schemas.microsoft.com/expression/2010/interactivity"
        xmlns:ei="http://schemas.microsoft.com/expression/2010/interactions"
        ```
    - After
        ```
        xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
        xmlns:ei="http://schemas.microsoft.com/xaml/behaviors"
        ```
- `TriggerAction`などは、`System.Windows.Input`から`Microsoft.Xaml.Behaviors`に変更されているので、`TriggerAction`のサブクラス等は、`using`部分を書き換える必要がある
