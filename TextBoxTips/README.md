# TextBox Tips

TextBoxのEnterキー押下で入力を確定（VMへ反映）する実装サンプル

# overview

- TextBoxDeterminedOnEnter
    - Commandによる実装パターン
    - Enterキー押下でVMのコマンドを実行し、VM側でプロパティを更新する
- CaptureOnEnter
    - ビヘイビアによる実装パターン
    - Enterキー押下でTextBox.Textプロパティのバイディングソースを更新する
- CaptureOnEnter2
    - 添付ビヘイビアによる実装パターン
    - Enterキー押下でTextBox.Textプロパティのバイディングソースを更新する

# 参考

- [Capturing the Enter key in a TextBox - Stack overflow](https://stackoverflow.com/questions/5556489/capturing-the-enter-key-in-a-textbox)
- [WPFのTextBoxでエンターキー押下時にBindingへ反映する - あらたまピコピコ・プログラマー養成所](https://pikopiko.artm.jp/page/note/15/)
- [【WPF】Enterキーで確定できるTextBoxにする添付プロパティ - さんさめのC＃ブログ](https://threeshark3.com/updatesource-with-enter/)
