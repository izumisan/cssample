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
