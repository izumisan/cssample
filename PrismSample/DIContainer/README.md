# DIContainer

UnityによるDIコンテナを用いたサンプル

# DIContainerApp

## Module

- DIContainerApp.CountModule
    - ViewModelにModelをDI（コンストラクタインジェクション）したサンプル
- DIContainerApp.DuobleModule
    - ViewModelにModelを`[Dependency]`属性を使用してDI（セッターインジェクション）したサンプル

※ 本プロジェクトでは、Prism Template Packを利用してみた

# LifetimeManagerSample

- ContainerControlledLifetimeManager
    - コンテナ単位で同じインスタンスを返す（コンテナが異なれば別インスタンス）
    - コンテナ単位のシングルトン
- ExternallyControlledLifetimeManager
    - 弱参照でオブジェクトを管理する
    - GCで回収されない限り、同じインスタンスを返す
    - GC回収後は、別インスタンスを返す
- PerThreadLifetimeManager
    - スレッド単位で同じインスタンスを返す
    - スレッド単位のシングルトン
- TransientLifetimeManager
    - DIコンテナに要求する度にインスタンスを生成する
    - いわゆるFactoryクラス
- PerResolveLifetimeManager
    - DIコンテナに要求する度にインスタンスを生成する
    - TransientLifetimeManagerとの差異は？？？
    - GC回収前なら同じインスタンスが使いまわされる？？？
- HierarchicalLifetimeManager
    - ？？？

