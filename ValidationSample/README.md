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

## バリデーションの実装

- VMでバリデーション
    - IDataErrorInfo or INotifyDataErrorInfoを実装
- Viewでバリデーション
    - ValidationRuleを実装

## IDataErrorInfo vs INotifyDataErrorInfo

- どちらを選んでも実装上の手間は大きく変わらない
- **INotifyDataErrorInfo**を使っておけばよい.
    - INotifyDataErrorInfoの方が後発(.net 4.5以上？)
    - prismのErrorContainerを利用できる
    - 内部的に非同期処理らしい
    - INotifyDataErrorInfoの方が直感的に実装できる（気がする）

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

## 独自の検証ロジックの実装

- CustomValidationAttributeを利用する
- ValidationAttributeのサブクラスを実装する

## ValidationAttributeのサブクラスの実装方法

- 以下の2メソッドのどちらかを実装すればよい
    1. bool IsValid( object value )
    1. ValidationResult IsValid( object value, ValidationContext validationContext )
    - 両方実装すると2の方が呼び出され、1の方は呼び出されない？
    - 2の方が若干できることが多い
        - ValidationContextから対象のプロパティを取得
        - ErrorMessageを独自指定 etc.
