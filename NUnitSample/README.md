# NUnit

# overview

1. NUnitSampleプロジェクト
    - NUnitの基本
1. AssertThatプロジェクト
    - Assert.Thatの使い方
        - 制約クラスの基本的な使い方
        - Is: オブジェクト単体に対する制約を作成
        - Has: コレクションの要素に対する制約を作成
        - Does: （文字列に対する制約だったりコレクションに対する制約だったり、いろいろできる）
        - Throws: 例外に関する制約を作成
    - ConsoleRunnerのおためし
        - ビルド後イベントでConsoleRunnerを指定
        - テスト失敗はビルドエラー扱い

# Assert

## Classic Model

httpする//github.com/nunit/docs/wiki/Classic-Model

## Constraint Model

https://github.com/nunit/docs/wiki/Constraint-Model

## 制約クラス

- Is
- Has
- Does
- Throws

# Attribute

## 基本

|Attribute|説明|
|---|---|
|TestFixture|テストクラスに付与する（SetupFixtureとの違いは理解できていない）|
|SetUpFixture|テストクラスに付与する（TestFixtureとの違いは理解できていない）|
|OneTimeSetUp|全てのテストメソッド実行前に一度だけ呼び出される|
|OneTimeTearDown|全てのテストメソッド実行後に一度だけ呼び出される|
|SetUp|各テストメソッド前に呼び出される|
|TearDown|各テストメソッド後に呼び出される|
|Test|テストメソッド|

## パラメトリックテスト

### テストデータ指定

|Attribute|説明|
|---|---|
|TestCase|テストメソッドに付与し、テストデータを指定する。指定したテストデータは、テストメソッドの引数となる。|
|TestCaseSource|テストメソッドに付与し、テストデータを返すメソッドorプロパティを指定する。指定したテストデータは、テストメソッドの引数となる。|

### テストデータ自動生成

|Attribute|説明|
|---|---|
|Random|テストメソッド引数に指定し、ランダム値を生成する|
|Range|テストメソッド引数に指定し、指定した範囲内の値を生成する|
|Values|テストメソッド引数に指定し、指定したパラメータセットの値を生成する|
|ValueSource|テストメソッド引数に指定し、指定したメソッドorプロパティの値を生成する|

以下の属性で、組み合わせ方法を指定できる。

|Attribute|説明|
|---|---|
|Combinatiorial|全組み(default)|
|Pairwise|ペアワイズ法（オールペア法）|
|Sequencetial|順組み|

## その他

|Attribute|説明|
|---|---|
|Property||
|MaxTime|実行時間が指定した時間を超過している場合、テスト失敗となる。|
|Timeout|実行時間が指定した時間を超過した時、ただちにテストメソッドはキャンセルされ、テスト失敗となる。|


全Attribute (NUnit doc)
- https://github.com/nunit/docs/wiki/Attributes
