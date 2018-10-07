# FileDialog

# overview

1. FileDialog1プロジェクト
    - 愚直に実装したパターン
    - ViewModelでコールバックアクションを設定したイベントを発行し、ViewからTriggerActionを呼び出し、TriggerActionでダイアログを表示する
    - 選択したファイルパスは、コールバックアクションを通じて、ViewModelに設定される
1. FileDialog2プロジェクト
    - PrismのInteractionRequestを利用したパターン
    - InteractionRequestというメッセンジャーを利用しているだけで、実質的にFileDialog1とやっていることに変わりはない
