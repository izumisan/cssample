#include "ipcserver.h"

using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

namespace IpcSample
{
namespace Shared
{

IpcServer::IpcServer()
    : m_ipcdata( gcnew IpcData() )
{
}

void IpcServer::open()
{
    IpcServerChannel^ channel = gcnew IpcServerChannel( "ipcchannel" );

    ChannelServices::RegisterChannel( channel, true );

    RemotingServices::Marshal( m_ipcdata, "ipcdata" );
}

} // namespace Shared
} // namespace IpcSample
