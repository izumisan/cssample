# Visual Studio Image Libraryの利用

Microsoft公式のVisual Studio Image Libraryの使い方

[Visual Studio Image Libraryダウンロードページ - Microsoft](https://www.microsoft.com/en-us/download/details.aspx?id=35825)

# PNGファイルの使い方

- ビルドアクションを`Resource`にすることで、xamlからパス指定で利用できる

```xml
<Image Source="path/to/foo.png"/>
```

# XAMLファイルの使い方

- xamlファイル内の`DrawingGroup`部分を下記のように`DrawingImage`として利用することで、ImageのSourceプロパティに指定できる
```xml
<!-- DrawingImageとしてリソース化して利用 -->
<DrawingImage x:Key="fooImage">
    <DrawingImage.Drawing>
        <!-- XAMLファイルのDrawingGroupをここ（DrawingImage.Drawing）にコピペ -->
        <DrawingGroup>
            ...
        </DrawingGroup>
    </DrawingImage.Drawing>
</DrawingImage>
```
```xml
<!-- Image.Sourceに指定する -->
<Image Source="{StaticResource fooImage}"/>
```