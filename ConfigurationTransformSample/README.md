# ConfigurationTransformSample

- Configuration Transformの基本的な使い方サンプル

1. App.configを右クリック
1. 「Add Config Transforms」を選択
1. App.Debug.config, App.Release.configが自動生成される

- 記載例
    ```xml
    <add key="key1" value="debug" xdt:Transform="Replace"/>
    ```

- Transform属性

    |value|description|
    |---|---|
    |Replace|設定値を置換する|
    |Insert|設定情報を追加する|
    |InsertBefore|xdt:Locatorで指定したキーの前に設定情報を追加する|
    |InsertAfter|xdt:Locatorで指定したキーの後に設定情報を追加する|
