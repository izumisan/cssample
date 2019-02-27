# quicktype

JSONのシリアライズ・デシリアライズコードを自動生成するquicktypeの試用プロジェクト

- webサービス
    - https://app.quicktype.io/
- FAQ
    - https://github.com/quicktype/quicktype/blob/master/FAQ.md
- github
    - https://github.com/quicktype/quicktype
- VSCode用extension
    - https://marketplace.visualstudio.com/items?itemName=quicktype.quicktype

# overview

- QuicktypeCS
    - webサービスで自動生成した**C#コード**の試用プロジェクト
    - `Newtonsoft.Json`用のC#コードが生成される
- QuicktypeCpp
    - webサービスで自動生成した**C++コード**の試用プロジェクト
    - JSON for Modern C++が必要
    - 自動生成されたコードではboostヘッダをインクルードしているが、コメントアウトしても、サンプルjsonでは問題なくシリアライズ・デシリアライズできた

# VSCode extension

設定項目の`Just Types`がON(default)の場合、クラス構造のみの生成となる.   OFFでシリアライズ・デシリアライズ用のコードが生成される.

# 出力コードのカスタマイズ

webサービスでは、自動生成コードをある程度カスタマイズできる.

- C#用オプション

    ![](2019-02-27-23-20-07.png)

- C++用オプション

    ![](2019-02-27-23-19-19.png)
