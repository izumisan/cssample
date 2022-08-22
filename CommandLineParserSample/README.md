# Command Line Parser

起動引数のパーサーライブラリ

# overview

- CommandLineParserSample
    - CommandLineParserの基本的な使い方
- CommandLineParserSample2
    - `IEnumerable<T>`に`Value属性`を付加することで、オプション形式でない起動引数を全て取得するサンプル
- UsageSample
    - `Usage属性`サンプル
    - ParserResultExtensions(WithParsed(), WithNotParsed() etc.)を利用しないサンプル
- ValueSample
    - `Value属性`サンプル
    - `Value属性`に指定するindexは、引数の並び順を表す数値であり、引数リストのインデックスではない
- VerbSample
    - `Verb属性`サンプル
    - オプションクラスに`VerbAttribute`を付加することで、サブコマンドとなる

# 備忘録

- 基本
    ```cs
    [Option('f', "foo")]
    public string Foo { get; set; }
    ```
    - 上記の場合、以下のオプションが有効になる
        - `-f aaa`
        - `--file aaa`
        - `--file=aaa`
- `--version` と `--help` は、デフォルトで既定されている
