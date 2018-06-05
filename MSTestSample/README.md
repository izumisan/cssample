# MSTestSample

# テストメソッド実行順序

1. ClassInitialize
    1. TestInitialize 1
    1. TestMethod 1
    1. TestCleanup 1
    1. TestInitialize 2
    1. TestMethod 2
    1. TestCleanup 2  
        :
1. ClassCleanup

※TestMethod毎にテストクラスのインスタンスが個々に生成される？（TestMethod毎にコンストラクタが呼び出されている）

# テスト属性

- TestCategory
- Description
- DataSource
- ExpectedException
- Timeout

# Privateメソッドのテスト

PrivateObjectクラスを利用する.

[Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObjectクラス](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2012/ms245564(v=vs.110))
