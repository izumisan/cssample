# SystemTraySample

# overview

- SystemTraySample
    - System.Windows.Forms.NotifyIconを用いたサンプル

# SystemTraySample覚書

1. 「新しい項目」から「コンポーネントクラス」を追加する
1. 追加したクラス（NotifyIconWrapper）に、ツールボックスから`ContextMenuStrip`, `NotifyIcon`をドラッグ＆ドロップ
1. `ContextMenuStrip`の「項目の編集」から、右クリックメニューアイテムを追加
1. `NotifyIcon`のContextMenuStripプロパティに、ContextMenuStripのオブジェクト、Iconプロパティにアイコンファイルを設定する
1. 参照設定に、`System.Drawing`を追加
1. NotifyIconWrapper.csにおいて、メニューアイテムクリック時のイベントハンドラを追加
1. App.xaml.csから、NotifyIconWrapperをインスタンス化

