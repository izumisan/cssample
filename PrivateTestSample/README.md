# Private Test サンプル

プライベートなメソッドやフィールドをテストするサンプル

# overview

- PrivateTestSample
    - リフレクションによるprivateへのアクセスサンプル
- PrivateTestSample2
    - MSTestの`PrivateObject`, `PrivateType`によるprivateへのアクセスサンプル

# 覚書

## Reflection

- メソッド
    - `Type.GetMethod()`で`MethodInfo`を取得して利用する
- フィールド
    - `Type.GetField()`で`FieldInfo`を取得して利用する
- プロパティ
    - `Type.GetProperty()`で`PropertyInfo`を取得して利用する

## MSTest

- メソッド・フィールド・プロパティ
    - `PrivateObject`を利用する
- 静的メソッド・静的フィールド・静的プロパティ
    - `PrivateType`を利用する
