# Prism 7

2018/10にリリースされたPrism 7で仕様が大きく変わったようで、特にDIコンテナ（Unity）関連が大きく変更しているようなので、復習をかねた再入門サンプル

# overview

- PrismApp
    - Prism 7によるシンプルなサンプル
    - 非推奨となった`Bootstrapper`の代わりに`PrismApplication`を使用

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
    - Prism 7で **非推奨（Obsolete属性）** となった
    - Prism 7では、代わりに`PrismApplication`を用いる
- PrismApplication
    - Prism 7でBootstrapperの代わりに追加されたApplicationクラス
    - Appの親クラスとして利用する

# Prism公式サンプル - GitHub

- PrismLibrary/Prism-Samples-Wpf
    - https://github.com/PrismLibrary/Prism-Samples-Wpf
- サンプル概要
    - [WPF Prism episode: 2 ～ WPF のフレームワーク決まってますか？ 迷ってますか？ Prism を選択してもらっていいですか？ ～](https://elf-mission.net/programming/wpf/episode02/)
    - [C# Prism Wpf公式サンプルでよく使いそうな機能](https://qiita.com/yuchan01/items/7b43a4cef5a91cf7a476)


# Prism 7 参考リンク

- [WPF Prism 入門エントリまとめ - halation ghost](https://elf-mission.net/wpf-prism-index/)
    - [WPF Prism episode: 3 ～ Re: ゼロから始める Prism 生活 ～](https://elf-mission.net/programming/wpf/episode03/)
- [Prismカテゴリー記事一覧 - かずきのBlog@hatena](https://blog.okazuki.jp/archive/category/Prism)
    - [Prism 7.x で DI コンテナ固有の機能を使いたい](https://blog.okazuki.jp/entry/2019/02/05/094546)
    - [Prism.Forms 7.1 の新しい XAML でのナビゲーション定義](https://blog.okazuki.jp/entry/2018/07/17/114318)
