# Navigation

Prism Navigationによる画面遷移のサンプル

- NavigationApp
    - Shell, Bootstrapperを有するWPFアプリケーション
- NavigationApp.FooModule
    - ナビゲーションの基本
- NavigationApp.BarModule
    - Navigationパラメータを使用して、遷移先のViewのコンテンツを切り替えたサンプル

## Note

- Prism.Regions.IRegionManager.RequestNavigate()で画面を遷移する
- Prism.Regionによるナビゲーションでは、一度生成したViewを再利用する
    - 画面遷移時のデータ初期化に注意
- Prism.Regions.INavigationAwareを継承し、画面遷移時の処理をフックする
- IsNavigationTarget()
    - trueを返す場合、引数のコンテキストのターゲットViewを再利用する
    - falseを返す場合、新しいViewを作る
- OnNavigatedTo()
    - 遷移してきた時に実行される
- OnNavigatedFrom()
    - 離れる時に実行される
