# NLog

NLogのサンプル

# overview

- NLogSample
    - NLogの基本的な使い方
- NLogSample2
    - CSコード側からログファイル名を指定したサンプル
- ArchiveLog
    - 古い日付のログファイルを自動的に削除するサンプル
- ChangeMinLevelByConfiguration
    - 出力ログレベルを`Debug`モードの場合は`Trace`, `Release`モードの場合は`Info`
    となるようにしたサンプル

# 備忘録

- loggerタグの属性で ${...} は使えないらしい
    ```xml
    <!-- これはダメ -->
    <logger name="*" minlevel="${var:outlevel}" writeTo="f" />
    ```
