# Navigation

Prism Navigationによる画面遷移のサンプル

- NavigationApp
    - Shell, Bootstrapperを有するWPFアプリケーション
- NavigationApp.FooModule
    - ナビゲーションの基本
- NavigationApp.BarModule
    - Navigationパラメータを使用して、遷移先のViewのコンテンツを切り替えたサンプル

## Note

- Prism.Regionによるナビゲーションでは、一度生成したViewを再利用する
    - 画面遷移時のデータ初期化に注意
- IsNavigationTarget()
    - trueを返す場合、引数のコンテキストのターゲットViewを再利用する
- OnNavigatedTo()
    - 遷移してきた時に実行される
- OnNavigatedFrom()
    - 離れる時に実行される
