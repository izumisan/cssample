# gRPC

# overview

## Basic

gRPCの基本的な使い方

- Basic
    - protoファイルから自動生成したProtocolBuffer, gRPC用コードを含むクラスライブラリ
- Basic.Server
- Basic.Client

# 備忘録

- protoファイルの自動コンバート
    - nugetから `Grpc.Tools` をインストール
    - プロジェクトにprotoファイルを追加した後、`<None Include="protos\foo.proto" />` の部分を `<Protobuf Include="protos\foo.proto" />` のようにタグを変更する
    - ビルド実行により、protoファイルからcsファイル（ProtocolBuffer, gRPC用クラス）が自動生成、ビルドされる
        - 自動生成されたcsファイルは、`obj`ディレクトリ下に生成されている

# 参考

- [C# を使用した gRPC サービス - Microsoft docs](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/basics?view=aspnetcore-5.0)
- [gRPC C#環境を作成する - Qiita](https://qiita.com/muroon/items/4e12dde47b9e8b1e94d3)
- [gRPC / MagicOnion 入門 (2) - 4 種類の通信方式](https://blog.xin9le.net/entry/2017/06/11/182515)