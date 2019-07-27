# README

Prism v7.2で追加されたDialogServiceを使ったサンプル

# How to

- Dialog用のViewをコンテナに登録する
- Dialog用のVMにIDialogAwareインタフェースを実装する
- 呼び出し元VMにIDialogServiceをインジェクション
- IDialogService.ShowDialogメソッド(or Showメソッド)でダイアログを表示する
    - 呼び出し元VMからDialogVMに渡すパラメータは、ShowDialogのメソッド引数のDialogParametersで指定する
- DialogVMでIDialogAware.RequestCloseイベントを発火することでダイアログを閉じる
    - Dialogの結果は、RequestCloseイベントの引数（DialogResult）で指定する

# Note

- ShowDialog()はモーダルダイアログ、Show()は非モーダルダイアログ
- Navigationと似たような感じで実装できる
- InteractionRequest & PopupWindowActionを使ったダイアログより楽に実装できる
