# Private Test サンプル

プライベートなメソッドやフィールドをテストするサンプル

# overview

- PrivateTestSample
    - リフレクションによるprivateへのアクセスサンプル
- PrivateTestSample2
    - MSTestの`PrivateObject`, `PrivateType`によるprivateへのアクセスサンプル
- PrivateTestSample3
    - NUnitで`PrivateObject`, `PrivateType`を利用したサンプル

# 覚書

# Reflection

- メソッド
    - `Type.GetMethod()`で`MethodInfo`を取得して利用する
- フィールド
    - `Type.GetField()`で`FieldInfo`を取得して利用する
- プロパティ
    - `Type.GetProperty()`で`PropertyInfo`を取得して利用する

# PrivateObject, PrivateType (MSTest)

- メソッド・フィールド・プロパティ
    - `PrivateObject`を利用する
- 静的メソッド・静的フィールド・静的プロパティ
    - `PrivateType`を利用する

# NUnitベースでMSTestのPrivateObject(PrivateType)を利用する

- nugetから`MSTest.TestFramework`をインストールする
- `PrivateObject`, `PrivateType`にエイリアスを設定した上で利用する
    - `NUnit.Framework`名前空間と`Microsoft.VisualStudio.TestTools.UnitTesting`名前空間で重複しているクラス名があるため
