# EventToCommandサンプル

View要素（UIエレメント）のイベントをVMのCommandにバインドするサンプルコード

# overview

- InvokeCommandAction
    - Blend SDKの`InvokeCommandAction`（System.Windows.Interactivity.InvokeCommandAction）を用いたサンプル
- PrismInvokeCommandAction
    - Prismの`InvokeCommandAction`（Prism.Interactivity.InvokeCommandAction）を用いたサンプル
    - Blend SDKのInvokeCommandActionと同じように使える
    - `TriggerParameterPath`にEventArgsのプロパティ名を指定することで、VM側でイベントのパラメータを受け取ることができる（本サンプルでは未使用）
- EventToReactiveCommand
    - ReactivePropertyの`EventToReactiveCommand`（Reactive.Bindings.Interactivity.EventToReactiveCommand）を用いたサンプル
    - バインドターゲットは、ReactiveCommand（ICommandは無理？未検証）
    - バインドターゲットを`ReactiveCommand<T>`とすることで、イベント引数をVM側から参照できるようになる
