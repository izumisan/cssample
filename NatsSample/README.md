# NATS sample

軽量でハイパフォーマンスなメッセージングシステム

- 公式ページ
    - https://nats.io/
- ドキュメント
    - https://docs.nats.io/
- NATS Server
    - ダウンロード
        - https://nats.io/download/nats-io/nats-server/
    - GitHub
        - https://github.com/nats-io/nats-server

公式ページによると、スループットはRabbitMQやKafkaに比較して大きい（see. https://nats.io/about/）


# overview

1. Pub/Subサンプル
    - Publisherプログラムから送信したメッセージをSubsriberプログラムで受信するサンプル
    - Subscriberプログラムを複数起動した場合、全てのSubscriberプログラムで受信する
1. Request/Replyサンプル
    - Requestorプログラムから送信したメッセージ内容に応じて、ReplierプログラムがFizzBuzzを返信するサンプル
1. QueueGroupサンプル
    - NATSがサポートしているQueueGroupメッセージモデルのサンプル
    - Subscriberプログラムを複数起動した場合、特定のSubscriberプログラムのみがメッセージを受信する

# NATS server

- 起動

    ```ps
    # デフォルトでは、0.0.0.0:4222でリッスンする
    > nats-server.exe
    ```
    ```ps
    # addr, portオプションでリッスンするアドレスとポートをそれぞれ指定できる
    > nats-server.exe --addr 127.0.0.1 --port 4222
    ```
    - その他オプション
    - `-l, --log <file>`
    - `-D, --debug`
    - `-V, --trace`

- 終了
    - `Ctrl + C`
