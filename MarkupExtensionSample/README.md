# マークアップ拡張

XAMLにおける `{Binding ...}` や `{StaticResource ...}` といった `{}` の部分（マークアップ拡張）の実装さんぷる

# overview

- MarkupExtensionSample
    - FizzBuzzMarkup1Extension
        - 最もシンプルなマークアップ拡張クラス
    - FizzBuzzMarkup2Extention
        - `{Binding Path=xxxx}`のように、プロパティを定義したマークアップ拡張クラス
    - FizzBuzzMarkup3Extension
        - `{Binding xxxx}`のように、プロパティを省略できるマークアップ拡張クラス

# 参考

- [WPF4.5入門 その11 「マークアップ拡張」](https://blog.okazuki.jp/entry/20130103/1357205143)
- [[C#][WPF]マークアップ拡張の作り方](http://blogs.wankuma.com/kazuki/archive/2008/03/30/130476.aspx)
- [WPFマークアップ拡張の自作](https://tocsworld.wordpress.com/2014/08/10/wpf%E3%81%A7%E3%81%AE%E3%83%9E%E3%83%BC%E3%82%AF%E3%82%A2%E3%83%83%E3%83%97%E6%8B%A1%E5%BC%B5%E3%81%AE%E8%87%AA%E4%BD%9C%E3%80%90%E5%A4%B1%E6%95%97%E8%AB%87%E3%80%91/)
- [WPF:Converterを使うとき、xamlのResource内で宣言をしたくないときの書き方](http://running-cs.hatenablog.com/entry/2016/04/04/203730)
- [[WPF] Bindign用のConverterの書き方](http://kitunechan.hatenablog.jp/entry/2016/11/24/154531)
