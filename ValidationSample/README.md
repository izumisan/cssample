# Validationサンプル

WPFの入力値検証についてのサンプルプログラム

# overview

- IDataErrorInfoSample
    - `IDataErrorInfo`インタフェースの実装サンプル
- ErrorContainerSample
    - prismの`ErrorContainer`を用いて、`INotifyDataErrorInfo`インターフェースを（少しだけ楽に）実装したサンプル
    - Validation属性を使用するため、`System.ComponentModel.DataAnnotations`への参照追加が必要

# 備忘録

## ValidationAttributeクラス

- RequiredAttribute
- RegularExpressionAttribute
- RangeAttribute
- MaxLengthAttribute
- MinLengthAttribute
- StringLengthAttribute
- その他
    - [ValidationAttributeクラス - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/api/system.componentmodel.dataannotations.validationattribute?redirectedfrom=MSDN&view=netframework-4.8#inheritanceContinued)

