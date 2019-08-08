# DialogSample

ダイアログの実装サンプル

# overview

- InteractionRequestDialog
    - prismの`InteractionRequest`と`PopupWindowAction`を用いたダイアログサンプル
- InteractionRequestDialog2
    - `IInteractionRequestAware`によるカスタムViewのダイアログサンプル
- MessageBoxService
    - `InteractionRequest`を利用してWPF標準のメッセージボックスを表示するサービスクラスの実装サンプル
    - `MessageBoxResult`による分岐処理をメソッドチェインでつなげてみたサンプル
- DialogService
    - prism v7.2で追加された`DialogService`によるダイアログサンプル

# Note

- `InteractionRequest`や`Notification`はprism 7.2で`Obsolete`となったため、警告が大量にでてしまう...
    - `#pragma`で指定するかプロジェクトプロパティから警告を抑制してしまうか...
        ```cs
        // Obsolete属性による警告を抑制する
        #pragma warning disable 618
        ```


# screen shot

### InteractionRequestDialog

![](2019-08-02-16-37-50.png)

![](2019-08-02-16-38-16.png)

### InteractionRequestDialog2

![](2019-08-02-16-42-45.png)

### MessageBoxService

![](2019-08-02-16-43-04.png)

![](2019-08-02-16-43-15.png)

![](2019-08-02-16-43-25.png)

### DialogService

![](2019-08-08-21-37-41.png)

![](2019-08-08-21-37-57.png)
