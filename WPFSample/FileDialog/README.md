# FileDialog

# overview

1. FileDialog1プロジェクト
    - 愚直に実装したパターン
    - ViewModelでコールバックアクションを設定したイベントを発行し、ViewからTriggerActionを呼び出し、TriggerActionでダイアログを表示する
    - 選択したファイルパスは、コールバックアクションを通じて、ViewModelに設定される
1. FileDialog2プロジェクト
    - PrismのInteractionRequestを利用したパターン
    - InteractionRequestというメッセンジャーを利用しているだけで、実質的にFileDialog1とやっていることに変わりはない
1. FileDialog3プロジェクト
    - ボタン押下後の処理をViewModelを介さずにViewのみで完結したパターン（正確にはTriggerActionは使う）
    - DelegateCommandの代わりにEventTriggerでTriggerActionを呼び出す
    - TriggerActionの結果をOneWayToSourceでViewModelに流し込む
