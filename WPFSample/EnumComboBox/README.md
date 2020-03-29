# EnumComboBox

ComboBoxにEnumを適用する際の実装パターンサンプル

# overview

- MonthViewModel1
    - コンボボックスのインデックスをVMでenumに変換する愚直に実装したサンプル
    - 表示用テキストはXAML上で指定
    - コンボボックスのインデックス値と列挙値が異なる場合、index => enum, enum => indexの双方向変換をそれぞれ実装する必要がある
- MonthViewModel2
    - `ItemsSource`を利用したサンプル
    - コンボボックスアイテムにオブジェクト（この例では KeyValuePairオブジェクト）をバインド
    - `DisplayMemberPath` にバインドオブジェクトのプロパティ名を指定することで、表示するデータを指定できる
    - `SelectedValuePath` にバインドオブジェクトのプロパティ名を指定することで、`SelectedValue` のプロパティを指定できる
- MonthViewModel3
    - `ItemsSource`を利用したサンプル
    - コンボボックスアイテムに列挙型をバインド
    - コンバーターを使用して、列挙型 => 表示名 を変換
    -  表示名は、`DisplayAttribute`で指定
