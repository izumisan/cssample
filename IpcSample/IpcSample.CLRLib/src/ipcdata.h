#pragma once

using namespace System;

// C#によるIpcSample.Shared.IpcDataと同じ名前空間にする

namespace IpcSample
{
namespace Shared
{

public ref class IpcData : public MarshalByRefObject
{
public:
    IpcData();

public:
    property int Value
    {
        int get()
        {
            return m_value;
        }

        void set( const int value )
        {
            m_value = value;
        }
    }

private:
    int m_value;
};

} // namespace Shared
} // namespace IpcSample
