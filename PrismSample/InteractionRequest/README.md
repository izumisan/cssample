 # InteractionRequest

InteractionRequestを用いたダイアログ表示のサンプル

## Module

- NotificationModule
    - `InteractionRequest<Notification>`を用いたモジュール
- ConfirmationModule
    - `InteractionReuqest<Confirmation>`を用いたモジュール
- CustomModule
    - Notificationを派生した自作クラスを用いたモジュール
- DefaultDialogModule
    - prism:PopupWindowActionによるダイアログではなく、System.Windows.MessageBoxによるWPFデフォルトのダイアログを表示するモジュール

## Memo

- InteractionRequestはMessengerパターンにおけるMessegerクラス
- Notification, ConfirmationはMessengerパターンにおけるMessageクラス
- Notificationは、「OK」ボタンのみ
- Confirmationは、「OK」「Cancel」ボタン
- InteractionRequest.RaiseAsyncメソッドは廃止されたっぽい [#672](https://github.com/PrismLibrary/Prism/issues/678)
