#pragma once

#include "ipcdata.h"

namespace IpcSample
{
namespace Shared
{

public ref class IpcClient
{
public:
    IpcClient();
public:
    property IpcData^ ipcData
    {
        IpcData^ get()
        {
            return m_ipcdata;
        }
    }

public:
    void open();

private:
    IpcData ^ m_ipcdata;
};

} // namespace Shared
} // namespace IpcSample
