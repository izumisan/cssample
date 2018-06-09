# CsvHelperSample

## Class Mapping

- CsvHelper.Configuration.ClassMap<T>を継承してクラスを定義する

## Converter

- CsvHelper.TypeConversion名前空間に基本的なコンバータが規定されている
- 自作する場合は、DefaultTypeConverterを継承してコンバータクラスを定義する

### EnumConverterについて

- コンストラクタでTypeを指定する必要があるため、TypeConverter<T>で指定することができない
- 列挙型用のコンバータは、別途定義必要がある
- 列挙型用のコンバータを自作する場合、このEnumConverterを継承して作ると吉
    - EnumConverter.ConvertFromStringは、数値 or 文字列から列挙型に変換してくれる
- 列挙型用汎用コンバータとして、以下のようなコンバータを用意しておくと便利
    ```cs
    public class GenericEnumConverter<T> : EnumConverter 
        where T : struct
    {
        public GenericEnumConverter()
            : base( typeof( T ) )
        {
        }
    }
    ```
