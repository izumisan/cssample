# Attributeクラスのサンプル

Attributeクラスの実装についてのサンプル

# 属性クラスの実装

- 自作属性クラスを`Attribute`クラスのサブクラスとして作成する
- 自作属性クラスを指定できる対象等を`AttributeUsage`属性を使って設定する

```cs
[AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct )]
public class FooAttribute : Attribute
{ ... }
```

# 属性の取得

`Attribute`クラスの`GetCustomAttribute`メソッドや`GetCustomAttributes`メソッドにより、付与されている属性を取得できる

```cs
// FooTestClassクラスの属性を取得する
Attribute[] attributes = Attribute.GetCustomAttributes( typeof( FooTestClass ) );
```
