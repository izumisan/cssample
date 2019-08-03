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
    - 出力ログレベルを`Debug`モードの場合は`Trace`, `Release`モードの場合は`Info`となるようにしたサンプル（その1）
    - コード上でルールを書き換えたパターン
- ChangeMinLevelByConfiguration2
    - 出力ログレベルを`Debug`モードの場合は`Trace`, `Release`モードの場合は`Info`となるようにしたサンプル（その2）
    - whenフィルタを用いて、config上でルールを無効化したパターン（`Debug`と`Release`で条件分岐用の変数をコード上から切り替える）

# 備忘録

- loggerタグの属性で ${...} は使えないらしい
    ```xml
    <!-- これはダメ -->
    <logger name="*" minlevel="${var:outlevel}" writeTo="f" />
    ```
- `<when>`フィルタにより、ルールを無効化
    ```xml
    <logger name="*" minlevel="Trace" writeTo="debuglog">
      <filters>
        <when condition="equals('${var:debuglog}','ignore')" action="Ignore"/>
      </filters>
    </logger>
    ```

# NLogドキュメント

- [Configuration file](https://github.com/NLog/NLog/wiki/Configuration-file)
- [File target](https://github.com/NLog/NLog/wiki/File-target)
- [FileTarget Archive Examples](https://github.com/NLog/NLog/wiki/FileTarget-Archive-Examples)
- [When Filter](https://github.com/NLog/NLog/wiki/When-filter)
