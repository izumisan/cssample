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
