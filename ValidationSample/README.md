# Validationサンプル

WPFの入力値検証についてのサンプルプログラム

# overview

- ValidateOnExceptions
    - 例外によるシンプルなエラー通知
- IDataErrorInfoSample
    - `IDataErrorInfo`インタフェースの実装サンプル
- ErrorContainerSample
    - prismの`ErrorContainer`を用いて、`INotifyDataErrorInfo`インターフェースを（少しだけ楽に）実装したサンプル
    - Validation属性を使用するため、`System.ComponentModel.DataAnnotations`への参照追加が必要
- ValidationAttributeSample
    - `System.ComponentModel.DataAnnotations`の`ValidationAttribute`クラスを用いたサンプル
- ValidationAttributeSample2
    - `ValidationAttribute`の派生クラスにて、独自の検証メソッドを実装したサンプル
- ValidationRule
    - ValidationRuleによる入力値検証サンプル

# 備忘録

## ValidationAttributeクラス

- RequiredAttribute
- RegularExpressionAttribute
- RangeAttribute
- MaxLengthAttribute
- MinLengthAttribute
- StringLengthAttribute
- CustomValidation
- その他
    - [ValidationAttributeクラス - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.componentmodel.dataannotations.validationattribute?redirectedfrom=MSDN&view=netframework-4.8#inheritanceContinued)

