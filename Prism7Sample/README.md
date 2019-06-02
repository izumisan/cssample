# Prism 7

2018/10にリリースされたPrism 7で仕様が大きく変わったようで、特にDIコンテナ（Unity）関連が大きく変更しているようなので、復習をかねた再入門サンプル

# overview

- PrismApp
    - Prism 7によるシンプルなサンプル
    - 非推奨となった`Bootstrapper`の代わりに`PrismApplication`を使用
- InjectionApp
    - DIのサンプル
    - FooModule
        - コンストラクタインジェクション
    - BarModule
        - プロパティインジェクション
    - BazModule
        - コンテナ自体をDIして、コンテナから直接オブジェクトを取得するサンプル

# 基本用語

- Shell
    - Windowのこと
    - スタートアッププロジェクトのメインウィンドウ
    - Moduleを読み込む
- Module
    - 機能単位パッケージ（クラスライブラリ）
    - Viewを含む
    - Prism 7で`IModule`インタフェースが変更されており、Moduleクラスの実装方法がPrism 6とは異なる
- Region
    - Viewを読み込む先のContentControl
- Bootstrapper
    - Prismのコンポーネントやサービスを初期化する
    - Prism 7で非推奨（Obsolete属性）となった
    - Prism 7では代わりに`PrismApplication`を用いる
- PrismApplication
    - Prism 7でBootstrapperの代わりに追加されたApplicationクラス
    - Appの親クラスとして利用する

# 利用頻度が高いクラス（インタフェース）

よく出てくるクラス（インタフェース）とその基本的な用途

- Prism.Unity名前空間
    - `PrismApplication`
- Prism.Modularity名前空間
    - `IModule`
    - `IModuleCatalog`
        - モジュールを登録する
        - コンテナから取得可能
- Prism.Regions名前空間
    - `IRegionManager`
        - リージョンにViewを登録する
        - コンテナから取得可能
- Prism.Ioc名前空間
    - `IContainerProvider`
        - コンテナからオブジェクトを取得する
    - `IContainerRegistry`
        - コンテナに型（オブジェクト）を登録する
    - `IContainerExtension`
        - `IContainerProvider`と`IContainerRegistry`の両インタフェースを継承
        - コンテナから取得可能

# Prism公式サンプル - GitHub

- PrismLibrary/Prism-Samples-Wpf
    - https://github.com/PrismLibrary/Prism-Samples-Wpf
- サンプル概要
    - [WPF Prism episode: 2 ～ WPF のフレームワーク決まってますか？ 迷ってますか？ Prism を選択してもらっていいですか？ ～](https://elf-mission.net/programming/wpf/episode02/)
    - [C# Prism Wpf公式サンプルでよく使いそうな機能](https://qiita.com/yuchan01/items/7b43a4cef5a91cf7a476)
    - [Prism-Samples-Wpfの勉強メモ](https://qiita.com/hsytkm/items/5d883d1bc61819f750c4)
    - [Prism公式サンプルのメモ](https://field-notes.sakura.ne.jp/pgmemo/microsoft/dotnet/wpf/samples)


|No| Topic | Description |
|---:|-----------|-------------|
|1| Bootstrapper and the Shell | Create a basic bootstrapper and shell |
|2| Regions | Create a region |
|3| Custom Region Adapter | Create a custom region adapter for the StackPanel |
|4| View Discovery | Automatically inject views with View Discovery |
|5| View Injection | Manually add and remove views using View Injection |
|6| View Activation/Deactivation | Manually activate and deactivate views |
|7| Modules with App.config | Load modules using an App.config file |
|7| Modules with Code | Load modules using code |
|7| Modules with Directory | Load modules from a directory |
|7| Modules loaded manually | Load modules manually using the IModuleManager |
|8| ViewModelLocator | using the ViewModelLocator |
|9| ViewModelLocator - Change Convention | Change the ViewModelLocator naming conventions |
|10| ViewModelLocator - Custom Registrations | Manually register ViewModels for specific views |
|11| DelegateCommand | Use DelegateCommand and `DelegateCommand<T>` |
|12| CompositeCommands | Learn how to use CompositeCommands to invoke multiple commands as a single command |
|13| IActiveAware Commands | Make your commands IActiveAware to invoke only the active command |
|14| Event Aggregator | Using the IEventAggregator |
|15| Event Aggregator - Filter Events | Filtering events when subscribing to events |
|16| RegionContext | Pass data to nested regions using the RegionContext |
|17| Region Navigation | See how to implement basic region navigation |
|18| Navigation Callback | Get notifications when navigation has completed |
|19| Navigation Participation | Learn about View and ViewModel navigation participation with INavigationAware |
|20| Navigate to existing Views | Control view instances during navigation |
|21| Passing Parameters | Pass parameters from View/ViewModel to another View/ViewModel |
|22| Confirm/cancel Navigation | Use the IConfirmNavigationReqest interface to confirm or cancel navigation || Controlling View lifetime | Automatically remove views from memory with IRegionMemberLifetime |
|23|RegionMemberLifetime||
|24| Navigation Journal | Learn how to use the Navigation Journal |
|25| Interactivity - NotificationRequest | Learn how to show popups using an InteractionRequest |
|26| Interactivity - ConfirmationRequest | Learn how to prompt a confirmation dialog using a ConfirmationRequest |
|27| Interactivity - Custom Content | Learn how to use your own content for a dialog shown with InteractionRequest |
|28| Interactivity - Custom Request | Create your own custom request to use with an InteractionRequest |
|29| Interactivity - InvokeCommandAction | Invoke commands in response to any event |

# Prism 7 参考リンク

- [WPF Prism 入門エントリまとめ - halation ghost](https://elf-mission.net/wpf-prism-index/)
    - [WPF Prism episode: 3 ～ Re: ゼロから始める Prism 生活 ～](https://elf-mission.net/programming/wpf/episode03/)
- [Prismカテゴリー記事一覧 - かずきのBlog@hatena](https://blog.okazuki.jp/archive/category/Prism)
    - [Prism 7.x で DI コンテナ固有の機能を使いたい](https://blog.okazuki.jp/entry/2019/02/05/094546)
    - [Prism.Forms 7.1 の新しい XAML でのナビゲーション定義](https://blog.okazuki.jp/entry/2018/07/17/114318)
