#include "ipcclient.h"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

namespace IpcSample
{
namespace Shared
{

IpcClient::IpcClient()
    : m_ipcdata( gcnew IpcData() )
{
}

void IpcClient::open()
{
    IpcClientChannel^ channel = gcnew IpcClientChannel();

    ChannelServices::RegisterChannel( channel, true );
    
    m_ipcdata = (IpcData^)( Activator::GetObject( m_ipcdata->GetType(), "ipc://ipcchannel/ipcdata" ) );
}

} // namespace Shared
} // namespace IpcSample
