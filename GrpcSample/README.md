# gRPC

GoogleによるRPC(Remote Procedure Call)を実現したプロトコル

- [gRPC](https://grpc.io/)
    - [Quick start - C#](https://www.grpc.io/docs/languages/csharp/quickstart/)
    - [Basics tutorial - C#](https://www.grpc.io/docs/languages/csharp/basics/)

# overview

## 1. Basic

gRPCの基本的な使い方

- Basic
    - protoファイルから自動生成したProtocolBuffer, gRPC用コードを含むクラスライブラリ
- Basic.Server
- Basic.Client

## 2. Calculator

1つのサービスに複数のメソッドを定義したサンプル

- Calculator.Server
- Calculator.Client
- Calculator.Shared

## 3. MultiService

複数サービスのサンプル

- MultiService.Server
- MultiService.Client
- MultiService.Proto

## 4. ServerStreamingRpc

Server-side streaming RPC のサンプル  
1リクエストに対し、5レスポンス得る

- ServerStreamingRpc.Server
- ServerStreamingRpc.Client
- ServerStreamingRpc.Shared

## 5. ClientStreamingRpc

Client-side streaming RPC のサンプル  
複数リクエストに対し、1レスポンスを得る

- ClientStreamingRpc.Server
- ClientStreamingRpc.Client
- ClientStreamingRpc.Shared

# 通信方式

1. Simple RPC
    - 1リクエスト / 1レスポンス
1. Server-side streaming RPC
    - 1リクエスト / 複数レスポンス
1. Client-side streaming RPC
    - 複数リクエスト / 1レスポンス
1. Bidirectional streaming RPC
    - 双方向ストリーミング

[Implementing RouteGuide - gRPC](https://www.grpc.io/docs/languages/csharp/basics/#implementing-routeguide)

# 備忘録

- protoファイルの自動コンバート
    - nugetから `Grpc.Tools` をインストール
    - プロジェクトにprotoファイルを追加した後、`<None Include="protos\foo.proto" />` の部分を `<Protobuf Include="protos\foo.proto" />` のようにタグを変更する
    - ビルド実行により、protoファイルからcsファイル（ProtocolBuffer, gRPC用クラス）が自動生成、ビルドされる
        - 自動生成されたcsファイルは、`obj`ディレクトリ下に生成されている
- `foo.proto` から `Foo.cs` と `FooGrpc.cs` が生成される
    - `Foo.cs`には、Protobuf用のクラスが既定されている
        - `message`で定義したクラス
    - `FooGrpc.cs`には、gRPC用のクラスが既定されている
        - `{サービス名}` クラス
        - `{サービス名}.{サービス名}Base` クラス
        - `{サービス名}.{サービス名}Client` クラス
- 実装手順（サーバー側）
    1. `{サービス名}.{サービス名}Base`クラスを継承したサービスクラスを作成する
    1. サービスクラスで、protoファイルで定義した関数を実装する
    1. `Grpc.Core.Server`を生成する
        - `Grpc.Core.Server`に、作成したサービスクラスを登録する
    1. 生成したサーバーを開始する
- 実装手順（クライアント側）
    1. `Grpc.Core.Channel`を生成する
    1. `{サービス名}.{サービス名}Client`を生成する
        - このクライアントを介して、サービスクラスの関数を呼び出す

# nuget

- サーバープログラム / クライアントプログラム
    - **Grpc**
    - Grpc.Core
    - Grpc.Core.Api
    - **Google.Protobuf**
    - etc.
- protobufによる自動生成コードを含むライブラリプロジェクト
    - **Grpc**
    - Grpc.Core
    - Grpc.Core.Api
    - **Grpc.Tools**  （ビルド時にprotoファイルからコードを自動生成する場合）
    - **Google.Protobuf**
    - etc.

# Link

- [C# を使用した gRPC サービス - Microsoft docs](https://docs.microsoft.com/ja-jp/aspnet/core/grpc/basics?view=aspnetcore-5.0)
- [gRPC C#環境を作成する - Qiita](https://qiita.com/muroon/items/4e12dde47b9e8b1e94d3)
- [gRPC / MagicOnion 入門 (2) - 4 種類の通信方式](https://blog.xin9le.net/entry/2017/06/11/182515)
- [Protocol Buffers/gRPC Codegen Integration Into .NET Build](https://github.com/grpc/grpc/blob/master/src/csharp/BUILD-INTEGRATION.md)
    - `Grpc.Tools` についてのページ