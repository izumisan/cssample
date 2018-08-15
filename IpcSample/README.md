# IPCサンプル

# 起動

1. IpcSample.Serverを起動
2. IpcSample.Clientを起動

# 要点

- System.Runtime.Remotingへの参照設定が必要
- サーバ側
    ```cs {.line-numbers}
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;

    namespace IpcSample.Shared
    {
        public class IpcServer
        {
            public IpcServer()
            {
            }

            private IpcData _ipcdata = new IpcData();

            public static string Channel
            {
                get { return "ipcchannel"; }
            }

            public IpcData IpcData
            {
                get { return _ipcdata; }
            }

            public void open()
            {
                // サーバチャンネルの生成
                IpcServerChannel channel = new IpcServerChannel( Channel );

                // チャンネル登録
                ChannelServices.RegisterChannel( channel, ensureSecurity: true );

                // IPCオブジェクトの公開
                RemotingServices.Marshal( _ipcdata, "ipcdata", typeof( IpcData ) );
            }
        }
    }
    ```
- クライアント側
    ```cs {.line-numbers}
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;

    namespace IpcSample.Shared
    {
        public class IpcClient
        {
            public IpcClient()
            {
            }

            private IpcData _ipcdata = null;

            public IpcData IpcData
            {
                get { return _ipcdata; }
            }

            public void open()
            {
                // クライアントチャンネルの生成
                IpcClientChannel channel = new IpcClientChannel();

                // チャンネル登録
                ChannelServices.RegisterChannel( channel, ensureSecurity: true );

                // IPCサーバで公開されているIPCオブジェクトを取得する
                // URLは"ipc://{チャンネル名}/{公開名}"
                _ipcdata = Activator.GetObject( typeof( IpcData ), url: $"ipc://{ IpcServer.Channel }/ipcdata" ) as IpcData;
            }
        }
    }
    ```
- IPCオブジェクト
    ```cs {.line-numbers}
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    namespace IpcSample.Shared
    {
        public class IpcData : MarshalByRefObject, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = null;

            public IpcData()
            {
            }

            private int _value = 0;

            public int Value
            {
                get { return _value; }
                set
                {
                    if ( _value != value )
                    {
                        _value = value;
                        RaisePropertyChanged();
                    }
                }
            }

            private void RaisePropertyChanged( [CallerMemberName] string propertyName = "" )
            {
                this.PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );  // イベント発行
            }
        }
    }
    ```

# 参考リンク

- [C# プロセス間通信（IPC）](http://programmers.high-way.info/cs/ipc.html)
- [C# プロセス間通信（IPC） 一定時間で自動的に切断されてしまう](http://programmers.high-way.info/cs/ipc2.html)
- [.NET Remoting IPC 双方向通信](http://d.hatena.ne.jp/drambuie/20141004/p1)
