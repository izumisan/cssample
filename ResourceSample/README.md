# リソースファイル

# Note

- ビルドアクションをResourceとした画像ファイルは、XAML上からパス指定で参照できる
- リソース（Resources.resx）内の画像ファイルは`System.Drawing.Bitmap`型。XAMLの`Image`のSouceプロパティと型が異なるので、利用の際は変換が必要
- クラスライブラリに`ResourceDictionary`を含める場合、下記の参照が必要
    - `PresentaionFramework`
    - `WindowsBase`
